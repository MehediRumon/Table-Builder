namespace TableBuilder.Models;

public class TableData
{
    public List<string> Headers { get; set; } = new();
    public List<List<string>> Rows { get; set; } = new();
}
