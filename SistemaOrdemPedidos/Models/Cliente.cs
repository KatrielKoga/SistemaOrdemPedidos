using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaOrdemPedidos.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        [Display(Name ="Endereço")]
        [DataType(DataType.MultilineText)]
        public string Endereco { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}