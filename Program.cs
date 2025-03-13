using CeasarCipher;

CeaserCipher cipher = new();
string phrase;
int num;
int option;

do
{
    Console.Clear();

    Console.WriteLine("Choose an option:");
    Console.WriteLine("1) Encrypt");
    Console.WriteLine("2) Decrypt");
    Console.WriteLine("3) Exit");

    while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
    {
        Console.WriteLine("Invalid option. \nPlease choose 1 for Encrypt, 2 for Decrypt or 3 to Exit.");
    }

    if (option == 3)
    {
        Console.WriteLine("Exiting the program...");
        break;
    }

    do
    {
        Console.WriteLine("Insert a phrase: ");
        phrase = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(phrase))
        {
            Console.WriteLine("The phrase cannot be null or empty. Please enter a valid phrase.");
        }
        else if (phrase.Any(c => !char.IsLetter(c) && c != ' '))
        {
            Console.WriteLine("The phrase can only contain letters (including accented letters and letters from other alphabets) and spaces. Please enter a valid phrase.");
            phrase = null!;
        }

    } while (string.IsNullOrWhiteSpace(phrase) || phrase.Any(c => !char.IsLetter(c) && c != ' '));

    Console.WriteLine("Insert a number: ");
    while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
    {
        Console.WriteLine("Invalid number. \nPlease enter a positive number: ");
    }

    string result = "";
    if (option == 1)
    {
        result = cipher.Encrypt(num, phrase);
        Console.WriteLine($"Encrypted Phrase: {result}");
    }
    else if (option == 2)
    {
        result = cipher.Decrypt(num, phrase);
        Console.WriteLine($"Decrypted Phrase: {result}");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

} while (option != 3);
