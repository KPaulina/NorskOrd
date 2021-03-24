using _NorskOrd_.Controllers;
using _NorskOrd_.Data;
using _NorskOrd_.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<Player, PlayerDto>();
        }
    }
}
