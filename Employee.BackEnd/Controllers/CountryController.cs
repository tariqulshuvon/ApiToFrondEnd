using Employee.Core.CQRS.Employee.Command;
using Employee.Core.CQRS.Employee.Query;
using Employee.Infrastructure.Persistence;
using Employee.Model;
using Employee.Service.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.BackEnd.Controllers;

public class CountryController : APIControllerBase
{

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VMEmployee>> GetById(int id)
    {
        return await HandleQueryAsync(new GetAllCountryByIdQuery(id));
    }
    [HttpGet]
    public async Task<ActionResult<VMCountry>> GetAllCountry()
    {
        return await HandleQueryAsync(new GetAllCountryQuery());
    }
    [HttpPost]

    public async Task<ActionResult<VMCountry>> CreateCountry(VMCountry command)
    {
        return await HandleCommandAsync(new CreateCountryCommand(command));
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult<VMCountry>> UpdateCountry(int id, VMCountry country)
    {
        return await HandleCommandAsync(new UpdateCountryCommand(id, country));
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VMCountry>> DeleteCountry(int id)
    {
        return await HandleCommandAsync(new DeleteCountryCommand(id));
    }

}
