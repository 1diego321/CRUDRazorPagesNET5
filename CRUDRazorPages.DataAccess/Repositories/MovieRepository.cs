using CRUDRazorPages.DataAccess.Contracts.IRepositories;
using CRUDRazorPages.DataAccess.Contracts.ISQL;
using CRUDRazorPages.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Repositories
{
    public class MovieRepository : IGenericRepository<Movie>
    {
        private readonly ISqlHelper _helper;

        public MovieRepository(ISqlHelper helper)
        {
            _helper = helper;
        }

        public async Task<List<Movie>> GetAll()
        {
            var dt = await _helper.ExecuteReaderAsync("");

            var lst = new List<Movie>();

            foreach (DataRow row in dt.Rows)
            {
                var oMovie = new Movie
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

        public Task<Movie> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<int> Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
