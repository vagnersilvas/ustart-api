using System;
using System.Collections.Generic;
using UStart.Domain.Entities;

namespace UStart.Domain.Contracts.Repositories
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        Cliente ConsultarPorId(Guid id);
        void Delete(Cliente cliente);
        IEnumerable<Cliente> Pesquisar(string pesquisa);
        void Update(Cliente cliente);
    }
}