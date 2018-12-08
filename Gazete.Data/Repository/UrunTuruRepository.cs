using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class UrunTuruRepository : BaseRepository<UrunTuru>
    {
        public override List<UrunTuru> Items => database.UrunTuru.ToList();

        public override UrunTuru Add(UrunTuru item)
        {
            database.UrunTuru.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(UrunTuru item)
        {
            database.UrunTuru.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override UrunTuru Select(int id) => Items.Single(x => x.Kod == id);
    }
}
