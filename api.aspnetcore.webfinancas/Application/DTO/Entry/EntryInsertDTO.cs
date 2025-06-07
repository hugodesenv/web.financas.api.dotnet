namespace api.aspnetcore.webfinancas.Application.DTO.Entry
{
    public class EntryInsertDTO
    {
        // payable or receivable]
        public String type { get; set; }
        public int person_id { get; set; }
        public int purpose_id { get; set; }
        public DateTime issue_date { get; set; }
        public String observation { get; set; }
        // Predicted or regular
        public String mode { get; set; }
    }
}
