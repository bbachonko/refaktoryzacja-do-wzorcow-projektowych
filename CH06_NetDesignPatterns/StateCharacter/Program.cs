using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringToDesignPatterns.CH06_NetDesignPatterns.StateCharacter
{
    class Program
    {
        static void Main()
        {
            Character character = new Character();

            character.Attack(); // Zdrowy atak
            character.Heal(); // Zdrowy, nic się nie dzieje

            character.SetState(character.WoundedState); // Zmiana stanu na Ranny
            character.Attack(); // Ranny atak
            character.Heal(); // Leczenie, zmiana na Zdrowy

            character.SetState(character.UnconsciousState); // Zmiana stanu na Nieprzytomny
            character.Attack(); // Atak nieprzytomnej postaci
            character.Heal(); // Leczenie, zmiana na Ranny
        }
    }
}
