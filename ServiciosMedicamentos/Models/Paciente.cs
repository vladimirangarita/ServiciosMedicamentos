//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiciosMedicamentos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            this.Consulta = new HashSet<Consulta>();
        }
    
        public int IIDPACIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APPATERNO { get; set; }
        public string APMATERNO { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONOFIJO { get; set; }
        public string TELEFONOCELULAR { get; set; }
        public Nullable<System.DateTime> FECHANACIMIENTO { get; set; }
        public Nullable<int> IIDSEXO { get; set; }
        public Nullable<int> IIDTIPOSANGRE { get; set; }
        public string ALERGIAS { get; set; }
        public string ENFERMEDADESCRONICAS { get; set; }
        public string CUADRADOVACUNAS { get; set; }
        public string ANTECEDENTESQUIRURGICOS { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public byte[] foto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual TipoSangre TipoSangre { get; set; }
    }
}
