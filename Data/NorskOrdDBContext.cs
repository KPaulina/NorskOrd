using _NorskOrd_.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_.Data
{
    
    public class NorskOrdDBContext : DbContext
    {
        public NorskOrdDBContext(DbContextOptions option) : base(option)
        {

        }

        //private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=NorskOrd;Trusted_Connection=True";
        public DbSet<Words> Words { get; set; }
        public DbSet<Player> Player { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }*/
    }

    

}
