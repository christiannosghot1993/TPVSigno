using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Controlador
{
    public class claseLogin
    {
        public String verificarUsuario(string nombreUsuario, string Contrasena)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            String respuesta = "";
            tbl_Usuarios usuario = tse.tbl_Usuarios.Where(x => x.usu_nombre_usuario == nombreUsuario).FirstOrDefault();
            if (usuario!=null)
            {
                if (usuario.usu_contrasena==Contrasena)
                {
                    respuesta = "OK";
                    return respuesta;
                }
                else
                {
                    respuesta = "Contraseña incorrecta";
                    return respuesta;
                }
            }
            else
            {
                respuesta = "El usuario ingresado no existe!!";
                return respuesta;
            }
        }
    }
}
