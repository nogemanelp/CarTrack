using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CarTrack_OMdbWebAPI.Controllers
{
    public class CachedEntriesController : ControllerBase
    {
        private readonly MetaData _metaData;
        private readonly DatabaseContext _databaseContext;
        private readonly IOmdbService _omdbService;
        private readonly IMemoryCache memoryCache;

        [System.Web.Http.Route("api/[controller]")]
        [ApiController]
        public OMdb_AccessController(DatabaseContext databaseContext)
        {
            _metaData = new MetaData();
            _databaseContext = databaseContext;
            _omdbService = new OmdbAPIService(_metaData.APIKey);
        }

        [HttpGet("OMdb_Access/GetItemByID")]
        public ActionResult<Item> GetItemByID(string id)
        {
            var result = _omdbService.GetItemById(id);
            return result;
        }

        [HttpDelete("{id}")]
        public void DeleteTodoItem(int id)
        {
            _omdbService.RemoveCachedItemByID(id);
        }

        [HttpPost]
        [EnableBodyRewind]
        public  void CreateTodoItem([FromBody]item model)
        {
            _omdbService.AddCachedItem(id);
        }

    }
}
