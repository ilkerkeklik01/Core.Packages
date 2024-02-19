using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging;

public abstract class BasePageableModel
{
    public int Size { get; set; }  // # of elements in a page
    public int Index { get; set; } // Page index
    public int Count { get; set; } // # of elements
    public int Pages { get; set; } // # of pages

    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}

