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

            this.context = scope.ServiceProvider.GetService<FinancecalcDBContext>();

        }

        public InitValues ClasificacionValues()
        {
            if (this.context.Clasificacion.Count() == 0)
            {
                this.context.Clasificacion.AddRange(DbData.getClasificacionData());
                this.context.SaveChanges();
            }
            return this;
        }

        public InitValues SubclasificacionValues()
        {
            if (this.context.Subclasificacion.Count() == 0)
            {
                this.context.Subclasificacion.AddRange(DbData.getSubclasificacionData(this.context));
                this.context.SaveChanges();
            }

            return this;
        }
    }
}