using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        DocumentsContext _documentsContext;

        public DocumentsController(DocumentsContext _documentsContext)
        {
            this._documentsContext = _documentsContext;
        }
        // GET: api/<DocumentsController>
        [HttpGet]
        public IEnumerable<Document> Get()
        {
            return _documentsContext.Documents;
        }

        // GET api/<DocumentsController>/5
        [HttpGet("{id}")]
        public Document Get(int id)
        {
            return _documentsContext.Documents.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<DocumentsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<DocumentsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DocumentsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
