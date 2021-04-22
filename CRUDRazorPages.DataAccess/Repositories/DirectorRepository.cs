using CRUDRazorPages.DataAccess.Entities;
using CRUDRazorPages.DataAccess.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Repositories
{
    public class DirectorRepository : MasterRepository ,IDirectorRepository
    {
        public DirectorRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<List<DirectorEntity>> GetAll()
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 1)
            };

            var tableResult = await ExecuteReaderAsync("SP_Director_Get", parameters);

            var lst = new List<DirectorEntity>();

            foreach (DataRow row in tableResult.Rows)
            {
                var oMovie = new DirectorEntity
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    AmountOfPrizes = Convert.ToInt32(row[2]),
                    Birthdate = Convert.ToDateTime(row[3])
                };

                lst.Add(oMovie);
            }

            return lst;
        }

        public async Task<DirectorEntity> GetById(int id)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 2),
                new SqlParameter("@Id", id)
            };

            DirectorEntity oDirector = new();

            var tableResult = await ExecuteReaderAsync("SP_Director_Get", parameters);

            foreach (DataRow row in tableResult.Rows)
            {
                oDirector = new DirectorEntity
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    AmountOfPrizes = Convert.ToInt32(row[2]),
                    Birthdate = Convert.ToDateTime(row[3])
                };
            }

            return oDirector;
        }

        public async Task<int> Add(DirectorEntity entity)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 1),
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@Birthdate", entity.Birthdate),
                new SqlParameter("@AmountOfPrizes", entity.AmountOfPrizes),       
            };

            return await ExecuteNonQueryAsync("SP_Director_Transaction", parameters);
        }

        public async Task<int> Update(DirectorEntity entity)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 2),
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@Birthdate", entity.Birthdate),
                new SqlParameter("@AmountOfPrizes", entity.AmountOfPrizes),
            };

            return await ExecuteNonQueryAsync("SP_Director_Transaction", parameters);
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 3),
                new SqlParameter("@Id", id),

            };

            return await ExecuteNonQueryAsync("SP_Director_Transaction", parameters);
        }
    }
}
