using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class GiderRepository : BaseRepository<Gider>
    {
        public override List<Gider> Items => database.Gider.ToList();

        public override Gider Add(Gider item)
        {
            database.Gider.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(Gider item)
        {
            database.Gider.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override Gider Select(int id) => Items.Single(x => x.Kod == id);
    }
}
