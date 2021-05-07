using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaEquipamento : TelaBase
    {
        private ControladorEquipamento controladorEquipamento;
        public TelaEquipamento(ControladorEquipamento controlador)
            : base("Cadastro de Equipamentos")
        {
            controladorEquipamento = controlador;
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo equipamento...");

            bool conseguiuGravar = GravarEquipamento(0);

            if (conseguiuGravar)
                ApresentarMensagem("Equipamento inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir o equipamento", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando um equipamento...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarEquipamento(id);

            if (conseguiuGravar)
                ApresentarMensagem("Equipamento editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o equipamento", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um equipamento...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorEquipamento.ExcluirEquipamento(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Equipamento excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o equipamento", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando equipamentos...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Equipamento[] equipamentos = controladorEquipamento.SelecionarTodosEquipamentos();

            if (equipamentos.Length == 0)
            {
                ApresentarMensagem("Nenhum equipamento cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   equipamentos[i].id, equipamentos[i].nome, equipamentos[i].fabricante);
            }
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarEquipamento(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preço do equipamento: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            resultadoValidacao = controladorEquipamento.RegistrarEquipamento(
                id, nome, preco, numeroSerie, dataFabricacao, fabricante);

            if (resultadoValidacao != "EQUIPAMENTO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }



        #endregion
    }

}
