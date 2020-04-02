using BaseClasses.Configurations.Manager.Managers;
using BaseClasses.Configurations.Manager.Utilities;
using Nest;
using System;

namespace Users.Service.Managment.Persistence.ElasticSearch.Common
{
    public abstract class BaseEs
    {
        protected readonly IElasticClient ElasticClient;

        protected BaseEs(IConfigurationManager configurationManager)
        {
            ElasticClient = Initialize(configurationManager);
        }

        private static IElasticClient Initialize(IConfigurationManager configurationManager)
        {
            var node = new Uri(configurationManager.GetConfiguration<Shared.Common.Keys, string>(url => url.ElasticSearchUrl));

            var settings = new ConnectionSettings(node);
            settings.BasicAuthentication(configurationManager.GetConfiguration<Shared.Common.Keys, string>(userName => userName.ElasticSearchUser), configurationManager.GetConfiguration<Shared.Common.Keys, string>(password => password.ElasticSearchPassword));
            settings.DefaultFieldNameInferrer(p => p.ToLower());
            settings.DisableDirectStreaming();

            return new ElasticClient(settings);
        }
    }
}