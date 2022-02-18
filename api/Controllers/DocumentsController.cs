using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Document>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Document>> Get()
        {
            var documents = _documentsContext.Documents.AsEnumerable();

            if (documents == null)
                return NotFound("No documents found.");

            return Ok(documents);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Document))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Document> Get(int id)
        {
            var document = _documentsContext.Documents.FirstOrDefault(documentId => documentId.Id == id);

            if (document == null)
                return NotFound(new String($"Document Id: {id} was not found"));

            return Ok(document);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type=typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(string))]
        public ActionResult Post([FromBody] Document document)
        {
            if (document == null)
                return BadRequest("Missing document entity");

            if (document.Id != 0)
                return UnprocessableEntity("Document Id must be zero");

            try
            {
                _documentsContext.Documents.Add(document);
                _documentsContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type=typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        public ActionResult Put(int id, [FromBody] Document document)
        {
            if (document == null)
                return BadRequest("Missing document entity");

            if (document.Id == 0)
                return UnprocessableEntity("Document Id must not be zero");

            if (document.Id != id)
                return BadRequest("Document Id must be equals to parameter Id");


            var _documentCheck = _documentsContext.Documents.Any(document => document.Id == id);
            if (!_documentCheck)
                return NotFound($"Document not found id = {id}");

            try
            {
                //do de changes
                _documentsContext.Documents.Update(document);
                _documentsContext.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult Delete(int id)
        {
            var _document = _documentsContext.Documents.FirstOrDefault(document => document.Id == id);
            if (_document == null)
                return NotFound($"Document Id = {id} not found.");

            try
            {
                _documentsContext.Documents.Remove(_document);
                _documentsContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
