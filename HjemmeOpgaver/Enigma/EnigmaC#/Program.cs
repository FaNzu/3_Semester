using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnigmaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = "DECODE";
            int shift = 5;
            string[] rotors = {
                            "BDFHJLCPRTXVZNYEIWGAKMUSQO",
                            "AJDKSIRUXBLHWTMCQGZNPYFVOE",
                            "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
                        };
            string message = "XPCXAUPHYQALKJMGKRWPGYHFTKRFFFNOUTZCABUAEHQLGXREZ";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string caeser_cipher(string message, int shift, string operation)
            {
                StringBuilder result = new StringBuilder(1000);
                for (int i = 0; i < message.Length; i++)
                {
                    if (operation == "ENCODE")
                    {
                        result.Append(alphabet[(alphabet.IndexOf(message[i]) + shift + i) % 26]);
                    }
                    else
                    {
                        Console.Error.WriteLine($"{(alphabet.IndexOf(message[i]) - shift - i)} and the result so far is {result}");
                        result.Append(alphabet[(alphabet.IndexOf(message[i]) - shift - i + 78) % 26]);
                    }
                }
                return result.ToString();
            }

            string do_rotor(string message, string rotor, string operation)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < message.Length; i++)
                {
                    char letter = message[i];
                    int letterIndex = alphabet.IndexOf(letter);
                    if (operation == "ENCODE")
                    {
                        result.Append(rotor[letterIndex]);
                    }
                    else
                    {
                        result.Append(alphabet[rotor.IndexOf(letter) % 26]);
                    }
                }
                return result.ToString();
            }

            if (operation == "ENCODE")
            {
                message = caeser_cipher(message, shift, operation);
                foreach (string rotor in rotors)
                {
                    message = do_rotor(message, rotor, operation);
                }
            }
            else
            {
                Array.Reverse(rotors);
                foreach (string rotor in rotors)
                {
                    message = do_rotor(message, rotor, operation);
                }
                message = caeser_cipher(message, shift, operation);
            }
            Console.WriteLine(message);

            string.Concat(message, "\n");
        }
    }
}
