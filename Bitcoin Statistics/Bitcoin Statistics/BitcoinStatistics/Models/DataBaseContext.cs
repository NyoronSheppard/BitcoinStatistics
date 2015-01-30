using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinStatistics.Models
{
    public class DataBaseContext : DataContext
    {
        public DataBaseContext(string connectionString):base(connectionString)
        {

        }

        public Table<TileUpdateDB> Tile;
    }
}
