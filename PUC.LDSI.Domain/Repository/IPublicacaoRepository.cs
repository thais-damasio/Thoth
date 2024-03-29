﻿using PUC.LDSI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Repository
{
    public interface IPublicacaoRepository : IRepository<Publicacao>
    {
        Task<Publicacao> ObterComRelacoesAsync(int id);
        Task<IEnumerable<Publicacao>> ListarComRelacoesAsync();
        Task<IEnumerable<Publicacao>> ListarComRelacoesAsync(int id_turma, int id_aluno);
        Task<IEnumerable<Publicacao>> ObterProvasComRelacoesAsync(int IdAluno, int id_turma);
    }
}
