//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KucniBudzetEntity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BudzetTabela
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public double Iznos { get; set; }
        public bool UlazIzlaz { get; set; }
        public double Suma { get; set; }
        public System.DateTime Datum { get; set; }
    }
}
