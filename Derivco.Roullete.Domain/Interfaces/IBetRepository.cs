namespace Derivco.Roullete.Domain.Interfaces
{
    public interface IBetRepository
    {
        Task<IList<Bet>> GetBetsAsync();
    }
}
