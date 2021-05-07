using System;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaFerramenta : TelaBase
    {
        public TelaFerramenta() : base("Cadastro de Ferramentas")
        {
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova ferramenta");

            bool conseguiuInserir = GravarFerramenta(0);

            if (conseguiuInserir)
            {
                ApresentarMensagem("Ferramenta inserida com sucesso", TipoMensagem.Sucesso);
            }
            else
            {
                ApresentarMensagem("Deu treta no cadastro", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        private bool GravarFerramenta(int v)
        {
            throw new NotImplementedException();
        }
    }
}
