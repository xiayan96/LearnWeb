using LearnWeb.Entites;
using LearnWeb.Entites.ReponseType;
using LearnWeb.Entites.RequestFeatures;

namespace Sample.GameManagement.Contracts
{
    public interface IPlayerRepository :IRepositoryBase<Player>
    {
        PagedList<Player> GetPlayers(PlayerParameter parameter);
        Task<Player?> GetPlayerById(Guid playerId);
        Task<Player?> GetPlayerWithCharacters(Guid playerId);

        //void CreatePlayer(Player player);
    }
}
