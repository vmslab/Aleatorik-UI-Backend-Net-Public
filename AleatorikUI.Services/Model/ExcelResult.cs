using System.Data;

namespace AleatorikUI.Services.Model;

public class ExcelResult
{
    public DataTable Table { get; set; }
    public int TotalCount { get; set; }
    public int SuccessCount { get; set; }
    public int ErrorCount { get; set; }
    public string ErrorMsg { get; set; }
}
