using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gazete.Utilities
{
    public static class Extentions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var observableList = new ObservableCollection<T>();
            foreach (var e in coll)
                observableList.Add(e);
            return observableList;
        }
    }
}
