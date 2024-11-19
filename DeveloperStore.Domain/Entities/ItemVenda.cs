using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Entities
{
    public class ItemVenda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid VendaId { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;
    }
}
