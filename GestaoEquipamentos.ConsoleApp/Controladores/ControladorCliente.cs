using System;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorCliente : ControladorBase
    {
        public ControladorCliente(int capacidadeRegistros) 
            : base(capacidadeRegistros)
        {
        }

        public string RegistrarCliente(int id, string nome, double preco,
            string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Cliente cliente;

            int posicao = 0;

            if (id == 0)
            {
                cliente = new Cliente();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                cliente = (Cliente)registros[posicao];
                posicao = ObterPosicaoOcupada(cliente);
            }

            //cliente.nome = nome;
            //cliente.preco = preco;
            //cliente.numeroSerie = numeroSerie;
            //cliente.dataFabricacao = dataFabricacao;
            //cliente.fabricante = fabricante;

            string resultadoValidacao = cliente.Validar();

            if (resultadoValidacao == "CLIENTE_VALIDO")
                registros[posicao] = cliente;

            return resultadoValidacao;
        }

        public Cliente SelecionarClientePorId(int id)
        {
            return (Cliente)SelecionarRegistro(new Cliente(id));
        }

        public bool ExcluirCliente(int idSelecionado)
        {
            return ExcluirRegistro(new Cliente(idSelecionado));
        }

        public Cliente[] SelecionarTodosClientes()
        {
            Cliente[] clientesAux = new Cliente[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), clientesAux, clientesAux.Length);

            return clientesAux;
        }
    }
}
