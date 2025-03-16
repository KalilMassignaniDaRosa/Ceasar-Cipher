namespace CeasarCipher
{
    public class CeaserCipher
    {
        public string Encrypt(int code, string phrase)
        {
            List<char> encryptedPhrase = new();

            foreach (char c in phrase)
            {
                // Caracteres com acentos sao mantidos
                if (char.IsLetter(c) && (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z'))
                {
                    bool isUpperCase = char.IsUpper(c);
                    char encryptedChar = _EncryptLetter(c, code, isUpperCase);
                    // Adiciona a lista
                    encryptedPhrase.Add(encryptedChar);
                }
                else
                {
                    // Mantem o char
                    encryptedPhrase.Add(c);
                }
                
            }

            // Converte a lista em array
            return new string(encryptedPhrase.ToArray());
        }

        // Converte letra para numero e adiciona o codigo
        private char _EncryptLetter(char c, int code, bool isUpperCase)
        {
            // Define o codigo ASCII
            // 'A' a 'Z' = 65 a 90
            // 'a' a 'z' = 97 a 122
            // usa 'A' ou 'a' para referencia
            int baseCode = isUpperCase ? 'A' : 'a';
            //Console.WriteLine("---\nChar: "+ c);
            //Console.WriteLine("Base Code: "+ baseCode);

            int letterIndex = c -baseCode;
            int newIndex = (letterIndex + code) %26;
            //Console.WriteLine("New Index: "+ newIndex);
            //Console.WriteLine("New Char code: "+ newIndex + baseCode);

            return (char)(newIndex + baseCode);
        }

        private char _DecryptLetter(char c, int code, bool isUpperCase)
        {
            int baseCode = isUpperCase ? 'A' : 'a';
            //Console.WriteLine("---\nChar: "+ c);
            //Console.WriteLine("Base Code: "+ baseCode);

            int letterIndex = c -baseCode;
            // +26 para garantir que o indice nao fique negativo
            int newIndex = (letterIndex - code + 26) % 26;
            //Console.WriteLine("New Index: "+ newIndex);
            //Console.WriteLine("New Char code: "+ newIndex + baseCode);

            return (char)(newIndex + baseCode);
        }


        public string Decrypt(int code, string phrase)
        {
            List<char> decryptedPhrase = new();

            foreach (char c in phrase)
            {
                if (char.IsLetter(c) && (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z'))
                {
                    bool isUpperCase = char.IsUpper(c);
                    char decryptedChar = _DecryptLetter(c, code, isUpperCase);
                    decryptedPhrase.Add(decryptedChar);
                }
                else
                {
                    decryptedPhrase.Add(c);
                }
            }

            return new string(decryptedPhrase.ToArray());
        }
    }
}
