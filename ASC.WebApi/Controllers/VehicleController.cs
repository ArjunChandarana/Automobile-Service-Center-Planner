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
    [RoutePrefix("Vehicle")]
    public class VehicleController : ApiController
    {
        private readonly IVehicleManager _vehicleManager;
        public VehicleController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var response = _vehicleManager.GetVehicles();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetVehiclesOfUser/{userId}")]
        public IHttpActionResult GetVehiclesOfUser(string userId)
        {
            var response = _vehicleManager.GetVehiclesOfUser(userId);
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
            var response = _vehicleManager.GetVehicle(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Vehicle vehicle)
        {
            string response = _vehicleManager.CreateVehicle(vehicle);
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
        public IHttpActionResult Edit(Vehicle vehicle)
        {
            string response = _vehicleManager.EditVehicle(vehicle);
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
            string response = _vehicleManager.DeleteVehicle(id);
            if (response != "deleted")
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
