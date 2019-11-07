using System;
using System.Linq;
using Financecalc_Server.Models;
using Financecalc_Server.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Financecalc_Server.Utils
{
    public class InitValues
    {
        private readonly FinancecalcDBContext context;

        public InitValues(IServiceProvider serviceProvider)
        {
            IServiceScope scope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();

            context = scope.ServiceProvider.GetService<FinancecalcDBContext>();

        }

        public InitValues ClasificacionValues()
        {
            if (context.Clasificacion.Count() == 0)
            {
                context.Clasificacion.AddRange(DbData.getClasificacionData());
                context.SaveChanges();
            }
            return this;
        }
    }
}