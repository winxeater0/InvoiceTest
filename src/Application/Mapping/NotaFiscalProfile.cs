using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class NotaFiscalProfile : Profile
{
    public NotaFiscalProfile()
    {
        CreateMap<NotaFiscal, NotaFiscalDto>()
            .ForCtorParam("CnpjPrestador", opt => opt.MapFrom(src => src.CnpjPrestador.Value))
            .ForCtorParam("CnpjTomador", opt => opt.MapFrom(src => src.CnpjTomador.Value));
    }
}
