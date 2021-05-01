using AutoMapper;
using CRUDRazorPages.DataAccess.Entities;
using CRUDRazorPages.DataAccess.Repositories.IRepositories;
using CRUDRazorPages.Domain.Models;
using CRUDRazorPages.Domain.Models.Movie;
using CRUDRazorPages.Domain.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Movie>> GetAll()
        {
            return (await _repository.GetAll()).Select(x => _mapper.Map<Movie>(x)).ToList();
        }

        public async Task<Movie> GetById(int id)
        {
            return _mapper.Map<Movie>(await _repository.GetById(id));
        }

        public async Task<int> Add(Movie model)
        {
            return await _repository.Add(_mapper.Map<MovieEntity>(model));
        }

        public async Task<int> Update(Movie model)
        {
            return await _repository.Update(_mapper.Map<MovieEntity>(model));
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
