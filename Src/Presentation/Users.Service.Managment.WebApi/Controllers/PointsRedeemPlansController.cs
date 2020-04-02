using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Delete;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update;

namespace Users.Service.Managment.WebApi.Controllers
{
    public class PointsRedeemPlansController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePointsRedeemPlanCommand command)
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
        public async Task<IActionResult> Update([FromBody]UpdatePointsRedeemPlanCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePointsRedeemPlanCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}