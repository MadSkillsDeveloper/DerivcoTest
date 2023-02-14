using AutoMapper;
using Derivco.Roulette.Api.DTO;
using Derivco.Roullete.Domain;

namespace Derivco.Roulette.Api.Mappings
{
    public class RouletteMappings : Profile
    {
        public RouletteMappings()
        {
            CreateMap<PlayerBetRequest, PlayerBet>();
            CreateMap<PlayerBet, PlayerBetReponse>();
        }
    }
}
