using Bo.TodoAppNTİer.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.Bussines.DependencyResolver.Microsoft
{
   public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-N7DU8EV\\SQLEXPRESS; database=TodoDb; integrated security=true");
            });
        }
    }
}
