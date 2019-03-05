using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using NapoleonNotes.Filters;
using NapoleonNotes.DAL;

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
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        
        public void Configure(IApplicationBuilder app, INoteRepository notes)
        {
            // seeding some notes
            notes.Create(new Note
            {
                CreatedAt = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(20)),
                Title = "Джеймс",
                Text = "Бакстер"
            });
            notes.Create(new Note
            {
                CreatedAt = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(120)),
                Title = "Заметка из прошлого",
                Text = "Кто меня создал?"
            });

            app.UseMvc();
        }
    }
}
