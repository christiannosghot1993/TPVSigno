using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
    public class claseProveedores
    {
        public String crearProveedores(tbl_Proveedores proveedores, int prv_id)
        {
            try
            {
                if (prv_id!=0)
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tbl_Proveedores prov = tse.tbl_Proveedores.Where(x => x.prv_id == prv_id).FirstOrDefault();
                    if (prov is null)
                    {
                        tse.tbl_Proveedores.Add(proveedores);
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }
                    else
                    {
                        //modifcacion
                        prov.prv_usuario = proveedores.prv_usuario;
                        prov.prv_ruc = proveedores.prv_ruc;
                        prov.prv_razon_social = proveedores.prv_razon_social;
                        prov.prv_pagina_web = proveedores.prv_pagina_web;
                        prov.prv_direccion = proveedores.prv_direccion;
                        prov.prv_email = proveedores.prv_email;
                        prov.prv_estado = proveedores.prv_estado;
                        prov.prv_telefono = proveedores.prv_telefono;
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }

                }
                else
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tse.tbl_Proveedores.Add(proveedores);
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

        public List<tbl_Proveedores> storeProveedores()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Proveedores.Where(x => x.prv_estado == "Activo" || x.prv_estado=="Inactivo").ToList();
        }

        public List<tbl_Proveedores> storeProveedoresActivos()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Proveedores.Where(x => x.prv_estado == "Activo").ToList();
        }

        public tbl_Proveedores buscarProveedoresPorRUC(string ruc)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Proveedores.Where(x => x.prv_ruc == ruc ).FirstOrDefault();
        }

        public List<tbl_Proveedores> buscarProveedoresPorRUCContains(string ruc)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Proveedores.Where(x => x.prv_ruc.Contains(ruc)).ToList();
        }

        public List<tbl_Proveedores> buscarProveedoresPorRazonSocialContains(string razonSocial)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Proveedores.Where(x => x.prv_razon_social.Contains(razonSocial)).ToList();
        }

        public String eliminarProveedor(tbl_Proveedores proveedores)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                var prov = tse.tbl_Proveedores.Where(X => X.prv_ruc == proveedores.prv_ruc).FirstOrDefault();
                tse.tbl_Proveedores.Remove(prov);
                tse.SaveChanges();
                String respuesta = "OK";
                return respuesta;
            }catch(Exception ex)
            {
                return ex.ToString();
            }
            
        }

    }
}
