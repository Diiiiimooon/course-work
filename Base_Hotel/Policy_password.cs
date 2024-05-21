using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Hotel
{

    static public class Policy_password
    {
        static uint minimumLength, maximumLength, passwordExpirationDays;
        static bool requiresSpecialCharacter, requiresUppercase, requiresLowercase, requiresNumber;
        static string forbiddenCharacters;

        // Минимальная длина пароля
        public static uint MinimumLength { get => minimumLength; set => minimumLength = value; }

        // Максимальная длина пароля
        public static uint MaximumLength { get => maximumLength; set => maximumLength = value; }

        // Требуется ли хотя бы одна заглавная буква
        public static bool RequiresUppercase { get => requiresUppercase; set => requiresUppercase = value; }

        // Требуется ли хотя бы одна строчная буква
        public static bool RequiresLowercase { get => requiresLowercase; set => requiresLowercase = value; }

        // Требуется ли хотя бы одна цифра
        public static bool RequiresNumber { get => requiresNumber; set => requiresNumber = value; }

        // Требуется ли хотя бы один специальный символ
        public static bool RequiresSpecialCharacter { get => requiresSpecialCharacter; set => requiresSpecialCharacter = value; }

        // Запрещенный набор символов
        public static string ForbiddenCharacters { get => forbiddenCharacters; set => forbiddenCharacters = value; }

        // Продолжительность действия пароля в днях
        public static uint PasswordExpirationDays { get => passwordExpirationDays; set => passwordExpirationDays = value; }


        // Метод проверки пароля на соответствие политике
        static public bool IsValid(string password, DateTime? passwordExpirationDate = null)
        {
            // Проверка длины
            if (password.Length < MinimumLength || password.Length > MaximumLength)
            {
                return false;
            }

            // Проверка символов
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasNumber = false;
            bool hasSpecialCharacter = false;
            string forbiddenCharacters = "`~$%^&*()_+{}[]|\\/*-№;:?<>";


            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(password[i]))
                {
                    hasLowercase = true;
                }
                else if (char.IsNumber(password[i]))
                {
                    hasNumber = true;
                }
                else if (!char.IsLetterOrDigit(password[i]) && !forbiddenCharacters.Contains(password[i]))
                {
                    hasSpecialCharacter = true;
                }
            }

            // Проверка требований к символам
            if ((RequiresUppercase == !hasUppercase)
                || (RequiresLowercase == !hasLowercase)
                || (RequiresNumber == !hasNumber)
                || (RequiresSpecialCharacter == !hasSpecialCharacter))
            {
                return false;
            }

            // Проверка срока действия пароля
            if (PasswordExpirationDays > 0 && passwordExpirationDate != null && passwordExpirationDate < DateTime.Now.AddDays(-PasswordExpirationDays))
            {
                return false;
            }

            return true;
        }

    }
}
