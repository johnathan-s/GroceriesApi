using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace GroceriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentIdController : ControllerBase
    {
        public DocumentIdController(ILogger<DocumentIdController> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<DocumentIdController> _logger;

        // GET: api/DocumentId
        [HttpGet]
        public DocumentId Get()
        {
            string documentId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 23);// mongodb id is 24 chars in length
            return new DocumentId
            {
                id = documentId
            };
        }
    }

    public class DocumentId
    {
       public string id { get; set; }
    }
}
