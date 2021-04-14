namespace Models
{
    public class Contractors
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
    }

    public class ContractorJobsProductViewModel : Contractors
    {
        public int ContractorJobContractorId { get; set; }

    }
}