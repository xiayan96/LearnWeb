using LearnWeb.Entites;
using LearnWeb.Entites.ReponseType;
using LearnWeb.Entites.RequestFeatures;
using LearnWeb.EntityFramework.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using Sample.GameManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LearnWeb.EntityFramework.Repositories
{
    internal class PlayerRepository :RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(GameManagementDbContext repositoryContext) :base(repositoryContext) { 
        }

        public PagedList<Player> GetPlayers(PlayerParameter parameter)
        {
            return FindByCondition(player => player.DateCreated.Date >= parameter.MinDateCreated.Date && 
                                             player.DateCreated.Date <= parameter.MaxDateCreated.Date)
                .SearchByAccount(parameter.Account)
                .OrderBy(x => x.DateCreated.Date)
                .ToPagedList(parameter.PageNumber,parameter.PageSize);
               
        }

        public async Task<Player?> GetPlayerById(Guid playerId)
        {
           return await FindByCondition(player=>player.Id == playerId).FirstOrDefaultAsync();
        }

        public async Task<Player?> GetPlayerWithCharacters(Guid playerId)
        {
            return await FindByCondition(player => player.Id == playerId)
                .Include(x => x.Characters)
                .FirstOrDefaultAsync();
        }

        //void IPlayerRepository.CreatePlayer(Player player)
        //{
        //    Create(player);
        //}
    }
}
