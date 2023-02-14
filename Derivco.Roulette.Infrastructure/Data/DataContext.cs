using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace Derivco.Roulette.Infrastructure.Data
{
    public class DataContext : IDisposable
    {

        #region Fields
        private bool disposedValue;
        private readonly IDbConnection _connection;
        #endregion

        #region Properties
        public IDbConnection Connection => _connection;
        #endregion

        #region Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Constructors
        public DataContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connection = new SqliteConnection(connectionString);
        }
        #endregion
    }
}
