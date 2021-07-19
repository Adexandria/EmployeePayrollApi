using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using EmployeePayroll.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using EmployeePayroll.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeePayroll.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class Employee : Controller
    {
        private readonly IData data;
        readonly I
        private readonly IMapper mapper;
        private readonly IPropertyMappingService propertyMapping;

        public Employee(IData data, IMapper mapper, IPropertyMappingService propertyMapping)
        {
            this.data = data ?? throw new NullReferenceException(nameof(data));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
            this.propertyMapping = propertyMapping ?? throw new NullReferenceException(nameof(propertyMapping));


        }
        // GET: /<controller>/
        [HttpGet(Name = "Employees")]
        [HttpHead]
        public IActionResult GetEmployees(PageSizes sizes)
        {

            var employees = data.Employees(sizes);
            var pagingMeta = new
            {
                totalCount = employees.TotalCount,
                totalPage = employees.TotalPage,
                currentPage = employees.CurrentPage,
                pageSize = employees.PageSize
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagingMeta));
            var link = CreateEmployeesLink(sizes, employees.HasNext, employees.Hasprevious);
            var addedLink = mapper.Map<IEnumerable<EmployeesDto>>(employees).ShapeData(sizes.Fields) as IDictionary<string,object>;
              var addlink = addedLink.Select(a =>
            {
                var studentasdictionary = a.ShapeData(sizes.Fields) as IDictionary<string, object>;
                var studentLinks = CreateEmployeeLink((Guid)studentasdictionary["EmployeeId"], null);
                studentasdictionary.Add("links", studentLinks);
                return studentasdictionary;
            });
            var linkCollection = new
            {
                value = addlink,
                link
            };

            return Ok(addedLink);

        }
        [HttpGet("{id}", Name = "Employee")]
        public async Task<ActionResult<EmployeeDto>> GetById(Guid id, string fields)
        {
            var employee = await data.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
          
            var newemployee = mapper.Map<EmployeeDto>(employee).ShapeData(fields) as IDictionary<string, object>;
            return Ok(newemployee);

        }
        [HttpPost]
        public async Task<ActionResult<EmployeesDto>> Post(EmployeeCreation employee)
        {
            var person = mapper.Map<Entities.Employee>(employee);
            await data.Add(person);
            await data.Save();
            var link = CreateEmployeeLink(person.EmployeeId, null);
            var newemployee = mapper.Map<EmployeesDto>(person).ShapeData(null) as IDictionary<string, object>;
            newemployee.Add("links", link);
            return Created("Created", newemployee);
        }
        [HttpPatch("{id}",Name ="Patch")]
        public async Task<ActionResult> Patch(Guid id,JsonPatchDocument<EmployeeCreation> patchDocument)
        {
            var query = await data.GetEmployee(id);
            if (query == null)
            {
                var newemployee = new EmployeeCreation();
                patchDocument.ApplyTo(newemployee);
                if (!TryValidateModel(newemployee))
                {
                    return ValidationProblem(ModelState);
                }
                var employeeToAdd = mapper.Map<Entities.Employee>(newemployee);
                await data.Add(employeeToAdd);
                await data.Save();
                var link = CreateEmployeeLink(employeeToAdd.EmployeeId, null);
                var employeeToReturn = mapper.Map<EmployeesDto>(employeeToAdd).ShapeData(null) as IDictionary<string, object>;
                employeeToReturn.Add("links", link);
                return Created("Created",employeeToReturn);
            }
            var employeeToPatch = mapper.Map<EmployeeCreation>(query);
            patchDocument.ApplyTo(employeeToPatch);
            if (!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(employeeToPatch, query);
            data.Update(query);
            await data.Save();
            return NoContent();
        }
         
       [HttpDelete("{id}",Name = "DeleteEmployee")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var employee = await data.GetEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }
            await data.Delete(id);
            await data.Save();
            return Ok();
        }
        public override ActionResult ValidationProblem(
         [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }

        private string CreateEmployeeUrl(PageSizes sizes, ResourceUriType type)
        {

            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("Employees",
                      new
                      {
                          fields = sizes.Fields,
                          pageNumber = sizes.PageNumber - 1,
                          pageSize = sizes.PageSize
                      });
                case ResourceUriType.Nextpage:
                    return Url.Link("Employees",
                      new
                      {
                          fields = sizes.Fields,
                          pageNumber = sizes.PageNumber + 1,
                          pageSize = sizes.PageSize
                      });
                case ResourceUriType.Current:
                default:
                    return Url.Link("Employees",
                    new
                    {
                        fields = sizes.Fields,
                        pageNumber = sizes.PageNumber,
                        pageSize = sizes.PageSize

                    });
            }
           
        }
        public IEnumerable<LinkDto> CreateEmployeeLink(Guid id, string fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                  new LinkDto(Url.Link("Employee", new { id }),
                  "self",
                  "GET"));
            }
            else
            {
                links.Add(
                  new LinkDto(Url.Link("Employee", new { id, fields }),
                  "self",
                  "GET"));
            }
            links.Add(
               new LinkDto(Url.Link("Bank", new { id }),
               "Update_bank",
               "PUT"));
            links.Add(
               new LinkDto(Url.Link("Patch", new { id }),
               "patch_employee",
               "PATCH"));
            links.Add(
               new LinkDto(Url.Link("Balances", new { id }),
               "Update_balances",
               "PUT"));
            links.Add(
               new LinkDto(Url.Link("Address", new { id }),
               "Update_address",
               "PUT"));
            links.Add(
               new LinkDto(Url.Link("Templates", new { id }),
               "Update_payTemplates",
               "PUT"));
            links.Add(
               new LinkDto(Url.Link("DeleteEmployee", new { id }),
               "delete_employee",
               "DELETE"));
            return links;

        }
        private IEnumerable<LinkDto> CreateEmployeesLink(PageSizes sizes,bool hasNext,bool hasPrevious)
            {
            var links = new List<LinkDto>();

            links.Add(new LinkDto(CreateEmployeeUrl(sizes, ResourceUriType.Current), "self", "GET"));
            
            if (hasNext)
            {
                links.Add(new LinkDto(CreateEmployeeUrl(sizes, ResourceUriType.Nextpage), "Nextpage", "GET"));
            }
            if(hasPrevious)
            {
                links.Add(new LinkDto(CreateEmployeeUrl(sizes, ResourceUriType.PreviousPage), "Previouspage", "GET"));
            }
            return links;
            }
    }
}
