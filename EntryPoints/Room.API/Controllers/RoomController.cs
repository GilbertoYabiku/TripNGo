using System;
using System.Collections.Generic;
using Application.DTOs.Room;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Room.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<RoomDTO> GetById(Guid id)
        {
            var room = _service.Get(id);
            return Ok(room);
        }

        [HttpGet]
        public ActionResult<List<RoomDTO>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateRoomDTO createRoomDTO)
        {
            try
            {
                _service.Save(createRoomDTO);
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
        public ActionResult Put([FromBody] UpdateRoomDTO updateRoomDTO)
        {
            try
            {
                _service.Update(updateRoomDTO);
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
