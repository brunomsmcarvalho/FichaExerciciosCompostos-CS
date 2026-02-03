using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string password;
        while (true)
        {
            Console.Write("Introduza a password: ");
            password = Console.ReadLine();

            if (IsPasswordValid(password))
            {
                Console.WriteLine("Password válida.");
                break;
            }
            else
            {
                Console.WriteLine("Password inválida. Deve ter pelo menos 8 caracteres, conter uma letra maiúscula, uma letra minúscula e um número.");
            }
        }
    }

    private static bool IsPasswordValid(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8)
            return false;

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            else if (char.IsLower(c)) hasLower = true;
            else if (char.IsDigit(c)) hasDigit = true;

            if (hasUpper && hasLower && hasDigit)
                return true;
        }

        return false;
    }
}