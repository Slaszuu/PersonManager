using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class PersonManager : IPersonManger
    {
        private readonly Person[] _people = new Person[999];
        private int _counter = 0;


        public int Counter
        {
            get { return _counter; }
        }

        public void AddPerson(Person person)
        {

            _people[_counter] = person;
            _counter++;
        }

        public void DeleteLastPerson()
        {
            _people[_counter - 1] = null;
            _counter--;
        }

        public void DeletePersonAtPosition(uint position)
        {
            _people[position] = null;

            for (uint i = position; i < _counter - 1; i++)
            {
                _people[i] = _people[i + 1];
            }
            _counter--;
            _people[_counter] = null;

        }

        public Person[] GetPeople()
        {
            var list = new List<Person>();

            foreach (var person in _people)
            {
                if (person == null)
                {
                    break;
                }

                list.Add(person);
            }

            return list.ToArray();
        }

        public void EditPerson(uint position, Person person)
        {
            _people[position] = person;
        }
    }
}
