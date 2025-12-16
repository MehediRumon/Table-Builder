using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using TableBuilder.Models;

namespace TableBuilder.Services;

public class WordDocumentService
{
    public byte[] GenerateWordDocument(TableData tableData)
    {
        using var memoryStream = new MemoryStream();
        using (var wordDocument = WordprocessingDocument.Create(memoryStream, WordprocessingDocumentType.Document))
        {
            var mainPart = wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            var body = mainPart.Document.AppendChild(new Body());

            // Create table
            var table = new Table();

            // Set table properties
            var tableProperties = new TableProperties(
                new TableBorders(
                    new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 }
                ),
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct }
            );
            table.AppendChild(tableProperties);

            // Add header row
            if (tableData.Headers.Count > 0)
            {
                var headerRow = new TableRow();
                foreach (var header in tableData.Headers)
                {
                    var cell = new TableCell();
                    var paragraph = new Paragraph(new Run(new Text(header)));
                    var paragraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
                    paragraph.InsertAt(paragraphProperties, 0);
                    
                    var runProperties = new RunProperties(new Bold());
                    paragraph.Descendants<Run>().First().InsertAt(runProperties, 0);
                    
                    cell.Append(paragraph);
                    headerRow.Append(cell);
                }
                table.Append(headerRow);
            }

            // Add data rows
            foreach (var row in tableData.Rows)
            {
                var tableRow = new TableRow();
                foreach (var cellValue in row)
                {
                    var cell = new TableCell();
                    var paragraph = new Paragraph(new Run(new Text(cellValue ?? "")));
                    cell.Append(paragraph);
                    tableRow.Append(cell);
                }
                table.Append(tableRow);
            }

            body.Append(table);
            mainPart.Document.Save();
        }

        return memoryStream.ToArray();
    }

    public string GenerateHtmlTable(TableData tableData)
    {
        var html = "<table border='1' style='border-collapse: collapse; width: 100%;'>";
        
        // Add header row
        if (tableData.Headers.Count > 0)
        {
            html += "<thead><tr>";
            foreach (var header in tableData.Headers)
            {
                html += $"<th style='border: 1px solid black; padding: 8px; text-align: center; font-weight: bold;'>{header}</th>";
            }
            html += "</tr></thead>";
        }
        
        // Add data rows
        html += "<tbody>";
        foreach (var row in tableData.Rows)
        {
            html += "<tr>";
            foreach (var cellValue in row)
            {
                html += $"<td style='border: 1px solid black; padding: 8px;'>{cellValue ?? ""}</td>";
            }
            html += "</tr>";
        }
        html += "</tbody></table>";
        
        return html;
    }
}
