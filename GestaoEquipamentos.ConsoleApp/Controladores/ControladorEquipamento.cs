using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorEquipamento : ControladorBase
    {
        public string RegistrarEquipamento(int id, string nome, double preco,
            string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Equipamento equipamento = null;

            int posicao;

            if (id == 0)
            {
                equipamento = new Equipamento();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Equipamento(id));
                equipamento = (Equipamento)registros[posicao];
            }

            equipamento.nome = nome;
            equipamento.preco = preco;
            equipamento.numeroSerie = numeroSerie;
            equipamento.dataFabricacao = dataFabricacao;
            equipamento.fabricante = fabricante;

            string resultadoValidacao = equipamento.Validar();

            if (resultadoValidacao == "EQUIPAMENTO_VALIDO")
                registros[posicao] = equipamento;

            return resultadoValidacao;
        }

        public Equipamento SelecionarEquipamentoPorId(int id)
        {
            return (Equipamento)SelecionarRegistroPorId(new Equipamento(id));
        }

        public bool ExcluirEquipamento(int idSelecionado)
        {
            return ExcluirRegistro(new Equipamento(idSelecionado));
        }

        public Equipamento[] SelecionarTodosEquipamentos()
        {
            Equipamento[] equipamentosAux = new Equipamento[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), equipamentosAux, equipamentosAux.Length);

            return equipamentosAux;
        }

    }
}