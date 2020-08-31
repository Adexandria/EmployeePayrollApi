using AutoMapper;
using EmployeePayroll.Model;
using EmployeePayroll.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Controllers
{
    [ApiController]
    [Route("api/employee/{id}/address")]
    public class Address:ControllerBase
    {
        private readonly IData db;
        private readonly IMapper mapper;
       
        public Address( IMapper mapper, IPropertyMappingService propertyMapping,IData db)
        {
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
           

        }
        [HttpPut(Name ="Address")]
        public async Task<ActionResult<Entities.Employee>> Put(Guid id,AddressCreation address)
        {
            var query = await db.GetEmployee(id);
            if( query == null)
            {
                return NotFound();
            }
            var newAddress = mapper.Map<Entities.Address>(address);
            query.HomeAddress = newAddress;
            db.Update(query);
            await db.Save();
            return Ok();
        }
    }
}
