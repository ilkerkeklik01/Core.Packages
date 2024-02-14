using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging;

public class Paginate<T>
{



    public Paginate()
    {
        Items = Array.Empty<T>();
        
    }

    public int Size { get; set; }  // # of elements in a page
    public int Index { get; set; } // Page index
    public int Count { get; set; } // # of elements
    public int Pages { get; set; } // # of pages
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index > 0;
    public bool HasNext => Index +1 < Pages;

}
