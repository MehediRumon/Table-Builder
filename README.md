# 📄 Image to Word-Compatible Table Builder

**AI-powered table extraction using GPT-4o Vision**

This Blazor web application allows users to upload or paste table images and automatically extract table structure using AI (GPT-4o Vision API). The extracted tables can be edited and exported as Word-compatible HTML or downloadable .docx files.

## ✨ Features

### 🖼️ Image Input
- **Upload**: Support for JPG, PNG, JPEG, and WEBP formats (max 10MB)
- **Paste**: Direct image paste from clipboard (Ctrl+V)
- **Preview**: Live preview of uploaded/pasted images
- **Validation**: File type and size validation with clear error messages

### 🤖 AI Table Extraction (GPT-4o Vision)
- Extracts column headers and table rows
- Preserves original language (English, Bangla, etc.)
- Maintains numeric values and units (kg, marks, etc.)
- Detects table structure and alignment
- Returns structured JSON data

### ✏️ Editable Table
- Edit headers and cell values after extraction
- Real-time editing with immediate updates
- Clean, responsive table interface

### 📤 Export Options
- **Copy to Clipboard**: Word-compatible HTML format (paste into MS Word, Google Docs)
- **Download as .docx**: Editable Word document with proper formatting
- Preserves table borders and alignment

### 🛡️ Error Handling
- Image validation and error messages
- AI extraction failure handling
- Network error recovery
- User-friendly error notifications

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- OpenAI API key with GPT-4o Vision access

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/MehediRumon/Table-Builder.git
   cd Table-Builder
   ```

2. **Configure OpenAI API**
   
   Update `appsettings.json` with your OpenAI API key:
   ```json
   {
     "OpenAI": {
       "ApiKey": "YOUR_OPENAI_API_KEY_HERE",
       "Endpoint": "https://api.openai.com/v1",
       "Model": "gpt-4o"
     }
   }
   ```
   
   Or use User Secrets for development:
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "OpenAI:ApiKey" "your-api-key-here"
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Build the project**
   ```bash
   dotnet build
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   
   Open your browser and navigate to:
   - HTTPS: `https://localhost:5001`
   - HTTP: `http://localhost:5000`

## 📖 Usage

1. **Upload or Paste Image**
   - Click "Choose File" to upload an image, or
   - Click on the paste area and press Ctrl+V to paste from clipboard

2. **Preview Image**
   - Review the uploaded image
   - Remove or replace if needed

3. **Generate Table**
   - Click "Generate Table" button
   - Wait for AI processing (typically 3-5 seconds)

4. **Edit Table**
   - Edit any header or cell value as needed
   - Changes are applied immediately

5. **Export**
   - Click "Copy Table" to copy HTML to clipboard (paste into Word/Docs)
   - Click "Download as .docx" to download editable Word document

## 🏗️ Project Structure

```
TableBuilder/
├── Components/
│   ├── Layout/          # Layout components
│   ├── Pages/           # Razor pages
│   │   └── Home.razor   # Main table builder page
│   ├── App.razor        # Root component
│   └── _Imports.razor   # Global imports
├── Models/
│   ├── TableData.cs            # Table data model
│   └── ImageUploadResult.cs    # Image upload result model
├── Services/
│   ├── TableExtractionService.cs   # AI extraction service
│   └── WordDocumentService.cs      # Word document generation
├── wwwroot/
│   ├── js/
│   │   └── app.js       # JavaScript utilities
│   └── lib/             # Bootstrap and other libraries
├── appsettings.json     # Application configuration
├── Program.cs           # Application entry point
└── README.md           # This file
```

## 🔧 Configuration

See [CONFIGURATION.md](CONFIGURATION.md) for detailed configuration instructions.

### Environment Variables (Production)

For production deployments, use environment variables:
- `OpenAI__ApiKey`: Your OpenAI API key
- `OpenAI__Endpoint`: API endpoint (default: https://api.openai.com/v1)
- `OpenAI__Model`: Model to use (default: gpt-4o)

## 🛠️ Technologies Used

- **Framework**: ASP.NET Core Blazor (.NET 9.0)
- **AI**: OpenAI GPT-4o Vision API (Azure.AI.OpenAI 2.1.0)
- **Word Processing**: DocumentFormat.OpenXml 3.2.0
- **UI**: Bootstrap 5
- **JavaScript**: Vanilla JS for clipboard and file handling

## 📋 Requirements Met

✅ Image upload (JPG, PNG, JPEG, WEBP)  
✅ Paste image from clipboard (Ctrl+V)  
✅ Image preview with remove/replace options  
✅ AI table extraction using GPT-4o Vision  
✅ Preserve language (English, Bangla) and units  
✅ Editable table grid  
✅ Copy table as Word-compatible HTML  
✅ Download as .docx file  
✅ Error handling and validation  
✅ Responsive UI with Bootstrap  
✅ C# .NET Blazor implementation  

## 🔒 Security & Performance

- **Security**: Images are processed in memory only, no permanent storage
- **Validation**: File type and size validation on upload
- **Performance**: 
  - AI processing: ~3-5 seconds
  - Word generation: <1 second

## 📝 License

This project is open source and available under the MIT License.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📧 Support

For issues and questions, please open an issue on GitHub.
