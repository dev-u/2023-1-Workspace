using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teste de sumario estatico
/// </summary>
public static class SummaryStatic
{
    /// <summary>
    /// Printa a mensagem
    /// </summary>
    /// <param name="mensagem"> A mensagem a ser printada  </param>
    /// <returns>  nada </returns>
    public static string TesteDebug(string mensagem)
    {
        Debug.Log(mensagem + "!");
        return "";
    }
}
