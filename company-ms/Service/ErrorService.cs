using MsCompany.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsCompany.Core.Service
{
    public class ErrorService
    {

        public Error CreateMessageReturnError(dynamic error, int message)
        {
            Error _error = new Error()
            {
                Message = "Erro ao " + Enum.GetName(typeof(Message), message) + " dados",
                Type = 1,
                Errors = error
            };
            return _error;
        }
        public string CreateMessageError(int type, int message)
        {
            switch (message)
            {
                case 1:
                    return Enum.GetName(typeof(TypeError), type) + " não encontrado na base de dados.";
                case 2:
                    return Enum.GetName(typeof(TypeError), type) + " informado está incorreto.";
                case 3:
                    return Enum.GetName(typeof(TypeError), type) + " Erro ao atualizar na base de dados.";
                case 4:
                    return Enum.GetName(typeof(TypeError), type) + " já existente na base de dados.";
                case 5:
                    return Enum.GetName(typeof(TypeError), type) + " não encontrado.";
            }

            return "Error";
        }

        enum Message
        {
            processar = 1,
            atualizar = 2
        }
        enum TypeError
        {
            companyId = 1,
            cnpjCpf = 2,
            companyAddressId = 3,
            companyParamsId = 4,
        }
    }
}
