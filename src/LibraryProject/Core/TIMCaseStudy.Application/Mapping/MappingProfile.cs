using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Common.Models.Queries;
using TIMCaseStudy.Common.Models.RequestModels;
using TIMCaseStudy.Domain.Entities;

namespace TIMCaseStudy.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookFilterViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(a => a.NameSurname)));

            CreateMap<CreateBookTransactionCommand, BookTransaction>()
                .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => DateTime.Parse(src.ReturnDate)));
        }
    }
}
