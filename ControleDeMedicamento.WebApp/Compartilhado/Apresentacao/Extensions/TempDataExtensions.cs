using FluentResults;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ControleDeMedicamento.WebApp.Compartilhado.Apresentacao.Extensions;

public static class TempDataExtensions
{
    public static void AddErrorMenssage(this ITempDataDictionary tempData, ResultBase result)
    {
        tempData["MensagemErro"] = result.Errors.First().Message;
    }
}