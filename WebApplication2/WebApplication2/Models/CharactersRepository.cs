using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CharactersRepository : ICharactersRepository
    {
        private List<Characters> characters = new List<Characters>();
        private int _nextId = 1;

        public CharactersRepository()
        {
        
        }
        public Characters Add(Characters item)
        {
            if (item == null)
                throw new ArgumentNullException();
            item.ID_characters = _nextId++;
            characters.Add(item);
            return item;
        }

        public Characters Get(int id)
        {
            return characters.Find(p => p.ID_characters == id);
        }

        public IEnumerable<Characters> GetAll()
        {
            return characters;
        }

        public void Remove(int id)
        {
            characters.RemoveAll(p => p.ID_characters == id);
        }

        public bool Update(Characters item)
        {
            if (item == null)
                throw new ArgumentNullException();
            int index = characters.FindIndex(p => p.ID_characters == item.ID_characters);
            if (index == -1)
                return false;
            characters.RemoveAt(index);
            characters.Add(item);
            return true;
        }
    }

}