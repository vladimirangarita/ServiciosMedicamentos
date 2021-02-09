using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace ServiciosMedicamentos.Clases
{
    public class Autenticacion : UserNamePasswordValidator
    {

        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new NotImplementedException("El usuario null o vacio");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new NotImplementedException("El passsword no null o vacio");
            }

            if (!(userName.ToLower().Equals("lhurol") && password.ToLower().Equals("1234")))
            {
                throw new FaultException("Usuario o contraseñ invalido");
            }

        }
    }
}