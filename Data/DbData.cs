using System;
using System.Collections.Generic;
using Financecalc_Server.Models;

namespace Financecalc_Server.Data
{
    public abstract class DbData
    {
        public static List<Clasificacion> getClasificacionData()
        {
            return new List<Clasificacion>
            {
                new Clasificacion { Id = 1000, Name = "cuentas de activo" },
                new Clasificacion { Id=2000, Name="cuentas de pasivo" },
                new Clasificacion { Id=3000, Name="cuentas de capital contable" },
                new Clasificacion { Id=4000, Name="cuentas complementarias de activo" },
                new Clasificacion { Id=5000, Name="cuentas de resultado acreedoras" },
                new Clasificacion { Id=6000, Name="cuentas de resultado deudoras" },
                new Clasificacion { Id=7000, Name="cuentas de orden" }
            };
        }
    }
}