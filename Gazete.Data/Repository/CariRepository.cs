using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class CariRepository : BaseRepository<CariOdeme>
    {
        public override List<CariOdeme> Items => database.CariOdeme.ToList();

        public override CariOdeme Add(CariOdeme item)
        {
            database.CariOdeme.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(CariOdeme item)
        {
            database.CariOdeme.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override CariOdeme Select(int id) => Items.Single(x => x.Kod == id);
    }
}
