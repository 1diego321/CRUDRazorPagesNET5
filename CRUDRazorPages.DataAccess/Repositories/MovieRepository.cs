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
    public class MovieRepository : MasterRepository, IMovieRepository
    {
        public MovieRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<List<MovieEntity>> GetAll()
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 1)
            };

            var tableResult = await ExecuteReaderAsync("SP_Movie_Get", parameters);

            var lst = new List<MovieEntity>();

            foreach (DataRow row in tableResult.Rows)
            {
                var oMovie = new MovieEntity
                {
                    Id = Convert.ToInt32(row[0]),
                    Title = row[1].ToString(),
                    Description = row[2].ToString(),
                    Duration = Convert.ToInt32(row[3]),
                    Premiere = Convert.ToDateTime(row[4]),
                    Takings = Convert.ToInt32(row[5]),
                    DirectorId = Convert.ToInt32(row[6])
                };

                lst.Add(oMovie);
            }

            return lst;
        }

        public async Task<MovieEntity> GetById(int id)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 2),
                new SqlParameter("@Id", id)
            };

            MovieEntity oMovie = new();

            var tableResult = await ExecuteReaderAsync("SP_Movie_Get", parameters);

            foreach (DataRow row in tableResult.Rows)
            {
                oMovie = new MovieEntity
                {
                    Id = Convert.ToInt32(row[0]),
                    Title = row[1].ToString(),
                    Description = row[2].ToString(),
                    Duration = Convert.ToInt32(row[3]),
                    Premiere = Convert.ToDateTime(row[4]),
                    Takings = Convert.ToInt32(row[5]),
                    DirectorId = Convert.ToInt32(row[6])
                };
            }

            return oMovie;
        }

        public async Task<int> Add(MovieEntity entity)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 1),
                new SqlParameter("@Title", entity.Title),
                new SqlParameter("@Description", entity.Description),
                new SqlParameter("@Duration", entity.Duration),
                new SqlParameter("@Premiere", entity.Premiere),
                new SqlParameter("@Takings", entity.Takings),
                new SqlParameter("@DirectorId", entity.DirectorId)
            };

            return await ExecuteNonQueryAsync("SP_Movie_Transaction", parameters);
        }
        
        public async Task<int> Update(MovieEntity entity)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 2),
                new SqlParameter("@Id", entity.Id),
                new SqlParameter("@Title", entity.Title),
                new SqlParameter("@Description", entity.Description),
                new SqlParameter("@Duration", entity.Duration),
                new SqlParameter("@Premiere", entity.Premiere),
                new SqlParameter("@Takings", entity.Takings),
                new SqlParameter("@DirectorId", entity.DirectorId)
            };

            return await ExecuteNonQueryAsync("SP_Movie_Transaction", parameters);
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@Option", 3),
                new SqlParameter("@Id", id)
            };

            return await ExecuteNonQueryAsync("SP_Movie_Transaction", parameters);
        }

    }
}
