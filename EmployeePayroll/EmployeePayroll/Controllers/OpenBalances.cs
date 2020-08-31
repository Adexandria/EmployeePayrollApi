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
    [Route("api/employee/{id}/balances")]
    public class OpenBalances : ControllerBase
    {
        private readonly IData db;
        private readonly IMapper mapper;
        private readonly IOpenBalance open1;
        public OpenBalances(IMapper mapper, IPropertyMappingService propertyMapping, IOpenBalance open1, IData db)
        {
            this.open1 = open1 ?? throw new NullReferenceException(nameof(open1));
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));


        }
        [HttpPut(Name = "Balances")]
        public async Task<ActionResult<OpenDto>> Put(Guid id, OpenUpdate open)
        {
            var query = await db.GetEmployee(id);
            if (query == null)
            {
                return NotFound();
            }
            var newbalance = mapper.Map<Entities.OpenBalances>(open);
            open1.Update(newbalance);
            open1.Save();
            query.OpenBalances = newbalance;
            db.Update(query);
            await db.Save();
            return Ok(query);
        }
    }
}
