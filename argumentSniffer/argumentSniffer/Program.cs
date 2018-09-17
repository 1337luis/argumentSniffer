using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argumentSniffer
{
    class Program
    {
        static void Main( string[] args )
        {
            //ADDS TO THE FIRST ARGUMENT THE NAME OF THE EXE AND A SPACE
            String arguments = System.AppDomain.CurrentDomain.FriendlyName + " ";

            //ADDS ALL EACH OTHER ARGUMENTS TO THE VARIABLE
            foreach( String argument in args )
            {
                arguments += format( argument ) + " "; //IF DETECTS ANY SPACE IN A SINGLE ARGUMENT, ADDS '"' TO IT
            }
            Console.WriteLine( arguments );
            save( arguments ); //SAVE THE FILE
        }

        static String format( String arg )
        {
            bool returnCom = false;
            String result = "";

            foreach( Char c in arg )
            {
                if( c == ' ' ) returnCom = true;
            }

            if( returnCom )
            {
                result = "\"" + arg + "\"";
            }
            else
            {
                result = arg;
            }

            return result;
        }
        static void save( String arg )
        {
            //NAMING AND SAVING THE SCRIPT
            System.IO.File.WriteAllText( 
                "launcher_" + 
                DateTime.Now.Day + "_" + 
                DateTime.Now.Hour + 
                DateTime.Now.Minute + 
                DateTime.Now.Second +
                ".bat", "@echo off\r\n" + arg );
        }
    }
}
