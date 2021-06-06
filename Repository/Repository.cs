using DadoMemoria.Intefaces;
using DadoMemoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadoMemoria.Repository
{
    public abstract class Repository<TEntidadeBase> : IRepository<TEntidadeBase> where TEntidadeBase : EntidadeBase
    {
        protected readonly List<TEntidadeBase> Registros;
        protected Repository(List<TEntidadeBase> registros)
        {
            Registros = registros;
        }

        public void Adicionar(TEntidadeBase entidade)
        {
            Registros.Add(entidade);
        }

        public void Atualizar(int id, TEntidadeBase entidade)
        {
            Registros[id] = entidade;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            Registros[id].Excluido = true;
        }

        public List<TEntidadeBase> ListarTodos()
        {
            return Registros;
        }
        
        public TEntidadeBase ObterPorId(int id)
        {
            if(id > Registros.Count -1)
            {
                return null;
            }

            return Registros[id];
        }

        public int ObterProximoId()
        {
            return Registros.Count;
        }
    }
}
