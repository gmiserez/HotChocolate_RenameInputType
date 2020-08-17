using System;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.Stitching;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Stitching
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("StarWars",
                (ctx, cfg) =>
                {
                    cfg.BaseAddress = new Uri("http://localhost:61227/graphql");
                });

            services.AddGraphQLSubscriptions();
            services.AddStitchedSchema(builder => builder
                .AddSchemaFromHttp("StarWars")
                .AddExtensionsFromFile("schemaExtensions.graphql")
                .RenameType("StarWars", "CreateReviewInput", "SaveReviewInput"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseGraphQL();
        }
    }
}
