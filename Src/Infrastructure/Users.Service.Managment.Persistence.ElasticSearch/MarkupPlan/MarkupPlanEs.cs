using BaseClasses.Configurations.Manager.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Persistence.ElasticSearch.Common;

namespace Users.Service.Managment.Persistence.ElasticSearch.MarkupPlan
{
    public class MarkupPlanEs : BaseEs, IMarkupPlanES
    {
        public MarkupPlanEs(IConfigurationManager configurationManager) : base(configurationManager)
        {
        }

        public async Task<List<Domain.Entities.MarkupPlan>> GetMarkupPlan(string query)
        {
            var nestString = query.Replace('\"', '"');

            var indexName = IndicesNames.MarkupPlans;

            var esResponse = await ElasticClient.SearchAsync<Domain.Entities.MarkupPlan>(
                                a => a.Query(q => q.Raw(nestString)).Index(indexName).Size(500));

            var markupPlanEs = esResponse.Documents.ToList();

            return markupPlanEs;
        }
    }
}