using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CarTrack_OMdbWebAPI.Helpers;
using CarTrack_OMdbWebAPI.Utilities;
using CarTrack_OMdbWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarTrack_OMdbWebAPI.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class OMdb_AccessController : ControllerBase
    {
        private readonly MetaData _metaData;
        private readonly DatabaseContext _databaseContext;
        private readonly IOmdbService _omdbService;
        private readonly IMemoryCache memoryCache;

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
            AddCachedItem(result);
            return result;
        }
        [HttpGet("OMdb_Access/GetItemByTitle")]
        public ActionResult<Item> GetItemByTitle(string title)
        {
            var result = _omdbService.GetItemByTitle(title);
            AddCachedItem(result);
            return result;
        }
        [HttpGet("OMdb_Access/GetItemByTitleAndYear")]
        public ActionResult<Item> GetItemByTitleAndYear(string title, int year)
        {
            var result = _omdbService.GetItemByTitle(title, year);
            AddCachedItem(result);
            return result;
        }
    }
}
