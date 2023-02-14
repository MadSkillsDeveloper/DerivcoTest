using System;

namespace Derivco.Roulette.Api.DTO
{
    public class PlayerBetRequest
    {
        #region Fields
        #endregion

        #region Properties
        public Guid PlayerId { get; set; }
        public Guid BetId { get; set; }
        public int? Spin { get; set; }
        public DateTime Timestamp { get; set; }
        #endregion

        #region Methods
        #endregion

        #region Constructors
        #endregion
    }
}
