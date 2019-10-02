﻿using PUC.LDSI.Domain.Entities;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Repository
{
    public interface IAvalicaoOpcaoRepository
    {
        Task<int> IncluirNovoProfessorAsync(Professor professor);
        Professor ObterPorLogin(string login);
    }
}
