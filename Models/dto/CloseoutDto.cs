namespace OSR_API.Models.dto
{
    public class CloseoutDto
    {
        public string? DealNo { get; set; } = "";
        public string? DealNoTo { get; set; } = "";
        public DateTime? ContractDate { get; set; }
        public DateTime? ContractDateTo { get; set; } 
        public DateTime? ValueDate { get; set; }
        public DateTime? ValueDateTo { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? EntryDateTo { get; set; }
        public string? Ccy { get; set; } = "";
        public string? Portfolio { get; set; } = "";
        public string? Broker { get; set; } = "";
        public string? Customer { get; set; } = "";
        public int? OrderBy { get; set; } = 0;
    }
}
