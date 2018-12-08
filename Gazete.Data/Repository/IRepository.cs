using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazete.Data.Repository
{
    interface IRepository<T> where T : class
    {
        bool HasChanges { get; }
        List<T> Items { get; }

        T Add(T item);
        void Remove(T item);
        //T Update(T item);
        T Select(int id);
        void SaveChanges();
        void UndoChanges(List<T> list);
    }
}
