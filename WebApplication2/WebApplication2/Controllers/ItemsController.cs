using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ItemsController : ApiController
    {

        static readonly IItemsRepository repository = new ItemsRepository();

        public IEnumerable<Items> GetAllItems()
        {
            return repository.GetAll();
        }

        public Items GetItems(int id)
        {
            Items item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostClient(Items item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Items>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.ID_item });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutChar(int id, Items Items)
        {
            Items.ID_item = id;
            if (!repository.Update(Items))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

    }
}

