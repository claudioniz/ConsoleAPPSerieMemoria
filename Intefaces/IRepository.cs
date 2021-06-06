using DadoMemoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadoMemoria.Intefaces
{
    public interface IRepository<TEntidadeBase> : IDisposable where TEntidadeBase : EntidadeBase
    {
        List<TEntidadeBase> ListarTodos();
        TEntidadeBase ObterPorId(int id);
        void Adicionar(TEntidadeBase entidade);
        void Excluir(int id);
        void Atualizar(int id, TEntidadeBase entidade);
        int ObterProximoId();
    }
}
