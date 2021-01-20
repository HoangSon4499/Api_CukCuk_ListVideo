using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Emuns;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entityById = _baseService.GetEntityById(id);
            return Ok(entityById);
        }

        [HttpPost]
        public IActionResult Post(TEntity entity)
        {

            var res = _baseService.Add(entity);
            return Ok(res);

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if (keyProperty.PropertyType== typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if ((keyProperty.PropertyType == typeof(int)))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity,id);
            }
            var res = _baseService.Update(entity);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = _baseService.Delete(id);
            return Ok(res);
        }
    }
}
