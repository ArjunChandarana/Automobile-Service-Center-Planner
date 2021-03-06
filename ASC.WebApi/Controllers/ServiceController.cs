using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASC.WebApi.Controllers
{
    [RoutePrefix("Service")]
    public class ServiceController : ApiController
    {
        private readonly IServiceManager _serviceManager;
        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var response = _serviceManager.GetServices();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var response = _serviceManager.GetService(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Service service)
        {
            string response = _serviceManager.CreateService(service);
            if (response == "already")
            {
                return Conflict();
            }
            else if (response != "created")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public IHttpActionResult Edit(Service service)
        {
            string response = _serviceManager.EditService(service);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            string response = _serviceManager.DeleteService(id);
            if (response != "deleted")
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
