using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorSolicitantes: ControladorBase
    {
        public string RegistrarSolicitante(int id, string nome, string telefone, string email)
        {
            Solicitante solicitante = null;

            int posicao;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Solicitante(id));
                solicitante = (Solicitante)registros[posicao];
            }

            solicitante.nome = nome;
            solicitante.email = email;
            solicitante.telefone = telefone;
            

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "SOLICITANTE_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistroPorId(new Solicitante(id));
        }

        public bool ExcluirSolicitante(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante[] SelecionarTodosSolicitantes()
        {
            Solicitante[] solicitnatesAux = new Solicitante[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), solicitnatesAux, solicitnatesAux.Length);

            return solicitnatesAux;
        }

    }
}
