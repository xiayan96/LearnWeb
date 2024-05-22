using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.Entites.Dtos
{
    public class PlayerWithCharactersDto :PlayerDto
    {
        public IEnumerable<CharacterDto> Characters { get; set; }
    }
}
