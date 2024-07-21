
using OSR_API.Repositories.Implementation;
using OSR_API.Repositories.Interface;
using OSR_API.Services.Implementation;
using OSR_API.Services.Interface;
using Repositories.Helpers.Implementation;
using Repositories.Helpers.Interface;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Implementation;
using Services.Interface;

namespace OSR_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            #region Services and Repositories Lifetimes Registerations
            #region Repos
            builder.Services.AddTransient<IUserRepository,UserRepository>();
            builder.Services.AddTransient<IReadyRepository,ReadyRepository>();
            builder.Services.AddTransient<IDiscountingRepository,DiscountingRepository>();
            builder.Services.AddTransient<IForwardRepository,ForwardRepository>();
            builder.Services.AddTransient<ISetofffwRepository,SetofffwRepository>();
            builder.Services.AddTransient<ICloseoutRepository,CloseoutRepository>();
            builder.Services.AddTransient<IOutstandingFWDRepository,OutstandingFWDRepository>();
            #endregion
            #region Services
            builder.Services.AddTransient<IUserService,UserService>();
            builder.Services.AddTransient<IAuthService,AuthService>();
            builder.Services.AddTransient<IReadyService,ReadyService>();
            builder.Services.AddTransient<IDiscountingService,DiscountingService>();
            builder.Services.AddTransient<IForwardService,ForwardService>();
            builder.Services.AddTransient<ISetofffwService, SetoffwService>();
            builder.Services.AddTransient<ICloseoutService, CloseoutService>();
            builder.Services.AddTransient<IOutstandingFWDService, OutstandingFWDService>();
            #endregion
            #region DB
            builder.Services.AddTransient<IDbHelper, DbHelper>();
            #endregion
            #endregion
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowAll");
            app.Run();
        }
    }
}
