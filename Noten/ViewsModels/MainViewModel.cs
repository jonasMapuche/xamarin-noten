using System;
using System.Collections.Generic;
using Noten.Models;

namespace Noten.ViewsModels
{
    public class MainViewModel
    {
        public static readonly NotenViewModel _notensViewModel = new NotenViewModel();

        public List<String> GetChord(string sigla)
        {
            ChordModel chord = _notensViewModel.GetChord(sigla);
            List<string> saida = new List<string>();
            if (chord != null)
            {
                saida.Add(chord.sigla.ToString());
            }
            else saida = null;
            return saida;
        }
    }
}