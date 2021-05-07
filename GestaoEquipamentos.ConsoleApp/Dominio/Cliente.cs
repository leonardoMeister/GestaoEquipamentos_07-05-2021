using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Cliente
    {
        private readonly int id;

        public Cliente()
        {
            id = GeradorId.GerarIdCliente();
        }

        public Cliente(int id)
        {
            this.id = id;
        }

        internal string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
