using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeePayroll.Model;
using EmployeePayroll.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeePayroll.Controllers
{
    [ApiController]
    [Route("api/employee/{id}/bank")]
    public class Bank : Controller
    {
      
        private readonly IData db;
        private readonly IMapper mapper;
       

        public Bank( IMapper mapper, IPropertyMappingService propertyMapping, IData db)
        {
            
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
         

        }
        [HttpPut(Name ="Bank")]
        public async Task<ActionResult<Entities.Bank>> Put(Guid id,BankCreation bank)
        {
            var query = await db.GetEmployee(id);
            if (query == null)
            {
                return NotFound();
            }
            var newbank = mapper.Map<Entities.Bank>(bank);
            query.BankAccount = newbank;
            db.Update(query);
            await db.Save();
            return Ok();
        }
    }
}
