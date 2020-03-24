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
                new Clasificacion { Code=-1, Name="na" },
                new Clasificacion { Code=1000, Name="cuentas de activo" },
                new Clasificacion { Code=2000, Name="cuentas de pasivo" },
                new Clasificacion { Code=3000, Name="cuentas de capital contable" },
                new Clasificacion { Code=4000, Name="cuentas complementarias de activo" },
                new Clasificacion { Code=5000, Name="cuentas de resultado acreedoras" },
                new Clasificacion { Code=6000, Name="cuentas de resultado deudoras" },
                new Clasificacion { Code=7000, Name="cuentas de orden" }
            };

        public static List<Subclasificacion> getSubclasificacionData(FinancecalcDBContext c) =>
            new List<Subclasificacion>
            {
                new Subclasificacion{ Code=-1, Name="na", Clasification=c.Clasificacion.Single(i => i.Code == -1) },
                new Subclasificacion { Code=1100, Name="activo circulante", Clasification=c.Clasificacion.Single(i => i.Code == 1000) },
                new Subclasificacion{ Code=1200, Name="activo fijo", Clasification=c.Clasificacion.Single(i => i.Code == 1000) },
                new Subclasificacion{ Code=1300, Name="activo diferido", Clasification=c.Clasificacion.Single(i => i.Code == 1000) },
                new Subclasificacion{ Code=1400, Name="otros activos", Clasification=c.Clasificacion.Single(i => i.Code == 1000) },
                new Subclasificacion{ Code=2100, Name="pasivo circulante", Clasification=c.Clasificacion.Single(i => i.Code == 2000) },
                new Subclasificacion{ Code=2200, Name="pasivo no circulante", Clasification=c.Clasificacion.Single(i => i.Code == 2000) }
            };
    }
}