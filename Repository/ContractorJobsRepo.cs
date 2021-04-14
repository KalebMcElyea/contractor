using System;
using System.Data;
using Dapper;
using Models;

namespace Repository
{
    public class ContractorJobsRepo
    {
        public readonly IDbConnection _db;

        public ContractorJobsRepo(IDbConnection db)
        {
            _db = db;
        }



        internal ContractorJobs Get(int id)
        {
            string sql = "SELECT * FROM contractorjobs WHERE id = @Id;";
            return _db.QueryFirstOrDefault<ContractorJobs>(sql, new { id });
        }

        internal ContractorJobs Create(ContractorJobs newCJ)
        {
            string sql = @"
      INSERT INTO contractorjobs
      (contractorsid , jobsid)
      VALUES
      (@ContractorsId , @JobsId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCJ);
            newCJ.Id = id;
            return newCJ;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contractorjobs WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}