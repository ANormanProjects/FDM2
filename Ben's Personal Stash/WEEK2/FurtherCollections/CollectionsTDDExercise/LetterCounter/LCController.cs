using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCounter
{
    public class LCController
    {
        public Dictionary<char, int> LetterCounter { get; set; }
        
        public LCController()
        {
            LetterCounter = new Dictionary<char, int>();
        }



        public Dictionary<char, int> NumOfOccurences(string myWord)
        {
            var chars = myWord.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (LetterCounter.ContainsKey(chars[i]) == false)
                {
                    LetterCounter.Add(chars[i], 1);
                }
                else
                {
                    LetterCounter[chars[i]] = LetterCounter[chars[i]] + 1;
                }   
            }

            //foreach(KeyValuePair<char, int> entry in LetterCounter)           //Used with Main Method
            //{
            //    Console.WriteLine(entry.Key + " occurs: " + entry.Value);
            //}

            return LetterCounter;
            {
                
            }
        
    //        Dictionary<char, int> numOfOc = new Dictionary<char, int>();

    //    foreach (char character in sentence)
    //{
    //    if(numOfOc.ContainsKey(character))
    //    {
    //        numOfOc[character]++;
    //    }
    //    else
    //    {
    //        numOfOc.Add(character, 1);
    //    }
    //    return numOfOc;
    //}
        }

    }

    //public void NumOfOccurs(string mystring)
    //{ //HELLO THERE
    //    var H = (mystring.Count(x => x == 'H'));
    //    var E = (mystring.Count(x => x == 'E'));
    //    var L = (mystring.Count(x => x == 'L'));
    //    var O = (mystring.Count(x => x == 'O'));
    //    var T = (mystring.Count(x => x == 'T'));
    //    var R = (mystring.Count(x => x == 'R'));

    //    LetterCounter.Add('H', H);
    //    LetterCounter.Add('E', E);
    //    LetterCounter.Add('L', L);
    //    LetterCounter.Add('O', O);
    //    LetterCounter.Add('T', E);
    //    LetterCounter.Add('R', R);

    //}

  
}
