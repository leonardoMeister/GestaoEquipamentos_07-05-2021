using GestaoEquipamentos.ConsoleApp.Controladores;
using System;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaPrincipal
    {
        private readonly ControladorChamado controladorChamado;
        ControladorEquipamento controladorEquipamento;
        private readonly TelaEquipamento telaEquipamento;
        ControladorSolicitantes controladorSolicitantes;
        public TelaSolicitantes telaSolicitantes;

        public TelaPrincipal(ControladorSolicitantes ctrlSolicitantes ,ControladorEquipamento ctlrEquipamento, TelaSolicitantes tela1 ,TelaEquipamento tlEquipamento,    ControladorChamado ctlrChamado)
        {
            controladorEquipamento = ctlrEquipamento;
            telaEquipamento = tlEquipamento;
            controladorChamado = ctlrChamado;
            controladorSolicitantes = ctrlSolicitantes;
            telaSolicitantes = tela1;
        }

        public TelaBase ObterOpcao()
        {
            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
                Console.WriteLine("Digite 2 para o Controle de Chamados");
                Console.WriteLine("Digite 3 para o Controle de Solicitantes");


                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = new TelaEquipamento(controladorEquipamento);

                else if (opcao == "2")
                    telaSelecionada = new TelaChamado(telaSolicitantes, telaEquipamento, controladorChamado);

                else if (opcao == "3")
                    telaSelecionada = new TelaSolicitantes(controladorSolicitantes);

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1"&& opcao !="3"  && opcao != "2" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else
                return false;
        }
    }
}
