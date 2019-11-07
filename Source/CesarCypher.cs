using System;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public int Mod(int n, int m)
        {
            return ((n % m) + m) % m;
        }

        public string Treating(string message)
        {
            string final = "";
            for (int i = 0; i < message.Length; i++)
            {
                char letter = message[i];
                int asciiLetter = (int)letter;
                if ((asciiLetter >= 33 && asciiLetter <= 47) || (asciiLetter >= 58 && asciiLetter <= 64))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if ((asciiLetter >= 91 && asciiLetter <= 96) || (asciiLetter >= 123 && asciiLetter <= 254))
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            return final;
        }


        public string Crypt(string message)
        {
            if (message == null) throw new ArgumentNullException();
            string final = "";
            int encryptedAscii = 0;
            message = message.ToLower();

            for (int i = 0; i < message.Length; i++)
            {
                char letter = message[i];
                int asciiLetter = (int)letter;
                Treating(message);
                if ((asciiLetter >= 97) && (asciiLetter <= 122))
                {
                    encryptedAscii = Mod((asciiLetter - 97 + 3), 26) + 97;
                    final += (char)encryptedAscii;
                }
                else if ((asciiLetter >= 48) && (asciiLetter <= 57) || asciiLetter == 32)
                {
                    final += letter;
                }
            }
            return final;
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null) throw new ArgumentNullException();
            string final = "";
            int decryptedAscii = 0;
            cryptedMessage = cryptedMessage.ToLower();

            for (int i = 0; i < cryptedMessage.Length; i++)
            {
                char letter = cryptedMessage[i];
                int asciiLetter = (int)letter;
                Treating(cryptedMessage);
                if ((asciiLetter >= 97) && (asciiLetter <= 122))
                {
                    decryptedAscii = Mod((asciiLetter - 97 - 3), 26) + 97;
                    final += (char)decryptedAscii;
                }
                else if ((asciiLetter >= 48) && (asciiLetter <= 57) || asciiLetter == 32)
                {
                    final += letter;
                }
            }
            return final;
        }

    }

}