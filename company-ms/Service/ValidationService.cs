using System;
using System.Security.Cryptography;
using System.Text;

namespace MsCompany.Service
{
    public class ValidationService
    {
        public bool cpfCnpj(string cpfCnpj)
        {
            return (IsCpf(cpfCnpj) || IsCnpj(cpfCnpj));
        }

        private static string IsValid(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }


        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = IsValid(cpf.Trim());
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = IsValid(cnpj.Trim());
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public string KeyGenerator(string name)
        {
            string token = "";
            string key = "";
            int b = 128;

            using (var sha256 = SHA256.Create())
            {
                if(name == "code") b = 1;
                byte[] bytes = new byte[b / 8];
                using (var keyGenerator = RandomNumberGenerator.Create())
                {
                    keyGenerator.GetBytes(bytes);
                    key = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(key + name));
                token = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return token;
            }

        }

        // private static string GetRandomSalt()
        // {
        //     return BCrypt.Net.BCrypt.GenerateSalt();
        // }

        // public string HashPassword(string password)
        // {
        //     return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        // }

        // public bool ValidatePassword(string password, string correctHash)
        // {
        //     return BCrypt.Net.BCrypt.Verify(password, correctHash);
        // }
        // public bool ValidatePasswordCompany(string password, string correctHash)
        // {
        //     return BCrypt.Net.BCrypt.Verify(password, correctHash);
        // }


    }
}

