using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class OdemeTipiRepository : BaseRepository<OdemeTipi>
    {
        public override List<OdemeTipi> Items => database.OdemeTipi.ToList();

        public override OdemeTipi Add(OdemeTipi item)
        {
            database.OdemeTipi.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(OdemeTipi item)
        {
            database.OdemeTipi.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override OdemeTipi Select(int id) => Items.Single(x => x.Kod == id); 
    }
}
