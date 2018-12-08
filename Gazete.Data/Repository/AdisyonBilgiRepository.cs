using System.Collections.Generic;
using System.Linq;

namespace Gazete.Data.Repository
{
    public class AdisyonBilgiRepository : BaseRepository<AdisyonBilgi>
    {
        public override List<AdisyonBilgi> Items => database.AdisyonBilgi.ToList();

        public override AdisyonBilgi Add(AdisyonBilgi item)
        {
            database.AdisyonBilgi.InsertOnSubmit(item);
            SaveChanges();
            return item;
        }

        public override void Remove(AdisyonBilgi item)
        {
            database.AdisyonBilgi.DeleteOnSubmit(item);
            SaveChanges();
        }

        public override AdisyonBilgi Select(int id) => Items.Single(x => x.Kod == id);
    }
}
