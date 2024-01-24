using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CharactersController : ApiController
    {
     
            static readonly ICharactersRepository repository = new CharactersRepository();

            public IEnumerable<Characters> GetAllCharacters()
            {
                return repository.GetAll();
            }

            public Characters GetCharacters(int id)
            {
            Characters item = repository.Get(id);
                if (item == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                return item;
            }

        public HttpResponseMessage PostClient(Characters item)
            {
                item = repository.Add(item);
                var response = Request.CreateResponse<Characters>(HttpStatusCode.Created, item);

                string uri = Url.Link("DefaultApi", new { id = item.ID_characters });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            public void PutChar(int id, Characters Characters)
            {
                Characters.ID_characters = id;
                if (!repository.Update(Characters))
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

