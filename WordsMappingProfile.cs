using _NorskOrd_.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_
{
    public class WordsMappingProfile : Profile
    {
        public WordsMappingProfile()
        {
            CreateMap<Words, AddNewWordDto>();

            CreateMap<AddNewWordDto, Words>();
        }

        
    }
}
