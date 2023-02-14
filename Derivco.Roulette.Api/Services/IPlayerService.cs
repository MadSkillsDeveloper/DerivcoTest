using Derivco.Roulette.Api.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.Roulette.Api.Services
{
    public interface IPlayerService
    {
        Task PlaceBetAsync(PlayerBetRequest playerBetRequest);
        Task SpinAsync(Guid id, int spin);
        Task<decimal> PayoutAsync(Guid PlayerBetId);
        Task<IList<PlayerBetReponse>> PreviousSpinsAsync();
    }
}
