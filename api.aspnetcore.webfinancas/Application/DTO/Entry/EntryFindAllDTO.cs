namespace api.aspnetcore.webfinancas.Application.DTO.Entry
{
    public class EntryFindAllDTO
    {
        public int id { get; set; }
        
        public DateTime issue_date { get; set; }

        public string type { get; set; }    

        public int person_id { get; set; }

        public string person_name { get; set; }

        public int purpose_id { get; set; }

        public string purpose_description {  get; set; }

        public string mode { get; set; }    

        public int bank_account_id {  get; set; }   

        public string bank_account_description {  get; set; }   

        public double total {  get; set; }
    }
}
