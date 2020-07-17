using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IPersonManger
    {
        int Counter { get; }
        void AddPerson(Person person);
        void DeleteLastPerson();
        void DeletePersonAtPosition(uint position);
        Person[] GetPeople();
        void EditPerson(uint position, Person person);
    }
}
