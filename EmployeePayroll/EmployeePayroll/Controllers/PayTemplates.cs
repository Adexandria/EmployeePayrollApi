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
    [Route("api/employee/{id}/paytemplates")]
    public class PayTemplates : Controller
    {
      
        private readonly IData db;
        private readonly IMapper mapper; 
        private readonly ITemplates templates;
        public PayTemplates(IMapper mapper, ITemplates templates, IData db)
        {
            this.templates = templates ?? throw new NullReferenceException(nameof(templates));
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));


        }
        [HttpPut(Name = "Templates")]
        public async Task<ActionResult<Entities.PayTemplates>> Put(Guid id, TemplatesCreation tem)
        {
            var query = await db.GetEmployee(id);
            if (query == null)
            {
                return NotFound();
            }
            var newTemplate = mapper.Map<Entities.PayTemplates>(tem);
           templates.Update(newTemplate);
            templates.Save(); 
            query.PayTemplates = newTemplate;
            db.Update(query);
            await db.Save();
            return Ok(query);
        }
    }
    
}
