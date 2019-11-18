using System;
using System.Collections.Generic;
using Application.DTOs.Hotel;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Room.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelController(IHotelService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<HotelDTO> GetById(Guid id)
        {
            var room = _service.Get(id);
            return Ok(room);
        }

        [HttpGet]
        public ActionResult<List<HotelDTO>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateHotelDTO createHotelDTO)
        {
            try
            {
                _service.Save(createHotelDTO);
                return Ok();
            }
            catch (Exception e)
            {
                string errors = e.Message;
                return ValidationProblem(new ValidationProblemDetails()
                {
                    Type = "Model Validation Error",
                    Detail = errors
                });
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UpdateHotelDTO updateHotelDTO)
        {
            try
            {
                _service.Update(updateHotelDTO);
                return Ok();
            }
            catch(Exception e)
            {
                string errors = e.Message;
                return ValidationProblem(new ValidationProblemDetails()
                {
                    Type = "Model Validation Error",
                    Detail = errors
                }); 
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                string errors = e.Message;
                return ValidationProblem(new ValidationProblemDetails()
                {
                    Type = "Cannot delete",
                    Detail = errors
                });
            }
        }
    }
}
