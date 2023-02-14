using Dapper;
using Derivco.Roulette.Infrastructure.Data.Scritps;
using Derivco.Roullete.Domain;
using Derivco.Roullete.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.Roulette.Infrastructure.Data.Repository
{
    public class PlayerBetRepository : IPlayerBetRepository
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Properties
        #endregion

        #region Methods
        public async Task AddPlayerBetAysnc(PlayerBet playerBet)
        {
            using DataContext dataContext = new(_connectionString);
            dataContext.Connection.Open();
            await dataContext.Connection.ExecuteAsync(DMLConstants.INSERT_PLAYERBET, playerBet);
        }

        public async Task<IList<PlayerBet>> GetPlayerBetListAsync()
        {
            using DataContext dataContext = new(_connectionString);
            dataContext.Connection.Open();
            return (IList<PlayerBet>)
                await dataContext.Connection
                .QueryAsync(DMLConstants.GET_ALL_PLAYERBETS);
        }

        public async Task UpdatePlayerBetAsync(Guid playerBetId, int spin)
        {
            using DataContext dataContext = new(_connectionString);
            dataContext.Connection.Open();
            await dataContext.Connection.ExecuteAsync(DMLConstants.UPDATE_PLAYERBETS_SPIN, new { Id = playerBetId, Spin = spin });
        }
        #endregion

        #region Constructors
        public PlayerBetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

    }
}
