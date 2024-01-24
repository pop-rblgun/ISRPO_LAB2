using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ItemsRepository : IItemsRepository
    {
        private List<Items> items = new List<Items>();
        private int _nextId = 1;

        public ItemsRepository()
        {
    
        }
        public Items Add(Items item)
        {
            if (item == null)
                throw new ArgumentNullException();
            item.ID_item = _nextId++;
            items.Add(item);
            return item;
        }

        public Items Get(int id)
        {
            return items.Find(p => p.ID_item== id);
        }

        public IEnumerable<Items> GetAll()
        {
            return items;
        }

        public void Remove(int id)
        {
            items.RemoveAll(p => p.ID_item == id);
        }

        public bool Update(Items item)
        {
            if (item == null)
                throw new ArgumentNullException();
            int index = items.FindIndex(p => p.ID_item == item.ID_item);
            if (index == -1)
                return false;
            items.RemoveAt(index);
            items.Add(item);
            return true;
        }
    }
}