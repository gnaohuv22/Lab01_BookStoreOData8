using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBookStore.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<BookStoreContext>(options =>
            options.UseInMemoryDatabase("BookLists"));

        builder.Services
            .AddControllers()
            .AddOData(opt => opt.Select()
                                .Filter()
                                .Count()
                                .OrderBy()
                                .Expand()
                                .SetMaxTop(100)
                                .AddRouteComponents("odata", GetEdmModel()));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseODataBatching();

        app.UseRouting();

        app.Use(next => context =>
        {
            var endpoint = context.GetEndpoint();
            if (endpoint == null)
            {
                return next(context);
            }

            IEnumerable<string> templates;
            IODataRoutingMetadata metadata = endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
            if (metadata != null)
            {
                templates = metadata.Template.GetTemplates();
            }
            return next(context);
        });

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    private static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<Book>("Books");
        builder.EntitySet<Press>("Presses");
        return builder.GetEdmModel();
    }
}