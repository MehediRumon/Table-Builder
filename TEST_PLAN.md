# Test Plan

## Manual Testing Guide for Table Builder

This document outlines the testing procedures for the Table Builder application.

## Prerequisites for Testing

- .NET 9.0 SDK installed
- Valid OpenAI API key configured
- Sample table images for testing

## Test Cases

### 1. Image Upload Tests

#### Test 1.1: Valid Image Upload (JPG)
- **Steps**:
  1. Navigate to the application home page
  2. Click "Choose File"
  3. Select a valid JPG image containing a table
- **Expected**: Image is uploaded and preview is shown
- **Status**: ⬜ Not Tested

#### Test 1.2: Valid Image Upload (PNG)
- **Steps**: Same as 1.1 but with PNG file
- **Expected**: Image is uploaded and preview is shown
- **Status**: ⬜ Not Tested

#### Test 1.3: Invalid File Type
- **Steps**:
  1. Try to upload a PDF or text file
- **Expected**: Error message "Invalid file type. Please upload JPG, PNG, JPEG, or WEBP images only"
- **Status**: ⬜ Not Tested

#### Test 1.4: File Size Exceeds Limit
- **Steps**:
  1. Try to upload an image larger than 10MB
- **Expected**: Error message "File size exceeds 10MB limit"
- **Status**: ⬜ Not Tested

### 2. Image Paste Tests

#### Test 2.1: Paste Image from Clipboard
- **Steps**:
  1. Copy an image to clipboard (screenshot or from browser)
  2. Click on the paste area
  3. Press Ctrl+V
- **Expected**: Image is pasted and preview is shown
- **Status**: ⬜ Not Tested

#### Test 2.2: Paste with No Image in Clipboard
- **Steps**:
  1. Ensure no image is in clipboard
  2. Click paste area and press Ctrl+V
- **Expected**: No error, no action taken
- **Status**: ⬜ Not Tested

### 3. Image Preview Tests

#### Test 3.1: Remove Image
- **Steps**:
  1. Upload an image
  2. Click "Remove Image" button
- **Expected**: Image preview is removed, upload form is shown again
- **Status**: ⬜ Not Tested

#### Test 3.2: Replace Image
- **Steps**:
  1. Upload an image
  2. Upload a different image
- **Expected**: First image is replaced with the second image
- **Status**: ⬜ Not Tested

### 4. AI Table Extraction Tests

#### Test 4.1: Extract Simple Table (English)
- **Steps**:
  1. Upload an image with a simple English table (2-3 columns, 3-5 rows)
  2. Click "Generate Table"
- **Expected**: 
  - Processing indicator is shown
  - Table is extracted correctly
  - Headers and data are accurate
- **Status**: ⬜ Not Tested

#### Test 4.2: Extract Table with Bangla Text
- **Steps**:
  1. Upload an image with Bangla text in the table
  2. Click "Generate Table"
- **Expected**: Bangla text is preserved correctly
- **Status**: ⬜ Not Tested

#### Test 4.3: Extract Table with Units
- **Steps**:
  1. Upload an image with numerical data and units (kg, marks, etc.)
  2. Click "Generate Table"
- **Expected**: Units are preserved with numbers
- **Status**: ⬜ Not Tested

#### Test 4.4: Extract Complex Table
- **Steps**:
  1. Upload an image with a complex table (5+ columns, 10+ rows)
  2. Click "Generate Table"
- **Expected**: Table structure is maintained, most data is accurate
- **Status**: ⬜ Not Tested

#### Test 4.5: Unclear Image
- **Steps**:
  1. Upload a blurry or low-quality image
  2. Click "Generate Table"
- **Expected**: Error message "Unable to detect table. Please try a clearer image."
- **Status**: ⬜ Not Tested

#### Test 4.6: No Table in Image
- **Steps**:
  1. Upload an image without a table
  2. Click "Generate Table"
- **Expected**: Error message indicating no table was detected
- **Status**: ⬜ Not Tested

### 5. Table Editing Tests

#### Test 5.1: Edit Header
- **Steps**:
  1. Extract a table
  2. Click on a header cell and edit the text
  3. Tab or click outside
- **Expected**: Header text is updated
- **Status**: ⬜ Not Tested

#### Test 5.2: Edit Cell Data
- **Steps**:
  1. Extract a table
  2. Click on a data cell and edit the text
  3. Tab or click outside
- **Expected**: Cell text is updated
- **Status**: ⬜ Not Tested

#### Test 5.3: Edit Multiple Cells
- **Steps**:
  1. Extract a table
  2. Edit multiple cells in sequence
- **Expected**: All edits are preserved
- **Status**: ⬜ Not Tested

### 6. Export Tests

#### Test 6.1: Copy Table to Clipboard
- **Steps**:
  1. Extract a table
  2. Click "Copy Table (Word-Compatible)"
  3. Open Microsoft Word
  4. Press Ctrl+V
- **Expected**: 
  - Success message is shown
  - Table is pasted into Word with borders and formatting
- **Status**: ⬜ Not Tested

#### Test 6.2: Copy and Paste to Google Docs
- **Steps**:
  1. Extract a table
  2. Click "Copy Table (Word-Compatible)"
  3. Open Google Docs
  4. Press Ctrl+V
- **Expected**: Table is pasted with formatting preserved
- **Status**: ⬜ Not Tested

#### Test 6.3: Download as DOCX
- **Steps**:
  1. Extract a table
  2. Click "Download as .docx"
- **Expected**: 
  - Success message is shown
  - table.docx file is downloaded
  - File can be opened in Word
  - Table is editable
- **Status**: ⬜ Not Tested

#### Test 6.4: Verify DOCX Content
- **Steps**:
  1. Open downloaded DOCX file
  2. Verify table structure, borders, and content
- **Expected**: Table matches the extracted data exactly
- **Status**: ⬜ Not Tested

### 7. Error Handling Tests

#### Test 7.1: Generate Without Image
- **Steps**:
  1. Click "Generate Table" without uploading an image
- **Expected**: Error message "Please upload or paste an image first"
- **Status**: ⬜ Not Tested

#### Test 7.2: Invalid API Key
- **Steps**:
  1. Configure an invalid API key
  2. Upload an image and click "Generate Table"
- **Expected**: Error message about API processing failure
- **Status**: ⬜ Not Tested

#### Test 7.3: Network Error
- **Steps**:
  1. Disconnect network
  2. Try to generate table
- **Expected**: Network error message
- **Status**: ⬜ Not Tested

### 8. Performance Tests

#### Test 8.1: Processing Time
- **Steps**:
  1. Upload a medium-sized table image
  2. Click "Generate Table"
  3. Measure time to completion
- **Expected**: Processing completes in under 5 seconds
- **Status**: ⬜ Not Tested

#### Test 8.2: Large Image Processing
- **Steps**:
  1. Upload a 10MB image
  2. Click "Generate Table"
- **Expected**: Image is processed successfully (may take longer)
- **Status**: ⬜ Not Tested

### 9. UI/UX Tests

#### Test 9.1: Responsive Design
- **Steps**:
  1. Resize browser window to various sizes
  2. Test on mobile, tablet, and desktop sizes
- **Expected**: UI adapts properly to different screen sizes
- **Status**: ⬜ Not Tested

#### Test 9.2: Loading Indicators
- **Steps**:
  1. Observe UI during AI processing
- **Expected**: Loading spinner and "Processing..." text are shown
- **Status**: ⬜ Not Tested

#### Test 9.3: Success Messages
- **Steps**:
  1. Perform successful operations (extract, copy, download)
- **Expected**: Green success messages are shown and can be dismissed
- **Status**: ⬜ Not Tested

### 10. Browser Compatibility Tests

#### Test 10.1: Chrome
- **Expected**: All features work correctly
- **Status**: ⬜ Not Tested

#### Test 10.2: Firefox
- **Expected**: All features work correctly
- **Status**: ⬜ Not Tested

#### Test 10.3: Edge
- **Expected**: All features work correctly
- **Status**: ⬜ Not Tested

#### Test 10.4: Safari
- **Expected**: All features work correctly
- **Status**: ⬜ Not Tested

## Test Data

### Sample Images Needed
1. Simple table (2-3 columns, 3-5 rows) - English
2. Table with Bangla text
3. Table with numerical data and units
4. Complex table (5+ columns, 10+ rows)
5. Blurry/low-quality image
6. Image without a table
7. Large image (close to 10MB)

## Test Results Summary

Total Tests: 34
- ✅ Passed: 0
- ❌ Failed: 0
- ⬜ Not Tested: 34

## Notes for Testers

1. Before testing, ensure OpenAI API key is configured in `appsettings.json` or user secrets
2. Test with various image qualities and table complexities
3. Document any unexpected behavior
4. Report performance issues if processing takes longer than 10 seconds

## Automated Testing (Future)

### Recommended Test Frameworks
- **Unit Tests**: xUnit, NUnit
- **Integration Tests**: WebApplicationFactory
- **UI Tests**: Playwright, Selenium

### Test Coverage Goals
- Unit Test Coverage: 80%+
- Integration Test Coverage: 60%+
- Critical Path Coverage: 100%
