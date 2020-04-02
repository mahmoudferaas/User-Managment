
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Common.Interfaces
{
    public interface IMarkupPlanES
    {
        Task<List<MarkupPlan>> GetMarkupPlan(string query);
    }
}
