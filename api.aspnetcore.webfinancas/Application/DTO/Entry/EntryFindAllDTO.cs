namespace api.aspnetcore.webfinancas.Application.DTO.Entry
{
    public class EntryFindAllDTO
    {
        public int id { get; set; }
        public string type { get; set; }
        public int personID { get; set; }
        public string personName { get; set; }
        public int purposeID { get; set; }
        public string purposeDescription { get; set; }
        public DateTime issueDate { get; set; }
        public string observation { get; set; }
        public string mode { get; set; }
    }
}
