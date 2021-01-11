using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiciosMedicamentos.Models;
using ServiciosMedicamentos.Clases;

namespace ServiciosMedicamentos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        int IService1.EliminarMedicamento(int iidMedicamento)
        {
            //throw new NotImplementedException();
            int rpta = 0;

            using (var bd=new MedicoEntities())
            {

                try
                {
                    Medicamento oMedicamento = bd.Medicamento.Where(P => P.IIDMEDICAMENTO == iidMedicamento).First();
                    oMedicamento.BHABILITADO = 0;
                    bd.SaveChanges();
                    rpta = 1;
                }
                catch (Exception)
                {
                    rpta = 0;
                    //throw;
                }


                return rpta;
            }
        }

        List<FormaFarmaceuticaCLS> IService1.ListaFormaFarmaceutica()
        {
            //throw new NotImplementedException();
            List<FormaFarmaceuticaCLS> ListaFormaFarmaceutica =
                new List<FormaFarmaceuticaCLS>();

            try
            {
                using (var bd = new MedicoEntities())
                {
                    ListaFormaFarmaceutica = bd.FormaFarmaceutica.Where(p=>p.BHABILITADO==1)
                        .Select(p => new FormaFarmaceuticaCLS
                        {
                            IidFormaFarmaceutica = p.IIDFORMAFARMACEUTICA,
                            NombreFormaFarmaceutica = p.NOMBRE
                        }).ToList();
                }
            }
            catch (Exception)
            {

                ListaFormaFarmaceutica = null;
            }
            return ListaFormaFarmaceutica;
        }

        List<MedicamentoCLS> IService1.ListarMedicamentos()
        {
            //throw new NotImplementedException();
            List<MedicamentoCLS> ListaMedicamento = new List<MedicamentoCLS>;
            try
            {
                using (var bd = new MedicoEntities())
                {
                    ListaMedicamento = (from medicamento in bd.Medicamento
                                        join formafarmaceutica in bd.FormaFarmaceutica
                                        on medicamento.IIDFORMAFARMACEUTICA equals
                                        formafarmaceutica.IIDFORMAFARMACEUTICA
                                        select new MedicamentoCLS
                                        {
                                            IidMedicamento = medicamento.IIDMEDICAMENTO,
                                            Nombre = medicamento.NOMBRE,
                                            Precio = (decimal)medicamento.PRECIO,
                                            NombreFormaFarmaceutica = formafarmaceutica.NOMBRE,
                                            Concentracion = medicamento.CONCENTRACION,
                                            Presentacion = medicamento.PRESENTACION,
                                            Stock = (int)medicamento.STOCK,
                                            BHabilitado=(int)medicamento.BHABILITADO
                                        }).ToList();
                }
            }
            catch (Exception)
            {

                ListaMedicamento = null;
            }

        }

        MedicamentoCLS IService1.RecuperarMedicamento(int iidMedicamento)
        {
            //throw new NotImplementedException();
            MedicamentoCLS oMedicamentoCLS = new MedicamentoCLS();
            try
            {
                using (var bd = new MedicoEntities())
                {
                    Medicamento oMedicamento = bd.Medicamento.Where(p => p.IIDMEDICAMENTO == iidMedicamento).First();
                    oMedicamentoCLS.IidMedicamento = oMedicamento.IIDMEDICAMENTO;
                    oMedicamentoCLS.IidFormaFarmaceutica =(int) oMedicamento.IIDFORMAFARMACEUTICA;
                    oMedicamentoCLS.Nombre = oMedicamento.NOMBRE;
                    oMedicamentoCLS.Precio =(decimal) oMedicamento.PRECIO;
                    oMedicamentoCLS.Stock = (int)oMedicamento.STOCK;
                    oMedicamentoCLS.Concentracion = oMedicamento.CONCENTRACION;
                    oMedicamentoCLS.Presentacion = oMedicamento.PRESENTACION;

                }
            }
            catch (Exception)
            {

                oMedicamentoCLS = null;
            }
            return oMedicamentoCLS;
        }

        int IService1.RegistraryActualizarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            //throw new NotImplementedException();
            int rpta = 0;
            try
            {
                using (var bd=new MedicoEntities())
                {
                    if (oMedicamentoCLS.IidFormaFarmaceutica==0)
                    {
                        Medicamento oMedicamento = new Medicamento();
                        oMedicamento.IIDMEDICAMENTO = oMedicamentoCLS.IidMedicamento;

                        oMedicamento.NOMBRE = oMedicamentoCLS.Nombre;
                        oMedicamento.PRECIO = oMedicamentoCLS.Precio;
                        oMedicamento.STOCK = oMedicamentoCLS.Stock;
                        oMedicamento.IIDFORMAFARMACEUTICA = oMedicamentoCLS.IidFormaFarmaceutica;
                        oMedicamento.CONCENTRACION = oMedicamentoCLS.Concentracion;
                        oMedicamento.PRESENTACION = oMedicamentoCLS.Presentacion;
                        oMedicamento.BHABILITADO = 1;

                        bd.Medicamento.Add(oMedicamento);
                        bd.SaveChanges();
                        rpta = 1;
                    }
                    else
                    {
                        Medicamento oMedicamento = bd.Medicamento.Where(p => p.IIDMEDICAMENTO == oMedicamentoCLS.IidMedicamento).First();


                        oMedicamento.NOMBRE = oMedicamentoCLS.Nombre;
                        oMedicamento.PRECIO = oMedicamentoCLS.Precio;
                        oMedicamento.STOCK = oMedicamentoCLS.Stock;
                        oMedicamento.IIDFORMAFARMACEUTICA = oMedicamentoCLS.IidFormaFarmaceutica;
                        oMedicamento.CONCENTRACION = oMedicamentoCLS.Concentracion;
                        oMedicamento.PRESENTACION = oMedicamentoCLS.Presentacion;
                        bd.SaveChanges();
                        rpta = 1;

                    }
                }
            }
            catch (Exception ex)
            {

                rpta = 0;

            }

            return rpta;
        }
    }
}
