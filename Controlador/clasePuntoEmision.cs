using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Modelo;

namespace Controlador
{
    public class clasePuntoEmision
    {
        public List<vta_Punto_Emision> storeVtaPuntoEmision()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.vta_Punto_Emision.ToList();
        }

        public List<tbl_Empresa> storeEstablecimiento()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Empresa.ToList();
        }

        public tbl_Punto_Emision buscarPuntoEmisionPorIP(string direccionIP)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Punto_Emision.Where(x => x.pem_direccion_ip == direccionIP).FirstOrDefault();
        }
        public vta_Punto_Emision buscarPuntoEmisionVistaPorIP(string direccionIP)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.vta_Punto_Emision.Where(x => x.pem_direccion_ip == direccionIP).FirstOrDefault();
        }
        public tbl_Punto_Emision buscarPuntoEmisionPorEstablecimientoPuntoEmision(int establecimiento, string puntoEmision)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Punto_Emision.Where(x => x.pem_emp_id == establecimiento && x.pem_punto_emision == puntoEmision).FirstOrDefault();
        }

        public String crearPuntoEmision(tbl_Punto_Emision puntoEmision, int pem_id)
        {
            try
            {
                if (pem_id != 0)
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tbl_Punto_Emision pem = tse.tbl_Punto_Emision.Where(x => x.pem_id == pem_id).FirstOrDefault();
                    if (pem is null)
                    {
                        tse.tbl_Punto_Emision.Add(puntoEmision);
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }
                    else
                    {
                        //modifcacion
                        pem.pem_emp_id = puntoEmision.pem_emp_id;
                        pem.pem_direccion_ip = puntoEmision.pem_direccion_ip;
                        pem.pem_punto_emision = puntoEmision.pem_punto_emision;
                        tse.SaveChanges();
                        string respuesta = "OK";
                        return respuesta;
                    }

                }
                else
                {
                    TpvSignoEntities tse = new TpvSignoEntities();
                    tse.tbl_Punto_Emision.Add(puntoEmision);
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
        public List<tbl_Punto_Emision> storePuntoEmision()
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Punto_Emision.ToList();
        }

        public List<vta_Punto_Emision> buscarPuntoEmisionPorEstablecimientoContains(string establecimiento)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.vta_Punto_Emision.Where(x => x.pem_emp_id.Contains(establecimiento)).ToList();
        }
        public List<vta_Punto_Emision> buscarPuntoEmisionPorDireccionIpContains(string direccionIP)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.vta_Punto_Emision.Where(x => x.pem_direccion_ip.Contains(direccionIP)).ToList();
        }
        public List<vta_Punto_Emision> buscarPuntoEmisionPorPuntoEmisionContains(string puntoEmision)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.vta_Punto_Emision.Where(x => x.pem_punto_emision.Contains(puntoEmision)).ToList();
        }
        public tbl_Punto_Emision buscarPuntoEmisionPorId(int pem_id)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            return tse.tbl_Punto_Emision.Where(x => x.pem_id == pem_id).FirstOrDefault();
        }

        public String eliminarPuntoEmision(tbl_Punto_Emision puntoEmision)
        {
            try
            {
                TpvSignoEntities tse = new TpvSignoEntities();
                var pe = tse.tbl_Punto_Emision.Where(X => X.pem_direccion_ip == puntoEmision.pem_direccion_ip).FirstOrDefault();
                tse.tbl_Punto_Emision.Remove(pe);
                tse.SaveChanges();
                String respuesta = "OK";
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public string getIP()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    }
}
