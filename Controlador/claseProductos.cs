using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Controlador
{
    public class claseProductos
    {
        public String crearProductos(tbl_Productos productos, int pro_id)
        {
            try
            {
                if (pro_id != 0)
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tbl_Productos prod = tse.tbl_Productos.Where(x => x.pro_id == pro_id).FirstOrDefault();
                    if (prod is null)
                    {
                        tse.tbl_Productos.Add(productos);
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }
                    else
                    {
                        //modifcacion
                        prod.pro_usuario = productos.pro_usuario;
                        prod.pro_codigo= productos.pro_codigo;
                        prod.pro_descripcion = productos.pro_descripcion;
                        prod.pro_prv_id = productos.pro_prv_id;
                        prod.pro_fam_id = productos.pro_fam_id;
                        prod.pro_coste = productos.pro_coste;
                        prod.pro_estado = productos.pro_estado;
                        prod.pro_stock_actual = productos.pro_stock_actual;
                        prod.pro_stock_minimo = productos.pro_stock_minimo;
                        prod.pro_imagen = productos.pro_imagen;
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }

                }
                else
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tse.tbl_Productos.Add(productos);
                    tse.SaveChanges();
                    string respuesta = "OK";
                    return respuesta;
                }

            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }

        public List<tbl_Productos> storeProductos()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_estado == "Activo" || x.pro_estado == "Inactivo").ToList();
        }

        public tbl_Productos buscarProductosPorCod(string pro_codigo)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_codigo == pro_codigo).FirstOrDefault();
        }

        public List<tbl_Productos> buscarProductosPorCodActivo(string pro_codigo)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_codigo.Contains(pro_codigo)&&x.pro_estado=="Activo").ToList();
        }

        public List<tbl_Productos> buscarProductosPorCodActivoInactivo(string pro_codigo)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_codigo.Contains(pro_codigo)).ToList();
        }

        public tbl_Productos buscarProductosPorId(int pro_id)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_id == pro_id).FirstOrDefault();
        }

        public tbl_Productos buscarProductosPorCodBarras(string pro_codigo_barras)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_codigo_barras == pro_codigo_barras && x.pro_estado=="Activo").FirstOrDefault();
        }

        public String eliminarProductos(tbl_Productos productos)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                var prod = tse.tbl_Productos.Where(X => X.pro_codigo == productos.pro_codigo).FirstOrDefault();
                tse.tbl_Productos.Remove(prod);
                tse.SaveChanges();
                String respuesta = "OK";
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public List<tbl_Productos> productosActivos()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_estado == "Activo").ToList();
        }

        public List<tbl_Productos> buscarProductosPorFamId(int fam_id)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_fam_id == fam_id && x.pro_estado=="Activo").ToList();
        }

        public List<tbl_Productos> buscarProductosPorDescripcion(string descripcion)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_descripcion.Contains(descripcion) && x.pro_estado=="Activo").ToList();
        }
        public List<tbl_Productos> buscarProductosPorDescripcionActivoInactivo(string descripcion)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Productos.Where(x => x.pro_descripcion.Contains(descripcion)).ToList();
        }
    }
}
