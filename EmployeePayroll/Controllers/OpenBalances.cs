using System;
using System.Threading.Tasks;
using AutoMapper;
using EmployeePayroll.Model;
using EmployeePayroll.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeePayroll.Controllers
{
    [ApiController]
    [Route("api/employee/{id}/balances/{balanceId}")]
    public class OpenBalances : ControllerBase
    {
        private readonly IData db;
        private readonly IMapper mapper;
        private readonly IOpenBalance open;
        public OpenBalances(IMapper mapper,IOpenBalance open, IData db)
        {
            this.open = open ?? throw new NullReferenceException(nameof(open));
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));


        }
        [HttpPut(Name = "Balances")]
        public async Task<ActionResult<OpenDto>> Put(Guid id, OpenUpdate openUpdate,Guid balanceId)
        {
            var query = await db.GetEmployee(id);
            if (query == null)
            {
                return NotFound();
            }
            var newbalance = mapper.Map<Entities.OpenBalances>(openUpdate);
            await open.Update(newbalance, balanceId);
            await db.Save();
            return Ok(query);
        }
    }
}
