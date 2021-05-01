using AutoMapper;
using CRUDRazorPages.DataAccess.Entities;
using CRUDRazorPages.DataAccess.Repositories.IRepositories;
using CRUDRazorPages.Domain.Models;
using CRUDRazorPages.Domain.Models.Director;
using CRUDRazorPages.Domain.Models.Director.ViewModel;
using CRUDRazorPages.Domain.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _repository;
        private readonly IMapper _mapper;

        public DirectorService(IDirectorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Director>> GetAll()
        {
            return (await _repository.GetAll()).Select(x => _mapper.Map<Director>(x)).ToList();
        }

        public async Task<Director> GetById(int id)
        {
            return _mapper.Map<Director>(await _repository.GetById(id));
        }

        public async Task<int> Add(Director model)
        {
            return await _repository.Add(_mapper.Map<DirectorEntity>(model));
        }

        public async Task<int> Update(Director model)
        {
            return await _repository.Update(_mapper.Map<DirectorEntity>(model));
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<DirectorForDDLViewModel>> GetForDDL()
        {
            return (await _repository.GetForDDL()).Select(x => _mapper.Map<DirectorForDDLViewModel>(x)).ToList();
        }
    }
}
