using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Backend;

namespace Frontend
{
    class PersonViewManager : IPersonViewManager
    {
        private readonly IPersonManger _personManager;

        public PersonViewManager(IPersonManger personManger)
        {
            _personManager = personManger;
        }

        public void StartMainLoop()
        {
            while (true)
            {
                Painter.WriteLineWithTextColor("Person Manager", ConsoleColor.DarkCyan);
                Painter.WriteLineWithTextColor("1: Wyświetl wszystkie pozycje", ConsoleColor.DarkYellow);
                Painter.WriteLineWithTextColor("2: Dodaj nową pozycje", ConsoleColor.DarkYellow);
                Painter.WriteLineWithTextColor("3: Usuń ostatnią zapisaną pozycje", ConsoleColor.DarkYellow);
                Painter.WriteLineWithTextColor("4: Usuń wybraną pozycje", ConsoleColor.DarkYellow);
                Painter.WriteLineWithTextColor("5: Edycja dowolnej pozycji", ConsoleColor.DarkYellow);

                var choose = ReadLine();

                switch (choose)
                {
                    case "1":
                        Clear();
                        ShowAllPeople();
                        break;
                    case "2":
                        Clear();
                        AddPerson();
                        break;
                    case "3":
                        Clear();
                        DeleteLastPerson();
                        break;
                    case "4":
                        Clear();
                        DeletePersonAtPosition();
                        break;
                    case "5":
                        Clear();
                        EditPerson();
                        break;
                    default:
                        Clear();
                        Painter.WriteLineWithTextColor("Podano niepoprawną wartość", ConsoleColor.Red);
                        break;
                }
            }
        }

        public void AddPerson()
        {
            Painter.WriteLineWithTextColor("Podaj imie: ", ConsoleColor.Green);
            string name = ReadLine();
            Painter.WriteLineWithTextColor("Podaj nazwisko: ", ConsoleColor.Green);
            string surname = ReadLine();
            Painter.WriteLineWithTextColor("Podaj adres: ", ConsoleColor.Green);
            string address = ReadLine();

            Person person = new Person(name, surname, address);
            _personManager.AddPerson(person);
            Clear();
        }

        public void DeleteLastPerson()
        {

            if (_personManager.Counter > 0)
            {
                Painter.WriteLineWithTextColor("Usunięto ostatni wpis", ConsoleColor.Green);
                _personManager.DeleteLastPerson();
            }
            else
                Painter.WriteLineWithTextColor("Baza jest pusta!", ConsoleColor.Red);
        }

        public void DeletePersonAtPosition()
        {
            Clear();

            while (true)
            {
                if (_personManager.Counter != 0)
                {
                    ShowAllPeople();
                    Painter.WriteWithTextColor("Podaj pozycje: ", ConsoleColor.DarkCyan);
                    var positionAsString = ReadLine();

                    if (uint.TryParse(positionAsString, out uint _position))
                    {
                        if (_position > _personManager.Counter || (_position <= 0))
                        {
                            Painter.WriteLineWithTextColor("Podano niepoprawną wartość", ConsoleColor.Red);
                            continue;
                        }
                        _position--;
                        _personManager.DeletePersonAtPosition(_position);
                        Painter.WriteLineWithTextColor("Usunięto wpis o indeksie: " + (_position + 1), ConsoleColor.Green);
                        break;
                    }
                    Painter.WriteLineWithTextColor("Podano niepoprawną wartość!", ConsoleColor.Red);
                    continue;
                }
                Painter.WriteLineWithTextColor("Baza jest pusta!", ConsoleColor.Red);
                break;
            }
        }

        public void ShowAllPeople()
        {
            Person[] people = _personManager.GetPeople();

            if (_personManager.Counter == 0)
            {
                Clear();
                Painter.WriteLineWithTextColor("Baza jest pusta!", ConsoleColor.Red);
            }
            else
            {
                for (int i = 0; i < people.Length; i++)
                {
                    Person person = people[i];
                    Painter.WriteLineWithTextColor(i + 1 + ": ", ConsoleColor.DarkCyan);
                    Painter.WriteWithTextColor("Imię:     ", ConsoleColor.DarkYellow);
                    WriteLine(person.Name);
                    Painter.WriteWithTextColor("Nazwisko: ", ConsoleColor.DarkYellow);
                    WriteLine(person.Surname);
                    Painter.WriteWithTextColor("Adres:    ", ConsoleColor.DarkYellow);
                    WriteLine(person.Address);
                }
            }
        }

        public void EditPerson()
        {
            Clear();

            while (true)
            {
                if (_personManager.Counter != 0)
                {
                    ShowAllPeople();
                    Painter.WriteWithTextColor("Podaj pozycje do edycji: ", ConsoleColor.DarkCyan);
                    var positionAsString = ReadLine();

                    if (uint.TryParse(positionAsString, out uint _position))
                    {
                        if ((_position > _personManager.Counter) || (_position == 0))
                        {
                            Painter.WriteLineWithTextColor("Podano niepoprawną wartość", ConsoleColor.Red);
                            continue;
                        }
                        _position--;
                        Painter.WriteLineWithTextColor("Podaj imie: ", ConsoleColor.Green);
                        string name = ReadLine();
                        Painter.WriteLineWithTextColor("Podaj nazwisko: ", ConsoleColor.Green);
                        string surname = ReadLine();
                        Painter.WriteLineWithTextColor("Podaj adres: ", ConsoleColor.Green);
                        string address = ReadLine();
                        Person person = new Person(name, surname, address);
                        _personManager.EditPerson(_position, person);
                        Clear();
                        Painter.WriteLineWithTextColor("Pozycja " + (_position + 1) + " została zmieniona", ConsoleColor.Green);
                        break;
                    }
                    Painter.WriteLineWithTextColor("Podano niepoprawną wartość", ConsoleColor.Red);
                    continue;
                }
                Painter.WriteLineWithTextColor("Baza jest pusta!", ConsoleColor.Red);
                break;
            }
        }

    }
}
