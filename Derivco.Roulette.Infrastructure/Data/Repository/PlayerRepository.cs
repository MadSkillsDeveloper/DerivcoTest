using Dapper;
using Derivco.Roulette.Infrastructure.Data.Scritps;
using Derivco.Roullete.Domain;
using Derivco.Roullete.Domain.Interfaces;
using System.Threading.Tasks;

namespace Derivco.Roulette.Infrastructure.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Properties
        #endregion

        #region Methods
        public async Task AddPlayerAsync(Player player)
        {
            using DataContext dataContext = new(_connectionString);
            dataContext.Connection.Open();
            await dataContext.Connection.ExecuteAsync(DMLConstants.INSERT_PLAYER, player);
        }
        #endregion

        #region Constructors
        public PlayerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion
    }
}
