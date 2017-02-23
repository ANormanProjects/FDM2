﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClassQuestion2
{
    public class PositionFactory2b
    {
        public Position GetPosition(int id)
        {
            Position position = null;

            //Get Values from AppSettings in app.config file.
            string[] managerKeys = ConfigurationManager.AppSettings["Manager"].Split(',');
            string[] clerkKeys = ConfigurationManager.AppSettings["Clerk"].Split(',');
            string[] programmerKeys = ConfigurationManager.AppSettings["Programmer"].Split(',');

            //Convert resulting string arrays to int arrays.
            int[] managerIDs = Array.ConvertAll(managerKeys, Int32.Parse);
            int[] clerkIDs = Array.ConvertAll(clerkKeys, Int32.Parse);
            int[] programmerIDs = Array.ConvertAll(programmerKeys, Int32.Parse);

            if ( managerIDs.Contains(id) )
            {
                position = new Manager();
            }
            else if ( clerkIDs.Contains(id) )
            {
                position = new Clerk();
            }
            else if ( programmerIDs.Contains(id) )
            {
                position = new Programmer();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return position;
        }
    }
}