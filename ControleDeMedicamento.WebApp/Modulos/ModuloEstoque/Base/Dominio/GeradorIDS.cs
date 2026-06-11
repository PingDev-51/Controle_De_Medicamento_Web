using System;
using System.Security.Cryptography;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Dominio;

public static class GeradorIds
{
    public static string GerarIdCurto()
    {
        return Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);
    }
}

