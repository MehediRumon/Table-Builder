using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using TableBuilder.Models;
using System.ClientModel;
using System.Text.Json;

namespace TableBuilder.Services;

public class TableExtractionService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TableExtractionService> _logger;

    public TableExtractionService(IConfiguration configuration, ILogger<TableExtractionService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<TableData?> ExtractTableFromImageAsync(string imageDataUrl)
    {
        try
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                _logger.LogError("OpenAI API key is not configured");
                return null;
            }

            var client = new AzureOpenAIClient(new Uri(_configuration["OpenAI:Endpoint"] ?? "https://api.openai.com/v1"), new ApiKeyCredential(apiKey));
            var chatClient = client.GetChatClient(_configuration["OpenAI:Model"] ?? "gpt-4o");

            // Extract base64 data from data URL
            var base64Data = imageDataUrl.Contains(",") ? imageDataUrl.Split(',')[1] : imageDataUrl;
            var imageBytes = Convert.FromBase64String(base64Data);

            var messages = new List<ChatMessage>
            {
                new SystemChatMessage("You are an expert at extracting table data from images. Extract the table structure including headers and rows. Return ONLY valid JSON in the format: {\"headers\": [\"col1\", \"col2\"], \"rows\": [[\"val1\", \"val2\"], [\"val3\", \"val4\"]]}. Preserve the original language (English or Bangla) and all units (kg, marks, etc.)."),
                new UserChatMessage(
                    ChatMessageContentPart.CreateTextPart("Extract the table from this image and return it as JSON."),
                    ChatMessageContentPart.CreateImagePart(BinaryData.FromBytes(imageBytes), "image/png")
                )
            };

            var options = new ChatCompletionOptions
            {
                MaxOutputTokenCount = 2000,
                Temperature = 0.1f
            };

            var response = await chatClient.CompleteChatAsync(messages, options);
            var content = response.Value.Content[0].Text;

            _logger.LogInformation("AI Response: {Content}", content);

            // Clean the response to extract JSON
            var jsonStart = content.IndexOf('{');
            var jsonEnd = content.LastIndexOf('}');
            if (jsonStart >= 0 && jsonEnd > jsonStart)
            {
                content = content.Substring(jsonStart, jsonEnd - jsonStart + 1);
            }

            var tableData = JsonSerializer.Deserialize<TableData>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return tableData;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error extracting table from image");
            return null;
        }
    }
}
