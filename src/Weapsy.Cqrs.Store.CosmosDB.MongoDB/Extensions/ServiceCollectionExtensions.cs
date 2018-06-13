﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weapsy.Cqrs.Domain;
using Weapsy.Cqrs.Store.CosmosDB.MongoDB.Configuration;
using Weapsy.Cqrs.Store.CosmosDB.MongoDB.Documents.Factories;
using Weapsy.Cqrs.Store.CosmosDB.MongoDB.Stores;

namespace Weapsy.Cqrs.Store.CosmosDB.MongoDB.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeapsyCqrsCosmosDbMongoDbStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StoreConfiguration>(configuration.GetSection("StoreConfiguration"));

            services.AddTransient<IEventStore, EventStore>();
            services.AddTransient<IAggregateDocumentFactory, AggregateDocumentFactory>();
            services.AddTransient<IEventDocumentFactory, EventDocumentFactory>();

            return services;
        }
    }
}
