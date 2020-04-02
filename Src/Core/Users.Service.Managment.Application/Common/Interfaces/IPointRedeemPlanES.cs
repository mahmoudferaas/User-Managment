using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Common.Interfaces
{
    public interface IPointRedeemPlanES
    {
        Task<List<PointsRedeemPlan>> GetPointRedeemPlan(string query);
    }
}