using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaOrdemPedidos.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        private bool sit = true;
        [DefaultValue(true)]
        [Required]
        public bool Ativo { get { return sit; } set { sit = value; } }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItemPedido> ItensPedido { get; set; }
    }
}