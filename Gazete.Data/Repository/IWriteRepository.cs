using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazete.Data.Repository
{
    public interface IWriteRepository : IDisposable
    {
        TItem Update<TItem>(TItem item, bool saveImmediately = true) where TItem : class, new();
        TItem Insert<TItem>(TItem item, bool saveImmediately = true) where TItem : class, new();
        void Save();
    }
}
