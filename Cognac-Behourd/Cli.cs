using System;
using Cognac_Behourd.Interfaces;

namespace Cognac_Behourd
{
    public class Cli : IInteractable
    {
        public void Ecrire(string text) => Console.Write(text);

        public string Lire() => Console.ReadLine();
    }
}