📄 Image to Word-Compatible Table Builder

(AI-powered – GPT-4o)
Allow users to input a table image (upload or paste), automatically extract table structure using AI, and generate a Word-compatible table that can be copied or downloaded.
🔧 Functional Requirements
1️⃣ Image Input Methods
1.1 Upload Image

Supported formats:

.jpg

.png

.jpeg

.webp

Max size:

Configurable (recommended: 5–10 MB)

Validation:

Image only (reject PDF, DOCX, etc.)

Clear error message for invalid files

1.2 Paste Image (Copy–Paste)

User can:

Copy image from:

Screenshot tool

Browser

WhatsApp / Messenger

Clipboard

Paste directly into input area (Ctrl + V)

System should:

Detect clipboard image

Auto-preview pasted image

Fallback:

Show “No image detected” message

2️⃣ Image Preview

Show uploaded / pasted image preview

Options:

Remove image

Replace image

Zoom / fit toggle (optional)

3️⃣ AI Table Extraction
3.1 AI Processing (GPT-4o Vision)

Extract:

Column headers

Rows

Numeric values

Bangla & English text

Preserve:

Original order

Language

Units (kg, marks, etc.)

Detect:

Header row

Table alignment

Output format:

Structured JSON only
5️⃣ Output Actions
5.1 Copy Table

Copy as:

Word-compatible table (HTML format)

Paste directly into:

MS Word

Google Docs

Preserve:

Table borders

Alignment

5.2 Download Word File

Download format:

.docx

Word compatibility:

MS Word 2016+

Table must be:

Editable (not image-based)

Upload-safe for exam systems

6️⃣ Error Handling
Scenario	Message
No image detected	“Please upload or paste an image”
AI extraction failed	“Unable to detect table. Try clearer image.”
Partial detection	Highlight missing cells
Network error	Retry option
🧠 Non-Functional Requirements
Performance

Image processing: ≤ 5 seconds

Word generation: ≤ 1 second

Security

Do NOT store images permanently

Temporary processing only

Auto-delete after generation

Accessibility

Keyboard support (Ctrl + V)

Clear buttons

Readable font size

🧩 UI Components

Image input box (Upload + Paste)

Preview panel

“Generate Table” button

Editable table grid

Copy button

Download button

✔ Provide C# dotnet / Blazor implementation