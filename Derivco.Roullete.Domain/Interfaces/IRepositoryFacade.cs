namespace Derivco.Roullete.Domain.Interfaces
{
    public interface IRepositoryFacade
    {
        IPlayerRepository PlayerRepository { get; }
        IPlayerBetRepository PlayerBetRepository { get; }
        IBetRepository BetRepository { get; }
    }
}
