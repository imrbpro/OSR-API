
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
            #endregion
            #region Services
            builder.Services.AddTransient<IUserService,UserService>();
            #endregion
            #region DB
            builder.Services.AddTransient<IDbHelper, DbHelper>();
            #endregion
            #endregion
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
