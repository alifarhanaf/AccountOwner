using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerWebAPI.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PropertyController(ILoggerManager logger, IRepositoryWrapper repository , IMapper mapper )
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProperties()
        {
            try
            {
                var properties = _repository.Property.GetAllProperties();
                _logger.LogInfo($"Returned All Properties");
                return Ok(properties);
            }
            catch
            {
                _logger.LogError($"Something Went Wrong inside");
                return StatusCode(500, "Internal Server Error");

            }
        }

        [HttpGet("{id}", Name = "PropertyById")]
        public IActionResult GetPropertyById(Guid id) 
        {
            try
            {
                var property = _repository.Property.GetPropertyById(id); 
                if (property == null)
                {
                    _logger.LogError($"Property with id {id}, hasn't been found in db."); 
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Property with id: {id}");
                    var propertyResult = _mapper.Map<PropertyDto>(property); 
                    return Ok(propertyResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProperty([FromBody]PropertyForCreateDto property)
        {

            try
            {
                if (property == null)
                {
                    _logger.LogError($"Property object sent from client is null");
                    return BadRequest("Property object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid property object sent from client");
                    return BadRequest("Invalid property object");
                }

            
                var propertyEntity = _mapper.Map<Property>(property);

                _repository.Property.CreateProperty(propertyEntity);
                _repository.Save();

                var createdProperty = _mapper.Map<PropertyDto>(propertyEntity); 

                return CreatedAtRoute("PropertyById", new { id = createdProperty.Id }, createdProperty);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wring inside CreateAccount action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProperty(Guid id, [FromBody]PropertyForUpdateDto property)
        {
            try
            {
                if (property == null)
                {
                    _logger.LogError("property object sent from client is null.");
                    return BadRequest("property object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("invalid property object sent from client.");
                    return BadRequest("invalid model object");
                }

                var propertyEntity = _repository.Property.GetPropertyById(id);
                if (propertyEntity == null)
                {
                    _logger.LogError($"property with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(property, propertyEntity);

                _repository.Property.UpdateProperty(propertyEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"something went wrong inside updateproperty action: {ex.Message}");
                return StatusCode(500, "internal server error");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(Guid id)
        {
            try
            {
                var property = _repository.Property.GetPropertyById(id);
                if (property == null)
                {
                    _logger.LogError($"Property with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                //if (_repository.Account.AccountsByOwner(id).Any())
                //{
                //    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                //    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                //}
                _repository.Property.DeleteProperty(property);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}