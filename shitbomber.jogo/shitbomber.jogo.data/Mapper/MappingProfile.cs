using AutoMapper;
using shitbomber.jogo.data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Model = shitbomber.jogo.domain.Model;

namespace shitbomber.jogo.data.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Teste, Teste>().ReverseMap();
        }
    }
}
