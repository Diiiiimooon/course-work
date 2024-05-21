using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Hotel
{
    internal class User
    {
      
            string name, surname, patronymic, login;
            bool chGuests, chNumbers, chGuests_Numbers, chPayment, chTimeOfResidence, chUsers;
            string acGuests, acNumbers, acGuests_Numbers, acPayment, acTimeOfResidence, acUsers;

            public User(string surname, string name, string patronymic, string login, bool chGuests, bool chNumbers, bool chGuests_Numbers, bool chPayment, bool chTimeOfResidence, bool chUsers, string acGuests, string acNumbers, string acGuests_Numbers, string acPayment, string acTimeOfResidence, string acUsers)
            {
                this.surname = surname; // Фамилия пользователя
                this.name = name; // Имя пользователя
                this.patronymic = patronymic; // Отчество пользователя
                this.login = login; // Логин пользователя
                this.chGuests = chGuests; // Права на таблицу Guests
                this.chNumbers = chNumbers; // Права на таблицу Numbers
                this.chGuests_Numbers = chGuests_Numbers; // Права на таблицу Guests_Numbers
                this.chPayment = chPayment; // Права на таблицу Payment
                this.chTimeOfResidence = chTimeOfResidence; // Права на таблицу TimeOfResidence
                this.chUsers = chUsers; // Права на таблицу Users                
                this.acGuests = acGuests; // Доступ к таблице Guests 
                this.acNumbers = acNumbers; // Доступ к таблице Numbers
                this.acGuests_Numbers = acGuests_Numbers; // Доступ к таблице Guests_Numbers
                this.acPayment = acPayment; // Доступ к таблице Payment
                this.acTimeOfResidence = acTimeOfResidence; // Доступ к таблице TimeOfResidence
                this.acUsers = acUsers; // Доступ к таблице Users

        }
            public string Surname { get => surname; set => surname = value; }
            public string Name { get => name; set => name = value; }
            public string Patronymic { get => patronymic; set => patronymic = value; }
            public string Login { get => login; set => login = value; }
            public bool ChGuests { get => chGuests; set => chGuests = value; }
            public bool ChNumbers { get => chNumbers; set => chNumbers = value; }
            public bool ChGuests_Numbers { get => chGuests_Numbers; set => chGuests_Numbers = value; }
            public bool ChPayment { get => chPayment; set => chPayment = value; }
            public bool ChTimeOfResidence { get => chTimeOfResidence; set => chTimeOfResidence = value; }
            public bool ChUsers { get => chUsers; set => chUsers = value; }
            public string AcGuests { get => acGuests; set => acGuests = value; }
            public string AcNumbers { get => acNumbers; set => acNumbers = value; }
            public string AcGuests_Numbers { get => acGuests_Numbers; set => acGuests_Numbers = value; }
            public string AcPayment { get => acPayment; set => acPayment = value; }
            public string AcTimeOfResidence { get => acTimeOfResidence; set => acTimeOfResidence = value; }
            public string AcUsers { get => acUsers; set => acUsers = value; }
    }
    
}
