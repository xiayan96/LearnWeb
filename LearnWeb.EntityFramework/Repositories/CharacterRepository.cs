using LearnWeb.Entites;
using Sample.GameManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.EntityFramework.Repositories
{
    internal class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(GameManagementDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
