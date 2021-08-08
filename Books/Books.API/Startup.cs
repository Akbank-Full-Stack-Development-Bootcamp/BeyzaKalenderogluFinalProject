using Books.Business;
using Books.Business.Extensions;
using Books.DataAccess.Data;
using Books.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Books.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
            

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {

            services.AddControllers(opt =>
            {
                opt.CacheProfiles.Add("list", new CacheProfile { Duration = 300 });
            });
            
            services.AddResponseCaching();
            services.AddMemoryCache();

            services.AddDistributedRedisCache(opt =>
            {
                opt.Configuration = "genre_list: 6379";
            });

            //Redis Dependency Injection
            services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());

            services.AddMapperConfiguration();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IPublisherRepository, EFPublisherRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, EFAuthorRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<BooksDbContext>(option => option.UseSqlServer(connectionString));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Books.API",
                    Contact = new OpenApiContact
                    { 
                        Email = "bkalenderoglu1@gmail.com",
                        Name = "Beyza Kalenderoglu"
                    },
                    Version = "v1" });
            });

            services.AddMvc(option => option.EnableEndpointRouting = false)
                            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var issuer = Configuration.GetSection("Bearer")["Issuer"];
            var audience = Configuration.GetSection("Bearer")["Audience"];
            var key = Configuration.GetSection("Bearer")["SecurityKey"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateActor = true,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = issuer,
                            ValidAudience = audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                        };
                    });

            services.AddCors(opt =>
            {
                opt.AddPolicy("Allow", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });


            });

            
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Allow");

            app.UseResponseCaching();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
