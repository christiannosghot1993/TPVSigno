using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Controlador
{
    public class claseFamilias
    {
        public String crearFamilia(tbl_Familias familias, int fam_id) {
            try
            {
                if (fam_id!=0)
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tbl_Familias tblFam = new tbl_Familias();
                    tblFam = tse.tbl_Familias.Where(x => x.fam_id == fam_id).FirstOrDefault();
                    if (tblFam is null)
                    {
                        tse.tbl_Familias.Add(familias);
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }
                    else
                    {
                        tblFam.fam_descripcion = familias.fam_descripcion;
                        tblFam.fam_estado = familias.fam_estado;
                        tblFam.fam_usuario = familias.fam_usuario;
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }
                }
                else
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tse.tbl_Familias.Add(familias);
                    tse.SaveChanges();
                    string respuesta = "OK";
                    return respuesta;
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
        public List<tbl_Familias> storeFamilias()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Familias.Where(x => x.fam_estado == "Activo" || x.fam_estado=="Inactivo").ToList();
        }

        public List<tbl_Familias> familiasActivas()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Familias.Where(x => x.fam_estado == "Activo").ToList();
        }

        public tbl_Familias buscarFamiliasPorDescripcion(string descripcion)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Familias.Where(x => x.fam_descripcion == descripcion).FirstOrDefault();
        }

        public List<tbl_Familias> buscarFamiliasPorDescripcionContains(string descripcion)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Familias.Where(x => x.fam_descripcion.Contains(descripcion)).ToList();
        }

        public tbl_Familias buscarFamiliasPorId(int fam_id)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Familias.Where(x => x.fam_id == fam_id).FirstOrDefault();
        }


        public String eliminarFamilia(tbl_Familias familias)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                var fam = tse.tbl_Familias.Where(X => X.fam_descripcion == familias.fam_descripcion).FirstOrDefault();
                tse.tbl_Familias.Remove(fam);
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
