﻿using CRM_Crud.Models;
using System.Collections.Generic;

namespace CRM_Crud.Repositories
{
    public interface IInscricaoRepository
    {
        void CriarInscricao(Inscricao Inscricao);
        IList<Inscricao> ListarInscricoes();
        Inscricao ListarUmaInscricao(int id);
        void EditarInscricao(Inscricao Inscricao);
        void DeletarInscricao(int id);
    }
}