namespace GestaoEquipamentos.ConsoleApp
{
    public class ControladorBase
    {
        const int CAPACIDADE_REGISTROS = 100;

        protected object[] registros;

        public ControladorBase()
        {
            registros = new object[CAPACIDADE_REGISTROS];
        }

        protected bool ExcluirRegistro(object obj)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                object registro = registros[i];

                if (registro != null && registro.Equals(obj)) //registro.id == id
                {
                    registros[i] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }
            return conseguiuExcluir;
        }

        protected object[] SelecionarTodosRegistros()
        {
            object[] registrosAux = new object[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (object registro in registros)
            {
                if (registro != null)
                    registrosAux[i++] = registro;
            }

            return registrosAux;
        }

        public object SelecionarRegistroPorId(object obj)
        {
            object registro = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registro = registros[i];

                    break;
                }
            }

            return registro;
        }

        protected int QtdRegistrosCadastrados()
        {
            int numeroRegistrosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroRegistrosCadastrados++;
                }
            }

            return numeroRegistrosCadastrados;
        }

        protected int ObterPosicaoVaga()
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        protected int ObterPosicaoOcupada(object obj)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj)) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
    }
}