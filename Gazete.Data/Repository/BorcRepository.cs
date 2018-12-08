using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class BorcRepository : BaseRepository<Borc>
    {
        public override List<Borc> Items => database.Borc.ToList();

        public override Borc Add(Borc item)
        {
            database.Borc.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(Borc item)
        {
            database.Borc.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override Borc Select(int id) => Items.Single(x => x.Kod == id);
    }
}
