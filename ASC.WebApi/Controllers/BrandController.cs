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
    [RoutePrefix("Brand")]
    public class BrandController : ApiController
    {
        private readonly IBrandManager _brandManager;
        public BrandController(IBrandManager brandManager)
        {
            _brandManager = brandManager; 
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var response = _brandManager.GetBrands();
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
            var response = _brandManager.GetBrand(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Brand brand)
        {
            string response = _brandManager.CreateBrand(brand);
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
        public IHttpActionResult Edit(Brand brand)
        {
            string response = _brandManager.EditBrand(brand);
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
            string response = _brandManager.DeleteBrand(id);
            if (response != "deleted")
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
