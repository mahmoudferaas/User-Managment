using BaseClasses.Configurations.Manager.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Persistence.ElasticSearch.Common;

namespace Users.Service.Managment.Persistence.ElasticSearch.User
{
    public class UserEs : BaseEs, IUserES
    {
        public UserEs(IConfigurationManager configurationManager) : base(configurationManager)
        {
        }

        public async Task<List<Domain.Entities.User>> GetUser(string query)
        {
            var nestString = query.Replace('\"', '"');

            var indexName = IndicesNames.User;

            var userEsResponse = await ElasticClient.SearchAsync<Domain.Entities.User>(
                                a => a.Query(q => q.Raw(nestString)).Index(indexName).Size(500));

            var userEs = userEsResponse.Documents.ToList();

            return userEs;
        }

    }
}