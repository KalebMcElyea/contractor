using System;
using System.Collections.Generic;
using Models;
using Repository;

namespace Service
{
    public class ContractorsService
    {
        private readonly ContractorRepo _repo;

        public ContractorsService(ContractorRepo repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Contractors> GetAll()
        {
            return _repo.GetAll();
        }

        internal Contractors Get(int id)
        {
            Contractors contractors = _repo.Get(id);
            if (contractors == null)
            {
                throw new Exception("invalid id");
            }
            return contractors;
        }

        internal Contractors Create(Contractors newContractor)
        {
            return _repo.Create(newContractor);
        }

        internal Contractors Edit(Contractors updated)
        {
            Contractors data = Get(updated.Id);

            data.name = updated.name != null ? updated.name : data.name;
            data.position = updated.position != null ? updated.position : data.position;


            return _repo.Edit(data);
        }

        internal string Delete(int id)
        {
            Contractors original = Get(id);
            _repo.Delete(id);
            return "Successfully Deleted";
        }

        internal object GetContractorsByJobId(int id)
        {
            return _repo.GetContractorsByJobId(id);
        }
    }
}