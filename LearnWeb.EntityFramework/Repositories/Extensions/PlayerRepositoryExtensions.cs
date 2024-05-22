using LearnWeb.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.EntityFramework.Repositories.Extensions
{
    public static class PlayerRepositoryExtensions
    {
        public static IQueryable<Player> SearchByAccount(this IQueryable<Player> players,string account)
        {
            if (string.IsNullOrWhiteSpace(account))
            {
                return players;
            }

            return players.Where(o => o.Account.ToLower().Contains(account.Trim().ToLower()));
        }
    }
}
