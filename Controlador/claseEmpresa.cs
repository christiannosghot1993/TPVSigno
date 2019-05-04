using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Controlador
{
    public class claseEmpresa
    {
        public String crearEmpresas(tbl_Empresa empresas, int emp_id)
        {
            try
            {
                if (emp_id != 0)
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tbl_Empresa emp = tse.tbl_Empresa.Where(x => x.emp_id == emp_id).FirstOrDefault();
                    if (emp is null)
                    {
                        tse.tbl_Empresa.Add(empresas);
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }
                    else
                    {
                        //modifcacion
                        emp.emp_ruc = empresas.emp_ruc;
                        emp.emp_razon_social = empresas.emp_razon_social;
                        emp.emp_nombre_comercial = empresas.emp_nombre_comercial;
                        emp.emp_obligada_contabilidad = empresas.emp_obligada_contabilidad;
                        emp.emp_contribuyente_especial = empresas.emp_contribuyente_especial;
                        emp.emp_numero_establecimiento = empresas.emp_numero_establecimiento;
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }

                }
                else
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tse.tbl_Empresa.Add(empresas);
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

        public List<tbl_Empresa> storeEmpresas()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.ToList();
        }

        public tbl_Empresa buscarEmpresaPorRazonSocial(string razonSocial)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.Where(x => x.emp_razon_social == razonSocial).FirstOrDefault();
        }

        public tbl_Empresa buscarEmpresaPorRuc(string ruc)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.Where(x => x.emp_ruc == ruc).FirstOrDefault();
        }

        public List<tbl_Empresa> buscarEmpresaPorRucContains(String ruc)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.Where(x => x.emp_ruc.Contains(ruc)).ToList();
        }

        public List<tbl_Empresa> buscarEmpresaPorRazonSocialContains(String razonSocial)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.Where(x => x.emp_razon_social.Contains(razonSocial)).ToList();
        }

        public List<tbl_Empresa> buscarEmpresaPorNombreComercialContains(String nombreComercial)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.Where(x => x.emp_nombre_comercial.Contains(nombreComercial)).ToList();
        }

        public tbl_Empresa buscarEmpresaPorId(int emp_id)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.Where(x => x.emp_id == emp_id).FirstOrDefault();
        }

        public String eliminarEmpresa(tbl_Empresa empresa)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                var emp = tse.tbl_Empresa.Where(X => X.emp_ruc == empresa.emp_ruc).FirstOrDefault();
                tse.tbl_Empresa.Remove(emp);
                tse.SaveChanges();
                String respuesta = "OK";
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }


    }
}
