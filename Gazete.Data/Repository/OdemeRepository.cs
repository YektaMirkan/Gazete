using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class OdemeRepository : BaseRepository<MusteriOdeme>
    {
        public override List<MusteriOdeme> Items => database.MusteriOdeme.ToList();

        public override MusteriOdeme Add(MusteriOdeme item)
        {
            database.MusteriOdeme.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(MusteriOdeme item)
        {
            database.MusteriOdeme.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override MusteriOdeme Select(int id) => Items.Single(x => x.Kod == id);
    }
}
