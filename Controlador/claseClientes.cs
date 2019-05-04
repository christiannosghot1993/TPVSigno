using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
    public class claseClientes
    {
        public String crearClientes(tbl_Clientes clientes, int cli_id)
        {
            try
            {
                if (cli_id != 0)
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tbl_Clientes cli = tse.tbl_Clientes.Where(x => x.cli_id == cli_id).FirstOrDefault();
                    if (cli is null)
                    {
                        tse.tbl_Clientes.Add(clientes);
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }
                    else
                    {
                        //modifcacion
                        cli.cli_usuario = clientes.cli_usuario;
                        cli.cli_nombres = clientes.cli_nombres;
                        cli.cli_apellidos = clientes.cli_apellidos;
                        cli.cli_cedula_ruc = clientes.cli_cedula_ruc;
                        cli.cli_telefono = clientes.cli_telefono;
                        cli.cli_direccion = clientes.cli_direccion;
                        cli.cli_estado = clientes.cli_estado;
                        cli.cli_correo = clientes.cli_correo;
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }

                }
                else
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tse.tbl_Clientes.Add(clientes);
                    tse.SaveChanges();
                    string respuesta = "OK";
                    return respuesta;
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public List<tbl_Clientes> storeClientes()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_estado == "Activo" || x.cli_estado == "Inactivo").ToList();
        }
        public tbl_Clientes buscarClientesPorRucCi(string rucCi)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_cedula_ruc == rucCi).FirstOrDefault();
        }

        public String eliminarClientes(tbl_Clientes clientes)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                var cli = tse.tbl_Clientes.Where(X => X.cli_cedula_ruc == clientes.cli_cedula_ruc).FirstOrDefault();
                tse.tbl_Clientes.Remove(cli);
                tse.SaveChanges();
                String respuesta = "OK";
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        public tbl_Clientes buscarClientesPorId(int cli_id)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_id == cli_id).FirstOrDefault();
        }

        public List<tbl_Clientes> buscarClientesActivosAsc()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_estado == "Activo").OrderBy(x=>x.cli_apellidos).ToList();
        }

        public List<tbl_Clientes> buscarClientesActivosPorNombreAsc(String nombres)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x =>x.cli_nombres.Contains(nombres) && x.cli_estado == "Activo").OrderBy(x => x.cli_nombres).ToList();
        }
        public List<tbl_Clientes> buscarClientesActivosPorApellidoAsc(String apellidos)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_apellidos.Contains(apellidos) && x.cli_estado == "Activo").OrderBy(x => x.cli_apellidos).ToList();
        }
        public List<tbl_Clientes> buscarClientesActivosPorRucCiAsc(String rucCi)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_cedula_ruc.Contains(rucCi) && x.cli_estado == "Activo").OrderBy(x => x.cli_apellidos).ToList();
        }
        public List<tbl_Clientes> buscarClientesPorRucCiContains(String rucCi)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_cedula_ruc.Contains(rucCi)).ToList();
        }
        public List<tbl_Clientes> buscarClientesPorNombresApellidosContains(String nombresApellidos)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Clientes.Where(x => x.cli_nombres.Contains(nombresApellidos) || x.cli_apellidos.Contains(nombresApellidos)).ToList();
        }
    }
}
