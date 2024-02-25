using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace FinancialSystemBackend_api_database
{
    public class User
    { 
      
        
        public bool IsOnline { get; set; }
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

      
        public List<Savings> UserSavingProjects { get; set; }

        public User()
        {
            UserSavingProjects = new List<Savings>();
        }

    }
}
