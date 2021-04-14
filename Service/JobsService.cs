using System;
using System.Collections.Generic;
using Models;
using Repository;

namespace Service
{
    public class JobsService
    {
        private readonly JobsRepo _repo;

        public JobsService(JobsRepo repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Jobs> GetAll()
        {
            return _repo.GetAll();
        }

        internal Jobs Get(int id)
        {
            Jobs jobs = _repo.Get(id);
            if (jobs == null)
            {
                throw new Exception("invalid id");
            }
            return jobs;
        }

        internal Jobs Create(Jobs newJob)
        {
            return _repo.Create(newJob);
        }

        internal Jobs Edit(Jobs updated)
        {
            Jobs data = Get(updated.Id);

            data.name = updated.name != null ? updated.name : data.name;
            data.price = updated.price;

            return _repo.Edit(data);
        }


        internal string Delete(int id)
        {
            Jobs original = Get(id);
            _repo.Delete(id);
            return "Successfully Deleted";
        }
    }
}