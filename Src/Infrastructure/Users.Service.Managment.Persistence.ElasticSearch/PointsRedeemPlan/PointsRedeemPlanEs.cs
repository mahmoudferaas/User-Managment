using BaseClasses.Configurations.Manager.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Persistence.ElasticSearch.Common;

namespace Users.Service.Managment.Persistence.ElasticSearch.PointsRedeemPlan

{
    public class PointsRedeemPlanEs : BaseEs, IPointRedeemPlanES
    {
        public PointsRedeemPlanEs(IConfigurationManager configurationManager) : base(configurationManager)
        {
        }

        public async Task<List<Domain.Entities.PointsRedeemPlan>> GetPointRedeemPlan(string query)
        {
            var nestString = query.Replace('\"', '"');

            var indexName = IndicesNames.PointsRedeemPlans;

            var esResponse = await ElasticClient.SearchAsync<Domain.Entities.PointsRedeemPlan>(
                                a => a.Query(q => q.Raw(nestString)).Index(indexName).Size(500));

            var pointsRedeemPlanEs = esResponse.Documents.ToList();

            return pointsRedeemPlanEs;
        }
    }
}