using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//teste ok
namespace CadastroCliente
{
    public class Cliente
    {
        public Cliente(string nomeEmpresa, string porte)
        {
            NomeEmpresa = nomeEmpresa;
            Porte = porte;
        }

        public int Id { get; }

        public string? NomeEmpresa { get; } 

        public string? Porte { get; }

    }

}
