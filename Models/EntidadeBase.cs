using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadoMemoria.Models
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
        public bool Excluido { get; set; }
    }
}
