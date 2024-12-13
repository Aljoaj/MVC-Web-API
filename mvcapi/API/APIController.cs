using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvcapi.API
{
    public class APIController : ApiController
    {
        mvcapiEntities db = new mvcapiEntities();
        // GET: api/API
        [HttpGet]
        [Route("api/API/getwebapitabs")]
        public IHttpActionResult Get()
        {
            return Ok(db.WebApiTabs.ToList());
        }

        // GET: api/API/5
        [HttpGet]
        [Route("api/API/getwebapitab/{id}")]
        public IHttpActionResult Get(int id)
        {
            WebApiTab employee = db.WebApiTabs.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/API
        [HttpPost]
        [Route("api/API/postwebapitab")]
        public IHttpActionResult Post(WebApiTab webApiTab)
        {
            if(ModelState.IsValid)
            {
                db.WebApiTabs.Add(webApiTab);
                db.SaveChanges();
            }
            return Ok(200);
        }

        // PUT: api/API/5
        [HttpPut]
        [Route("api/API/putwebapitab/{id}")]
        public IHttpActionResult Put(int id, WebApiTab webApiTab)
        {
            db.Entry(webApiTab).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/API/5
        [HttpDelete]
        [Route("api/API/deletewebapitab/{id}")]
        public IHttpActionResult Delete(int id)
        {
            WebApiTab webApiTab = db.WebApiTabs.Find(id);
            if(webApiTab==null)
            {
                return NotFound();
            }
            db.WebApiTabs.Remove(webApiTab);
            db.SaveChanges();
            return Ok(webApiTab);
        }
    }
}
