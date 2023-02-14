using AutoMapper;
using Derivco.Roulette.Api.DTO;
using Derivco.Roullete.Domain;
using Derivco.Roullete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Derivco.Roulette.Api.Services
{
    public class PlayerService : IPlayerService
    {
        #region Fields
        private readonly IRepositoryFacade _repositoryFacade;
        private readonly IMapper _mapper;
        #endregion

        #region Properties
        #endregion

        #region Methods
        public async Task<decimal> PayoutAsync(Guid playerBetId)
        {
            var playerBets = await _repositoryFacade
                .PlayerBetRepository
                .GetPlayerBetListAsync();

            var playerBet = playerBets
                .FirstOrDefault(x =>
                    x.Id == playerBetId.ToString());

            var bets = await _repositoryFacade.BetRepository.GetBetsAsync();
            var bet = bets.FirstOrDefault(x => x.Id == Guid.Parse(playerBet.BetId));


            return CalculatePayout(playerBet.Spin, bet.Id);
        }

        private static decimal CalculatePayout(int? spin, Guid id)
        {
            return 35000.0M;
        }

        public async Task PlaceBetAsync(PlayerBetRequest playerBetRequest)
        {
            var playerBet = _mapper.Map<PlayerBet>(playerBetRequest);
            playerBet.Id = Guid.NewGuid().ToString();
            await _repositoryFacade.PlayerBetRepository.AddPlayerBetAysnc(playerBet);
        }

        public async Task<IList<PlayerBetReponse>> PreviousSpinsAsync()
        {
            var playerBets = await _repositoryFacade
                                    .PlayerBetRepository
                                    .GetPlayerBetListAsync();

            return _mapper.Map<List<PlayerBetReponse>>(playerBets);
        }

        public async Task SpinAsync(Guid playerBetId, int spin)
        {
            await _repositoryFacade.PlayerBetRepository.UpdatePlayerBetAsync(playerBetId, spin);
        }
        #endregion

        #region Constructors
        public PlayerService(IRepositoryFacade repositoryFacade, IMapper mapper)
        {
            _repositoryFacade = repositoryFacade;
            _mapper = mapper;
        }
        #endregion

    }
}
