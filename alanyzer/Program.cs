using System;
using System.Collections.Generic;
using System.IO;

namespace alanyzer
{
    class Program
    {
        static string decryptCaesar(string cyphertext, List<string> alphabet, int offset)
        {
            char[] buffertext = cyphertext.ToCharArray();
            string sourceText = "";
            for (int i = 0; i<buffertext.Length;i++)
            {
                if (alphabet.Contains(buffertext[i].ToString()))
                {
                    int newIndex = findIndexOf(alphabet, buffertext[i].ToString()) - offset;
                    if (newIndex>0)
                    {
                        sourceText+=  alphabet[newIndex % alphabet.Count].ToCharArray()[0];
                    }
                    else
                    {
                        sourceText+= alphabet[(alphabet.Count + newIndex) % alphabet.Count].ToCharArray()[0];
                    }
                    
                }
                else
                {
                    sourceText += buffertext[i];
                }
                
            }
            return sourceText;
        }
        static int findIndexOf(List<string> array, string elem)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == elem)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            List<string> letterdictionary2 = new List<string> { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            string letterdictionary = "абвгдежзийклмнопрстуфхцшщъыьэюя";           
            int[] frequencies = new int[letterdictionary2.Count];
            string message = "ъпэ дзвлэ эокмнияэзэ янмж, дпи вбрфэмп крнндвг ьбшд. зи нинпивп изэ зм вб йкэяве, рйкэазмзвг в рфмюзшт пмднпия. оеь ъпили нибоэзш окрлвм бэжмфэпмещзшм рфмюзвдв. ";
            /*int key;
            int k = 0;
              string file = @"Test.txt";
            int num = 0;
            int p = 0;
            string a = "";
            */
            message  = File.ReadAllText(@"result.txt");
            for (int i = 0; i < letterdictionary.Length; i++)
            {
                for(int j = 0; j < message.Length; j++)
                {
                    if (letterdictionary[i]==message[j])
                    {
                        frequencies[i]++;
                    }
                }
            }
            int cyphertextMostFrequentLetterIndex = findmax(frequencies);
            int offset = cyphertextMostFrequentLetterIndex - findIndexOf(letterdictionary2, "о") ;
            Console.WriteLine(String.Format("Most frequent letter in cyphertext is '{0}' wich index is {1}, so offset is {2}",
                letterdictionary2[cyphertextMostFrequentLetterIndex], cyphertextMostFrequentLetterIndex, offset));


            string result = decryptCaesar(message, letterdictionary2, offset);
            File.WriteAllText("freqres.txt", result);
            Console.WriteLine(result);

            //foreach(char n in message)
            //{
            //    if (letterdictionary.Contains(n))
            //    {
            //        if(p < message.Length)
            //        {
            //            p = message[n%message.Length];
            //            a = n.ToString();

            //        }
            //        else if (p == message.Length && !(letterdictionary.Contains(p.ToString())))
            //            {
            //            a = a + n;
            //        }
            //    }
            //}
            //int max = findmax(c);
          //  Console.WriteLine(a);           
        }
      
        static int findmax(int[] array)
        {
            int max = array[0];
            int indexOfMax = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
               if(array[i]>max)
                {
                    max = array[i];
                        indexOfMax = i;
                }
            }
            return indexOfMax;
        }

    }
}
