using AutoMapper;
using CRUDRazorPages.DataAccess.Entities;
using CRUDRazorPages.Domain.Models.Director;
using CRUDRazorPages.Domain.Models.Director.ViewModel;
using CRUDRazorPages.Domain.Models.Movie;
using CRUDRazorPages.Domain.Models.Movie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Extensions
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //Movie
            CreateMap<MovieEntity, Movie>().ReverseMap();
            CreateMap<MovieEntity, MovieDetailsViewModel>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name))
                .ReverseMap();

            //Director
            CreateMap<DirectorEntity, Director>().ReverseMap();
            CreateMap<DirectorEntity, DirectorForDDLViewModel>();
        }
    }
}
