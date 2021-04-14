using System;
using Models;
using Repository;

namespace Service
{
    public class ContractorJobsService
    {
        private readonly ContractorJobsRepo _repo;

        public ContractorJobsService(ContractorJobsRepo repo)
        {
            _repo = repo;
        }

        internal ContractorJobs Create(ContractorJobs newCJ)
        {

            return _repo.Create(newCJ);
        }

        internal string Delete(int id)
        {
            ContractorJobs original = Get(id);
            _repo.Delete(id);
            return "Successfully Deleted";
        }

        private ContractorJobs Get(int id)
        {
            ContractorJobs contractorJobs = _repo.Get(id);
            if (contractorJobs == null)
            {
                throw new Exception("invalid id");
            }
            return contractorJobs;

        }
    }
}