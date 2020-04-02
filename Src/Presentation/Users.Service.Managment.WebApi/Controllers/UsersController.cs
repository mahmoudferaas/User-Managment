using BaseClasses.Loggers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Users.Commands.Create;
using Users.Service.Managment.Application.Users.Commands.Delete;
using Users.Service.Managment.Application.Users.Commands.Update;

namespace Users.Service.Managment.WebApi.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : BaseController
    {
        [HttpPost]

        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }



        [HttpPost]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}