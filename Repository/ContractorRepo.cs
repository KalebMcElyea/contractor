using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repository
{
    public class ContractorRepo
    {

        public readonly IDbConnection _db;

        public ContractorRepo(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Contractors> GetAll()
        {
            string sql = "SELECT * FROM contractor;";
            return _db.Query<Contractors>(sql);
        }

        internal Contractors Get(int id)
        {
            string sql = "SELECT * FROM contractor WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Contractors>(sql, new { id });
        }

        internal Contractors Create(Contractors newContractor)
        {
            string sql = @"
      INSERT INTO contractor
      (name, position)
      VALUES
      (@Name, @Position,);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newContractor);
            newContractor.Id = id;
            return newContractor;
        }

        internal Contractors Edit(Contractors data)
        {
            string sql = @"
      UPDATE contractor
      SET
        name = @Name,
        position = @Position,
      WHERE id = @Id;
      SELECT * FROM contractor WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Contractors>(sql, data);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contractor WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }

        internal object GetContractorsByJobId(int id)
        {
            string sql = @"SELECT 
      c.*,
      cj.id AS ContractorJobContractorId
      FROM contractorjobs cj
      JOIN contractor c ON c.id = cj.jobId
      WHERE jobId = @id;";
            return _db.Query<ContractorJobsProductViewModel>(sql, new { id });
        }
    }
}