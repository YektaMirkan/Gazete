using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class MasaRepository : BaseRepository<Masa>
    {
        public override List<Masa> Items => database.Masa.ToList();

        public override Masa Add(Masa item)
        {
            database.Masa.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(Masa item)
        {
            database.Masa.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override Masa Select(int id) => Items.Single(x => x.Kod == id);
    }
}
