using System;
using System.Collections.Generic;
using System.Linq;
using Financecalc_Server.Models;

namespace Financecalc_Server.Data
{
    public abstract class DbData
    {
        public static List<Clasificacion> getClasificacionData() =>
            new List<Clasificacion>
            {
                new Clasificacion { Id=-1, Name="na" },
                new Clasificacion { Id=1000, Name="cuentas de activo" },
                new Clasificacion { Id=2000, Name="cuentas de pasivo" },
                new Clasificacion { Id=3000, Name="cuentas de capital contable" },
                new Clasificacion { Id=4000, Name="cuentas complementarias de activo" },
                new Clasificacion { Id=5000, Name="cuentas de resultado acreedoras" },
                new Clasificacion { Id=6000, Name="cuentas de resultado deudoras" },
                new Clasificacion { Id=7000, Name="cuentas de orden" }
            };

        public static List<Subclasificacion> getSubclasificacionData(FinancecalcDBContext c) =>
            new List<Subclasificacion>
            {
                new Subclasificacion{ Id=-1, Name="na", Clasification=c.Clasificacion.Single(i => i.Id == -1) },
                new Subclasificacion { Id=1100, Name="activo circulante", Clasification=c.Clasificacion.Single(i => i.Id == 1000) },
                new Subclasificacion{ Id=1200, Name="activo fijo", Clasification=c.Clasificacion.Single(i => i.Id == 1000) },
                new Subclasificacion{ Id=1300, Name="activo diferido", Clasification=c.Clasificacion.Single(i => i.Id == 1000) },
                new Subclasificacion{ Id=1400, Name="otros activos", Clasification=c.Clasificacion.Single(i => i.Id == 1000) },
                new Subclasificacion{ Id=2100, Name="pasivo circulante", Clasification=c.Clasificacion.Single(i => i.Id == 2000) },
                new Subclasificacion{ Id=2200, Name="pasivo no circulante", Clasification=c.Clasificacion.Single(i => i.Id == 2000) }
            };
    }
}