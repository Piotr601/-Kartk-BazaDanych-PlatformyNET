using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BazaDanych
{
    public class Gra
    {
        public int id { set; get; }
        public string gatunek { set; get; }
        public string nazwa { set; get; }
    }

    public class Gra_DB:DbContext
    {
        public DbSet<Gra> Gry { set; get; }
    }

}
