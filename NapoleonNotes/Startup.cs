using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using NapoleonNotes.Filters;
using NapoleonNotes.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace NapoleonNotes
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddSingleton<INoteRepository, NoteRepository>();
            services
                .AddMvc(options=>
                {
                    options.Filters.Add<InvalidModelResponseFilter>();
                })
                .AddJsonOptions(options =>
                {
                    var contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };

                    options.SerializerSettings.ContractResolver = contractResolver;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.Converters.Add(new UnixDateTimeConverter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        
        public void Configure(IApplicationBuilder app, INoteRepository notes)
        {
            // seeding some notes
            //notes.Create(new Note
            //{
            //    CreatedAt = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(20)),
            //    Title = "Джеймс",
            //    Text = "Бакстер"
            //});
            //notes.Create(new Note
            //{
            //    CreatedAt = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(120)),
            //    Title = "Заметка из прошлого",
            //    Text = "Кто меня создал?"
            //});

            app.UseMvc();
        }
    }
}
