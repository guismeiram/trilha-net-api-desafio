using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UnsupportedCurrencyException : Exception
    {
        public UnsupportedCurrencyException(string Tarefas)
           : base($"Tarefas \"{Tarefas}\" is unsupported.")
        {

        }
    }
}
