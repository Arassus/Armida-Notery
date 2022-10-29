using Amrida.Notery.Presentation.Core.Models;
using Armida.Notery.Common.Dtos;
using AutoMapper;

namespace API.Profiles
{
    public class NoteryMappingProfile : Profile
    { 
        public NoteryMappingProfile()
        {
            CreateMap<Notebook, NotebookDto>();
            CreateMap<NotebookDto, Notebook>();
        }
    }
}
