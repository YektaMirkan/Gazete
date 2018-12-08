using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class UrunRepository : BaseRepository<Urun>
    {
        public override List<Urun> Items => database.Urun.ToList();

        public override Urun Add(Urun item)
        {
            database.Urun.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(Urun item)
        {
            database.Urun.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override Urun Select(int id) => Items.Single(x => x.Kod == id);
    }
}
