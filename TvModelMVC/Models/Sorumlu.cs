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
    
    public partial class Sorumlu
    {
        public int SorumluId { get; set; }
        public string SorumluIsim { get; set; }
        public string SorumluGorevi { get; set; }
        public decimal SorumluMaas { get; set; }
        public int YayinYayinId { get; set; }
    
        public virtual Yayin Yayin { get; set; }
    }
}
