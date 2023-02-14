using Dapper;
using Derivco.Roulette.Infrastructure.Data.Scritps;
using Derivco.Roullete.Domain;
using Derivco.Roullete.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.Roulette.Infrastructure.Data.Repository
{
    public class BetRepository : IBetRepository
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Properties
        #endregion

        #region Methods
        public async Task<IList<Bet>> GetBetsAsync()
        {
            using DataContext dataContext = new(_connectionString);
            dataContext.Connection.Open();
            return (IList<Bet>)await dataContext
                 .Connection
                 .QueryAsync<Bet>(DMLConstants.GET_ALL_BETS);
        }
        #endregion

        #region Constructors
        public BetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

    }
}
