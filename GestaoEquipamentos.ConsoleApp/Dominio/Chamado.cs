using System;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Chamado
    {
        public int id;
        public string titulo;
        public string descricao;
        public DateTime dataAbertura;
        public Equipamento equipamento;
        public Solicitante solicitante;

        public Chamado()
        {
            id = GeradorId.GerarIdChamado();
        }  


        public Chamado(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string DiasEmAberto
        {
            get
            {
                TimeSpan diasEmAberto = DateTime.Now - dataAbertura;

                return diasEmAberto.ToString("dd");
            }
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(titulo))
                resultadoValidacao += "O campo Nome é obrigatório \n";
            if(solicitante is null)
                resultadoValidacao += "Solicitante Inválido \n";
            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CHAMADO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Chamado chamado = (Chamado)obj;

            if (id == chamado.id)
                return true;
            else
                return false;
        }
    }
}
