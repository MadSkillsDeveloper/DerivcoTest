namespace Derivco.Roullete.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task AddPlayerAsync(Player player);
    }
}
