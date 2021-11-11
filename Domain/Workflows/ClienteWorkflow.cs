using System;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.UoW;

namespace UStart.Domain.Workflows
{
    public class ClienteWorkflow : WorkflowBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ClienteWorkflow(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public Cliente Add(ClienteCommand command)
        {

            if (string.IsNullOrEmpty(command.Nome))
            {
                this.AddError("Nome", "Nome não informado");
            }

            if (this.IsValid() == false)
            {
                return null;
            }

            var cliente = new Cliente(command);
            _clienteRepository.Add(cliente);
            _unitOfWork.Commit();

            return cliente;
        }

        public void Update(Guid id, ClienteCommand command){
            
            var cliente = _clienteRepository.ConsultarPorId(id);
            if (cliente != null){
                cliente.Update(command);
                _clienteRepository.Update(cliente);
                _unitOfWork.Commit();
            }
            else{
                AddError("Cliente", "Cliente não pode ser encontrado", id);
            }

        }

        public void Delete(Guid id){

            //GrupoProduto grupoProduto = _grupoProdutoRepository.ConsultarPorId(id);

            var cliente = _clienteRepository.ConsultarPorId(id);
            if (cliente != null){
                _clienteRepository.Delete(cliente);
                _unitOfWork.Commit();                
            }else{
                AddError("Cliente", "Cliente não pode ser encontrado", id);
            }            
        }

        
    }
}