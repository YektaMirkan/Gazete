using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Gazete.Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DatabaseDataContext database = new DatabaseDataContext();

        public abstract List<T> Items { get; }
        public abstract T Add(T item);
        public abstract void Remove(T item);
        //public abstract T Update(T item);
        public abstract T Select(int id);

        public bool HasChanges => database.GetChangeSet().Updates.Any();
        public void SaveChanges() => database.SubmitChanges();
        public void UndoChanges(List<T> list)
            => list.ForEach(item => database.Refresh(RefreshMode.OverwriteCurrentValues, item));
    }
}
