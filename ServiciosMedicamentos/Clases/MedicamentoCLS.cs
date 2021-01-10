using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosMedicamentos.Clases
{
    [DataContract]
    public class MedicamentoCLS
    {
       [DataMember(Order =0)]
        public string Nombre { get; set; }
        [DataMember(Order = 0)]
        public string Concentracion { get; set; }
        [DataMember(Order = 0)]
        public int IidFormaFarmaceutica { get; set; }
        [DataMember(Order = 0)]
        public string NombreFormaFarmaceutica { get; set; }
        [DataMember(Order = 0)]

        public decimal Precio { get; set; }
        [DataMember(Order = 0)]
        public int Stock { get; set; }
        [DataMember(Order = 0)]
        public string Presentacion { get; set; }
        public int BHabilitado { get; set; }

    }
}