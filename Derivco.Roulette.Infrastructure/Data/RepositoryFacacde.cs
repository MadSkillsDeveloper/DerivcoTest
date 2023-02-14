using Derivco.Roulette.Infrastructure.Data.Repository;
using Derivco.Roullete.Domain.Interfaces;

namespace Derivco.Roulette.Infrastructure.Data
{
    public class RepositoryFacacde : IRepositoryFacade
    {
        #region Fields
        private readonly string _connectionString;

        private IPlayerRepository _playerRepository;
        private IPlayerBetRepository _playerBetRepository;
        private IBetRepository _betRepository;
        #endregion

        #region Properties
        public IPlayerRepository PlayerRepository
        {
            get
            {
                return _playerRepository ??= new PlayerRepository(_connectionString);
            }
        }

        public IPlayerBetRepository PlayerBetRepository
        {
            get
            {
                return _playerBetRepository ??= new PlayerBetRepository(_connectionString);
            }
        }

        public IBetRepository BetRepository
        {
            get
            {
                return _betRepository ??= new BetRepository(_connectionString); ;
            }
        }
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public RepositoryFacacde(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

    }
}
