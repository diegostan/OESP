using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OESP.Domain.Commands;
using OESP.Domain.Entities.ApplicationContext;
using OESP.Domain.Handlers;
using OESP.Domain.Respositories;


namespace OESP.API.Controllers
{
    [Route("v1/application/")]
    public class OESPController : ControllerBase
    {
       
       

        [AllowAnonymous]
        [Route("")]
        [HttpPost]
        public CommandResult CreateApplication([FromServices]CreateApplicationHandler handler
        ,[FromBody]CreateApplicationCommand command)
        {
            return (CommandResult)handler.Handle(command);
        }

        [AllowAnonymous]
        [Route("")]
        [HttpPut]
        public CommandResult UpdateApplicationEvent([FromServices]UpdateApplicationStateHandler handler
       , [FromBody] UpdateApplicationStateCommand command)
        {
            return (CommandResult)handler.Handle(command);
        }

        [AllowAnonymous]
        [Route("all")]
        [HttpGet]
        public Task<IEnumerable<ApplicationContext>> GetAllApplicationEvent(
            [FromServices]IApplicationRepository repository)
        {
            var res = repository.GetAllApplications();
            return res;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public Task<ApplicationContext> GetApplicationEventById(
            [FromServices] IApplicationRepository repository, int id)
        {
            var res = repository.GetApplicationById(id);
            return res;
        }
    }
}