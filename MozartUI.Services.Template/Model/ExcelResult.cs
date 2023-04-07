using System.Data;

namespace MozartUI.Services.Template;

public class ExcelResult
{
    public DataTable Table { get; set; }
    public int TotalCount { get; set; }
    public int SuccessCount { get; set; }
    public int ErrorCount { get; set; }
    public string ErrorMsg { get; set; }
}
