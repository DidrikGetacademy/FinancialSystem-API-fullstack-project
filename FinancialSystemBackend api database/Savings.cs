using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinancialSystemBackend_api_database
{
    public class Savings
    {
        public string Title { get; set; }
        public string Description { get; set; }
        private int ProjectCount { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SavingsId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }




        public Savings(string title, string description)
        {
            Title = title;
            Description = description;
            ProjectCount = 0;
        }
    }
}




