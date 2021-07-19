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
    [Route("api/employee/{id}/paytemplates/{templateId}")]
    public class PayTemplates : Controller
    {
      
        private readonly IData db;
        private readonly IMapper mapper; 
        private readonly ITemplates template;
        public PayTemplates(IMapper mapper, ITemplates template, IData db)
        {
            this.template = template ?? throw new NullReferenceException(nameof(template));
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));


        } 
        [HttpGet(Name = "Templates")]
        public async Task<ActionResult<Entities.PayTemplates>> GetTemplate(Guid id)
        {
            var query = await db.GetEmployee(id);
            if (query == null)
            {
                return NotFound();
            }
            var paytemplate = await template.GetPayTemplate(id);
            return Ok(paytemplate);
        }
        [HttpPut(Name = "Templates")]
        public async Task<ActionResult<Entities.PayTemplates>> UpdateTemplate(Guid id, TemplatesCreation tem,Guid templateId)
        {
            var query = await db.GetEmployee(id);
            if (query == null)
            {
                return NotFound();
            }
            var newTemplate = mapper.Map<Entities.PayTemplates>(tem);
            await template.Update(newTemplate,templateId);
            return Ok("Sucessfully updated");
        }
        [HttpPut(Name = "Templates/EarningsLine")]
        public async Task<ActionResult<Entities.EarningsLines>> UpdateEarningLine(Guid id, TemplatesCreation tem, Guid templateId)
        {
            var query = await db.GetEmployee(id);
            if (query == null)
            {
                return NotFound();
            }
            var newTemplate = mapper.Map<Entities.PayTemplates>(tem);
            await template.Update(newTemplate, templateId);
            return Ok("Sucessfully updated");
        }
    }
    
}
