using System.Text;

namespace TestProject1.Utils
{
    public static class DataUtils
    {
        private static readonly Random random = new Random();
        private static string GenerateRandomString(int length, string characterPool)
        {
            return new string(Enumerable.Range(0, length)
                .Select(_ => characterPool[random.Next(characterPool.Length)])
                .ToArray());
        }

        public static (string localPart, string randomDomain, string password) GenerateEmailDomainAndPassword()
        {
            var testData = TestDataProvider.Load();
            const string letters = "abcdefghijklmnopqrstuvwxyz";
            const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numerals = "0123456789";
            const string cyrillicChars = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя";
            var localPart = GenerateRandomString(testData.EmailLength, letters);
            var randomDomain = GenerateRandomString(testData.DomainLength, letters);
            var passwordLength = testData.PasswordLength;
            var password = new StringBuilder();

            password.Append(capitalLetters[random.Next(capitalLetters.Length)]);
            password.Append(numerals[random.Next(numerals.Length)]);
            password.Append(localPart[random.Next(localPart.Length)]);
            password.Append(cyrillicChars[random.Next(cyrillicChars.Length)]);

            var allCharacters = letters + capitalLetters + numerals + cyrillicChars;
            while (password.Length < passwordLength)
            {
                password.Append(allCharacters[random.Next(allCharacters.Length)]);
            }

            var finalPassword = new string(password.ToString().OrderBy(_ => random.Next()).ToArray());

            return (localPart, randomDomain, finalPassword);
        }
    }
}
