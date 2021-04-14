namespace Models
{
    public class ContractorJobs
    {
        public ContractorJobs()
        {
        }

        public int Id { get; set; }
        public int ContractorsId { get; set; }
        public int JobsId { get; set; }
    }
}