using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.Entites.RequestFeatures
{
    public class PlayerParameter : QueryStringParameters
    {
        public PlayerParameter()
        {
            orderBy = "account";
        }

        public DateTime MinDateCreated { get; set; }
        public DateTime MaxDateCreated { get; set; } = DateTime.Now;

        public bool ValidDateCreatedRange => MinDateCreated < MaxDateCreated;

        public string? Account {  get; set; }


    }
}
