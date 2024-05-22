using AutoMapper;
using LearnWeb.Entites;
using LearnWeb.Entites.Dtos;

namespace LearnWeb
{
    public class MappingProfile :Profile
    {
        public MappingProfile() 
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<Player, PlayerWithCharactersDto>();
            CreateMap<Character, CharacterDto>();

            CreateMap<PlayerForCreationDto, Player>();
            CreateMap<PlayerForUpdateDto, Player>();

        }
    }
}
