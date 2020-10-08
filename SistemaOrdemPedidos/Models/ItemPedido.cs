using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaOrdemPedidos.Models
{
    public class ItemPedido
    {
        [Key]
        public int ItemPedidoId { get; set; }

        [Required]
        public float Quantidade { get; set; }

        [Required]
        [Display(Name = "Observações")]
        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}