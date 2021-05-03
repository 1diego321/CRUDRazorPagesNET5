using AutoMapper;
using CRUDRazorPages.DataAccess.Entities;
using CRUDRazorPages.DataAccess.Repositories.IRepositories;
using CRUDRazorPages.Domain.Models;
using CRUDRazorPages.Domain.Models.Movie;
using CRUDRazorPages.Domain.Models.Movie.ViewModel;
using CRUDRazorPages.Domain.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MovieService(IMovieRepository repository, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<List<Movie>> GetAll()
        {
            return (await _repository.GetAll()).Select(x => _mapper.Map<Movie>(x)).ToList();
        }

        public async Task<Movie> GetById(int id)
        {
            return _mapper.Map<Movie>(await _repository.GetById(id));
        }

        public async Task<MovieDetailsViewModel> GetForDetailsById(int id)
        {
            return _mapper.Map<MovieDetailsViewModel>(await _repository.GetForDetailsById(id));
        }

        public async Task<int> Add(Movie model)
        {
            if (model.Image != null)
            {
                string mainRoute = _hostEnvironment.WebRootPath;
                string routeImgFolder = Path.Combine(mainRoute, @"img");
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                string imageRoute = Path.Combine(routeImgFolder, imageName);

                Directory.CreateDirectory(routeImgFolder);

                using (var fs = new FileStream(imageRoute, FileMode.Create))
                {
                    model.Image.CopyTo(fs);

                    model.ImageURL = @"\img\" + imageName;
                }
            }

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
