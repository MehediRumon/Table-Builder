# Configuration Guide

## OpenAI API Setup

To use the Table Builder application, you need to configure your OpenAI API credentials.

### Steps:

1. **Get an OpenAI API Key:**
   - Go to [OpenAI Platform](https://platform.openai.com/)
   - Sign up or log in to your account
   - Navigate to API Keys section
   - Create a new API key

2. **Configure the Application:**

   Update the `appsettings.json` file with your API key:

   ```json
   {
     "OpenAI": {
       "ApiKey": "YOUR_OPENAI_API_KEY_HERE",
       "Endpoint": "https://api.openai.com/v1",
       "Model": "gpt-4o"
     }
   }
   ```

   **For development**, you can also use User Secrets:

   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "OpenAI:ApiKey" "your-api-key-here"
   ```

3. **Environment Variables (Production):**

   For production deployments, set environment variables:

   - `OpenAI__ApiKey`: Your OpenAI API key
   - `OpenAI__Endpoint`: API endpoint (default: https://api.openai.com/v1)
   - `OpenAI__Model`: Model to use (default: gpt-4o)

## Running the Application

1. **Install Dependencies:**
   ```bash
   dotnet restore
   ```

2. **Run the Application:**
   ```bash
   dotnet run
   ```

3. **Access the Application:**
   Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`

## Features

- **Image Upload**: Upload table images in JPG, PNG, JPEG, or WEBP format
- **Paste Image**: Copy and paste images directly from clipboard
- **AI Extraction**: Automatically extract table structure using GPT-4o Vision
- **Editable Table**: Edit extracted table data before export
- **Copy to Clipboard**: Copy table in Word-compatible HTML format
- **Download as .docx**: Download editable Word document

## Troubleshooting

- **"Unable to detect table"**: Ensure the image is clear and the table is visible
- **API Key Error**: Verify your OpenAI API key is correctly configured
- **File Size Error**: Maximum image size is 10MB
