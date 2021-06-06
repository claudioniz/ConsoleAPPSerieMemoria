using DadoMemoria.Intefaces;
using DadoMemoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadoMemoria.Repository
{
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        public SerieRepository(List<Serie> series) : base(series) {
            
        }
    }
}
