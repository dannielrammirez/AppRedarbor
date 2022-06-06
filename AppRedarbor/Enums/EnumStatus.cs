using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppRedarbor.Enums
{
    public enum EnumStatus
    {
        [Description("Creado")]
        Creado = 1,
        [Description("Activo")]
        Activo = 2,
        [Description("Inactivo")]
        Inactivo = 3,
        [Description("Suspendido")]
        Suspendido = 4,
        [Description("Eliminado")]
        Eliminado = 5
    }
}
