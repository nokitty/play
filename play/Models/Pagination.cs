using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace play.Models
{
    public class Pagination<T>:BasePagedList<T>
    {
        public Pagination(IEnumerable<T> subset,int page,int size,int count):base(page,size,count)
        {
            Subset.AddRange(subset);
        }
    }
}