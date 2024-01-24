using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    interface ICharactersRepository
    {
        IEnumerable<Characters> GetAll();
        Characters Get(int id);
        Characters Add(Characters item);
        void Remove(int id);
        bool Update(Characters item);
    }

}