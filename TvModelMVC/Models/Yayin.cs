//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TvModelMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yayin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yayin()
        {
            this.Sorumlu = new HashSet<Sorumlu>();
        }
    
        public int YayinId { get; set; }
        public string YayinAdi { get; set; }
        public string YayinTarihi { get; set; }
        public decimal YayinReyting { get; set; }
        public int KanalKanalId { get; set; }
    
        public virtual Kanal Kanal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sorumlu> Sorumlu { get; set; }
    }
}