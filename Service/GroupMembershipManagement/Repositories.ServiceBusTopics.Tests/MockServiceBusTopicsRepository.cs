// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using Models;
using Models.ServiceBus;
using Newtonsoft.Json.Linq;
using Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tests.Repositories
{
    public class MockServiceBusTopicsRepository : IServiceBusTopicsRepository
    {
        public Dictionary<string, List<ServiceBusMessage>> Subscriptions { get; private set; } = new Dictionary<string, List<ServiceBusMessage>>();

        public async Task AddMessageAsync(SyncJob job)
        {
            var allQueries = JArray.Parse(job.Query);
            var queryTypes = allQueries.SelectTokens("$..type")
                                    .Select(x => x.Value<string>())
                                    .Distinct()
                                    .ToList();

            foreach (var queryType in queryTypes)
            {
                var message = CreateMessage(job);
                if (Subscriptions.ContainsKey(queryType))
                {
                    Subscriptions[queryType].Add(message);
                }
                else
                {
                    Subscriptions.Add(queryType, new List<ServiceBusMessage> { message });
                }
            }

            await Task.CompletedTask;
        }

        public Task AddMessageAsync(ServiceBusMessage message)
        {
            throw new System.NotImplementedException();
        }

        public ServiceBusMessage CreateMessage(SyncJob job)
        {
            var body = JsonSerializer.Serialize(job);
            var message = new ServiceBusMessage
            {
                Body = Encoding.UTF8.GetBytes(body)
            };

            message.MessageId = $"{job.PartitionKey}_{job.RowKey}_{job.RunId}";

            return message;
        }
    }
}
