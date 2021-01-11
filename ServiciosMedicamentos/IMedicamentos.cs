using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiciosMedicamentos.Clases;
namespace ServiciosMedicamentos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMedicamentos
    {
        //Listo de Medicamentos
        [OperationContract]
        List<MedicamentoCLS> ListarMedicamentos();

        //Lista forma farmaceutica
        List<FormaFarmaceuticaCLS> ListaFormaFarmaceutica();

        //recuperar Medicamento

        MedicamentoCLS RecuperarMedicamento(int iidMedicamento);

        //Agregar y editar Medicamento

        int  RegistraryActualizarMedicamento(MedicamentoCLS oMedicamentoCLS);

        //Eliminar medicamento

        int EliminarMedicamento(int iidMedicamento);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.

}
