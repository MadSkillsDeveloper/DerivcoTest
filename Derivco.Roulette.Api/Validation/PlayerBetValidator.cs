using Derivco.Roulette.Api.DTO;
using FluentValidation;

namespace Derivco.Roulette.Api.Validation
{
    public class PlayerBetValidator : AbstractValidator<PlayerBetRequest>
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public PlayerBetValidator()
        {
            RuleFor(x => x.Timestamp).NotEmpty();
            RuleFor(x => x.PlayerId).NotEmpty();
            RuleFor(x => x.BetId).NotEmpty();
        }
        #endregion
    }
}
