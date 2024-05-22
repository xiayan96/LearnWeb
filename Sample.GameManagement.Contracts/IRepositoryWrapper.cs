using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.GameManagement.Contracts
{
    public interface IRepositoryWrapper
    {
        IPlayerRepository Player { get; }
        ICharacterRepository Character { get; }
        Task<int> Save();
    }
}
