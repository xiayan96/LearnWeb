using LearnWeb.EntityFramework.Repositories;
using Sample.GameManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.EntityFramework
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GameManagementDbContext _gameManagementDbContext;
        private IPlayerRepository _player;
        private ICharacterRepository _character;

        public IPlayerRepository Player { get { return _player ??= new PlayerRepository(_gameManagementDbContext); } }

        public ICharacterRepository Character { get { return _character ??= new CharacterRepository(_gameManagementDbContext); } }

        public RepositoryWrapper(GameManagementDbContext gameDbContext)
        {
            _gameManagementDbContext = gameDbContext;
        }

        public Task<int> Save()
        {
            return _gameManagementDbContext.SaveChangesAsync();
        }
    }
}
