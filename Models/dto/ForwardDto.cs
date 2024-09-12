namespace OSR_API.Models.dto
{
    public class ForwardDto
    {
        public string? DealNo { get; set; } = "";
        public string? DealNoTo { get; set; } = "";
        public string? DealDate { get; set; } = "";
        public string? DealDateTo { get; set; } = "";
        public string? ODate { get; set; } = "";
        public string? ODateTo { get; set; } = "";
        public string? ValueDate { get; set; } = "";
        public string? ValueDateTo { get; set; } = "";
        public string? Ccy { get; set; } = "";
        public string? PortFolio { get; set; } = "";
        public string? Broker { get; set; } = "";
        public string? Trader { get; set; } = "";
        public string? Customer { get; set; } = "";     
        public int? OrderBy { get; set; }
    }
}
