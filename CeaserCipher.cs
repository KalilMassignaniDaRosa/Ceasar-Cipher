using static CeasarCipher.Letters;

namespace CeasarCipher
{
    public class CeaserCipher
    {
        public int code;

        public string Encrypt(int code, string phrase)
        {
            List<int> numbers = LetterToNumber(phrase);
            List<int> encryptedNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number != -1) 
                {
                    bool isUpperCase = char.IsUpper(phrase[encryptedNumbers.Count]); // Verifica se e maiuscula
                    int encryptedNumber = AdjustNumberForWrapAround(number + code, isUpperCase);
                    encryptedNumbers.Add(encryptedNumber);
                }
                else
                {
                    // Mantem caracteres nao alfabeticos
                    encryptedNumbers.Add(-1);
                }
            }

            // Converte numero para letra
            string encryptedPhrase = "";
            foreach (int num in encryptedNumbers)
            {
                if (num != -1)
                {
                    // Volta o numero para o caracter
                    encryptedPhrase += (char)num;
                }
                else
                {
                    // Mantem caracteres nao alfabeticos
                    encryptedPhrase += phrase[encryptedNumbers.IndexOf(num)];
                }
            }

            return encryptedPhrase;
        }

        // Converte letra em numero (A = 0, ... , Z = 25)
        public static int ConvertLetterToNumber(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                // Tenta fazer o parse do caractere para o enum
                if (Enum.TryParse<LetterEnum>(c.ToString(), out LetterEnum letter))
                {
                    return (int)letter; // Retorna o valor do enum
                }
            }
            // Retorna -1 se nao for valido
            return -1;
        }

        // Wrap Arround
        public static int AdjustNumberForWrapAround(int number, bool isUpperCase)
        {
            int baseValue = isUpperCase ? 'A' : 'a';
            return (number + 26) % 26 + baseValue; // Garante o wrap-around considerando A ou a
        }

        public static List<int> LetterToNumber(string phrase)
        {
            List<int> numbers = new List<int>();

            foreach (char c in phrase)
            {
                if (c >= 'A' && c <= 'Z') // Maiusculas
                {
                    numbers.Add(c - 'A');
                }
                else if (c >= 'a' && c <= 'z') // Minusculas
                {
                    numbers.Add(c - 'a');
                }
                else
                {
                    numbers.Add(-1); // Ignora numeros e outros caracteres
                }
            }

            return numbers;
        }

        public string Decrypt(int code, string phrase)
        {
            List<int> numbers = LetterToNumber(phrase);
            List<int> decryptedNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number != -1)
                {
                    bool isUpperCase = char.IsUpper(phrase[decryptedNumbers.Count]); 
                    int decryptedNumber = AdjustNumberForWrapAround(number - code, isUpperCase);
                    decryptedNumbers.Add(decryptedNumber);
                }
                else
                {
                    decryptedNumbers.Add(-1); 
                }
            }

            string decryptedPhrase = "";
            foreach (int num in decryptedNumbers)
            {
                if (num != -1)
                {
                    decryptedPhrase += (char)num; 
                }
                else
                {
                    decryptedPhrase += phrase[decryptedNumbers.IndexOf(num)];
                }
            }

            return decryptedPhrase;
        }
    }
}
