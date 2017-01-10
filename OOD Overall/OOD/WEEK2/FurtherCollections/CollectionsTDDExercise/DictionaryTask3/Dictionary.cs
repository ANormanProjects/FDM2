using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DictionaryTask3
{
    public class DictionaryController
    {
        public Dictionary<string, Color> colordic { get; set; }

        public DictionaryController()
        {
            colordic = new Dictionary<string, Color>();

            colordic.Add("Red", Color.Red);
            colordic.Add("Blue", Color.Blue);
            colordic.Add("Green", Color.Green);
            colordic.Add("White", Color.White);
            colordic.Add("Black", Color.Black);

        }

        
        public Dictionary<string, Color> GetColor()
        {
            return colordic;
        }

        //public void AddColor(string colorname, Color colorToAdd)
        //{
        //    colordic.Add(colorname, colorToAdd);
        //}
    }


}
