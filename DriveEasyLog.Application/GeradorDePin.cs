using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DriveEasyLog.Application;

public static class GeradorDePin
{
    private static readonly Random _random = new Random();

    public static string GerarPinUnico()
    {
        // 1. Gera 3 letras maiúsculas aleatórias
        const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string parteLetras = new string(Enumerable.Repeat(letras, 3)
            .Select(s => s[_random.Next(s.Length)]).ToArray());

        // 2. Gera 3 números aleatórios
        const string numeros = "0123456789";
        string parteNumeros = new string(Enumerable.Repeat(numeros, 3)
            .Select(s => s[_random.Next(s.Length)]).ToArray());

        // 3. Retorna o PIN combinado (Ex: "BGT881")
        return parteLetras + parteNumeros;
    }
}