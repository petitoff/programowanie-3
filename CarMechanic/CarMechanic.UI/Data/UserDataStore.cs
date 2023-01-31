using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanic.UI.Data
{
    public class UserDataStore : IUserDataStore
    {
        public int CurrentUserId { get; set; }

        public UserDataStore()
        {
            // dev
            CurrentUserId = 1;
           
            // prod
        }
    }
}
