using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repository
{
    public class JobsRepo
    {

        public readonly IDbConnection _db;

        public JobsRepo(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Jobs> GetAll()
        {
            string sql = "SELECT * FROM job;";
            return _db.Query<Jobs>(sql);
        }

        internal Jobs Get(int id)
        {
            string sql = "SELECT * FROM job WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Jobs>(sql, new { id });
        }

        internal Jobs Create(Jobs newJob)
        {
            string sql = @"
      INSERT INTO job
      (name, price)
      VALUES
      (@Name,  @Price,;
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newJob);
            newJob.Id = id;
            return newJob;
        }

        internal Jobs Edit(Jobs data)
        {
            string sql = @"
      UPDATE job
      SET
        name = @Name,
        price = @Price,
      WHERE id = @Id;
      SELECT * FROM flight WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Jobs>(sql, data);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM job WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}