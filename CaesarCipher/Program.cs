using System;
using System.Text.RegularExpressions;
namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string eOrD, text;
            int encryptVal;
            int tempVal;
            char[] textChar;
            bool quit = false;
            int[] charAmount = new int[127];
            while (quit == false)
            {
                Console.WriteLine("would You like to encrypt (E), decrypt (D), Perform Frequeny Analysis (F), or quit (Q)");
                eOrD = Console.ReadLine().ToUpper();
                if (eOrD.Contains("Q"))
                {
                    quit = true;
                }
                if (quit == false)
                {
                    Console.WriteLine("Input text");
                    text = Console.ReadLine().ToUpper();
                    text = Regex.Replace(text, @"\W", "");
                    textChar = text.ToCharArray(0, text.Length);
                    if (eOrD.Contains("F"))
                    {
                        for (int i = 0; i < textChar.Length; i++)
                        {
                            charAmount[Convert.ToInt32(textChar[i])]++;
                        }
                        for (int i = 0; i < charAmount.Length; i++)
                        {
                            if (charAmount[i] > 0)
                            {
                                Console.WriteLine("{0} amount = {1}", Convert.ToString(Convert.ToChar(i)), charAmount[i]);
                            }
                        }
                    }
                    else
                    {
                        do
                        {
                            try
                            {
                                Console.WriteLine("Input the encryption value between 1 and 25");
                                encryptVal = Convert.ToInt32(Console.ReadLine());
                                if (encryptVal > 25 || encryptVal < 1)
                                {
                                    throw new Exception();
                                }
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("that is not a valid integer, try again");
                            }
                        }
                        while (true);
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (Convert.ToString(text[i]) != " ")
                            {
                                if (eOrD.Contains("E"))
                                {
                                    tempVal = Convert.ToInt32(text[i]) + encryptVal;
                                    if (tempVal > 90)
                                    {
                                        tempVal = tempVal - 25;
                                    }
                                }
                                else
                                {
                                    tempVal = Convert.ToInt32(text[i]) - encryptVal;
                                    if (tempVal < 65)
                                    {
                                        tempVal = tempVal + 25;
                                    }
                                }
                                textChar[i] = Convert.ToChar(tempVal);

                            }
                        }
                        text = new string(textChar);
                        Console.WriteLine(text);
                    }
                }
            }
        }
    }
}
