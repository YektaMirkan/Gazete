using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class MasaTipiRepository : BaseRepository<MasaTipi>
    {
        public override List<MasaTipi> Items => database.MasaTipi.ToList();

        public override MasaTipi Add(MasaTipi item)
        {
            database.MasaTipi.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(MasaTipi item)
        {
            database.MasaTipi.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override MasaTipi Select(int id) => Items.Single(x => x.Kod == id);
    }
}
