using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class AdisyonRepository : BaseRepository<Adisyon>
    {
        public override List<Adisyon> Items => database.Adisyon.ToList();

        public override Adisyon Add(Adisyon item)
        {
            database.Adisyon.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(Adisyon item)
        {
            database.Adisyon.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override Adisyon Select(int id) => Items.Single(x => x.Kod == id);
    }
}
