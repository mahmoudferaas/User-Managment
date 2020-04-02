using BaseClasses.Loggers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Users.Service.Managment.Application.MarkupPlans.Commands.Create;
using Users.Service.Managment.Application.MarkupPlans.Commands.Delete;
using Users.Service.Managment.Application.MarkupPlans.Commands.Update;

namespace Users.Service.Managment.WebApi.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MarkupPlansController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateMarkupPlanCommand command)
        {
            try
            {
                var id = await Mediator.Send(command);
                return Ok(id);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]UpdateMarkupPlanCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete, BuildUserInformation]
        public async Task<IActionResult> Delete(DeleteMarkupPlanCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}