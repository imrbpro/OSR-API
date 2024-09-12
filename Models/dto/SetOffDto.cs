namespace OSR_API.Models.dto
{
    public class SetOffDto
    {
        public string? DealNo { get; set; } = "";
        public string? DealNoTo { get; set; } = "";
        public string? ContractDate { get; set; } = "";
        public string? ContractDateTo { get; set; } = "";
        public string? ValueDate { get; set; } = "";
        public string? ValueDateTo { get; set; } = "";
        public string? EntryDate { get; set; } = "";
        public string? EntryDateTo { get; set; } = "";
        public string? Ccy { get; set; } = "";
        public string? Portfolio { get; set; } = "";
        public string? Trad { get; set; } = "";
        public string? Customer { get; set; } = "";
        public int? OrderBy { get; set; } = 0;
    }
}
