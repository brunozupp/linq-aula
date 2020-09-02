using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuSite.Models
{
    // Parte da outra Produto, que foi criada com o banco
    public partial class Produto
    {
        [Display(Name = "Total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public decimal Total 
        { 
            get {
                return this.Quantidade * this.ValorUnitario;
            } 
        }
    }
}