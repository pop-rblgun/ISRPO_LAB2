using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    interface IItemsRepository
    {
        IEnumerable<Items> GetAll();
        Items Get(int id);
        Items Add(Items item);
        void Remove(int id);
        bool Update(Items item);
    }

}