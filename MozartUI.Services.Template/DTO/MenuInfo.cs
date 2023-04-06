namespace MozartUI.Services.Template.DTO
{
    public class MenuInfo
    {
        public string? MenuId { get; set; }
        public string? SystemId { get; set; }
        public string? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public int Sequence { get; set; }
        public string? Type { get; set; }
        public bool? Separator { get; set; }
        public string? Params { get; set; }
        public string? State { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsWrite { get; set; }
    }
}