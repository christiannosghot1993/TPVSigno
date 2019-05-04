using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Controlador
{
    public class claseFacturacion
    {
        public String guardarFacturaCabecera(tbl_Factura_Cabecera facturaCabecera)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                tse.tbl_Factura_Cabecera.Add(facturaCabecera);
                tse.SaveChanges();
                string respuesta = "OK";
                return respuesta;
            }catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public String guardarFacturaDetalle(List<tbl_Factura_Detalle> facturaDetalle)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                foreach (var item in facturaDetalle)
                {
                    tse.tbl_Factura_Detalle.Add(item);
                    tse.SaveChanges();
                }
                
                string respuesta = "OK";
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public List<tbl_Factura_Cabecera> comprobarFacturaCbecera()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Factura_Cabecera.Where(x => x.fac_id >= 1).ToList();
        }

        public tbl_Factura_Cabecera buscarFacturaCabeceraPorSerie(string serieFactura)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            tbl_Factura_Cabecera factCab = tse.tbl_Factura_Cabecera.Where(x => x.fac_numero_serie == serieFactura).FirstOrDefault();
            return factCab;
        }
    }
}
