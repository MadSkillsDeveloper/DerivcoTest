using Derivco.Roulette.Api.DTO;
using Derivco.Roulette.Api.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Derivco.Roulette.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PlayerController : ControllerBase
    {
        #region Fields
        private readonly IValidator<PlayerBetRequest> _playerBetRequestValidator;
        private readonly IPlayerService _playerService;
        #endregion

        #region Properties
        #endregion

        #region Methods
        [HttpPost]
        [Route("placebet")]
        public async Task<IActionResult> PlaceBet(PlayerBetRequest playerBetRequest)
        {
            ValidationResult validationResult =
                _playerBetRequestValidator.Validate(playerBetRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult
                    .Errors
                    .Select(x => new
                    {
                        property = x.PropertyName,
                        message = x.ErrorMessage
                    })
                    .ToList();

                return BadRequest(errors);
            }

            await _playerService.PlaceBetAsync(playerBetRequest);

            return Ok();
        }
        #endregion

        #region Constructors
        public PlayerController(
            IPlayerService playerService,
            IValidator<PlayerBetRequest> playerBetRequestValidator)
        {
            _playerBetRequestValidator = playerBetRequestValidator;
            _playerService = playerService;
        }
        #endregion
    }
}
