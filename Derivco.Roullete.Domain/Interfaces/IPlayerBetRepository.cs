namespace Derivco.Roullete.Domain.Interfaces
{
    public interface IPlayerBetRepository
    {
        Task AddPlayerBetAysnc(PlayerBet playerBet);
        Task<IList<PlayerBet>> GetPlayerBetListAsync();
        Task UpdatePlayerBetAsync(Guid playerBetId, int spin);
    }
}
