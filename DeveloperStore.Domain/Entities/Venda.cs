using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Entities
{
    public class Venda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public string Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public string Filial { get; set; }
        public ICollection<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
        public bool Cancelado { get; set; } = false;
    }
}
