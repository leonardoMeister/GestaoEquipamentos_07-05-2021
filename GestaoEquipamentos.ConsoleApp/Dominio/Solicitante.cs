using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Solicitante
    {
        public int id;
        public string nome;
        public string email;
        public string telefone;
        private int IdEstatico = 1;

        public Solicitante()
        {
            id = IdEstatico;
            IdEstatico++;
        }
        public Solicitante(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (nome.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";
         
            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "SOLICITANTE_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Solicitante solicita = (Solicitante)obj;

            if (id == solicita.id)
                return true;
            else
                return false;
        }
    }
}
