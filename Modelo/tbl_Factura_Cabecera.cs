//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Factura_Cabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Factura_Cabecera()
        {
            this.tbl_Factura_Detalle = new HashSet<tbl_Factura_Detalle>();
        }
    
        public int fac_id { get; set; }
        public string fac_numero_serie { get; set; }
        public string fac_punto_emision { get; set; }
        public Nullable<System.DateTime> fac_fecha_emision { get; set; }
        public string fac_cli_cedula_ruc { get; set; }
        public string fac_cli_nombres { get; set; }
        public string fac_cli_apellidos { get; set; }
        public Nullable<decimal> fac_total { get; set; }
        public Nullable<decimal> fac_descuento { get; set; }
        public Nullable<decimal> fac_total_impuestos { get; set; }
        public string fac_forma_pago_codigo { get; set; }
        public string fac_usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Factura_Detalle> tbl_Factura_Detalle { get; set; }
    }
}
