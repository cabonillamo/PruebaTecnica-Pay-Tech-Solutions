//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trabajo
    {
        public int ID_TAREA { get; set; }
        public int ID_ESTADO_TAREA { get; set; }
        public string TITULO { get; set; }
        public string DESCRIPCION { get; set; }
        public System.DateTime FECHA_REGISTRO { get; set; }
        public Nullable<System.DateTime> FECHA_TERMINADA { get; set; }
        public Nullable<int> ID_BORRADO { get; set; }
    
        public virtual Borrado_Logico Borrado_Logico { get; set; }
        public virtual Estado_Tarea Estado_Tarea { get; set; }
    }
}
