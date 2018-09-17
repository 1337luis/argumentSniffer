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
            String arguments = System.AppDomain.CurrentDomain.FriendlyName + " ";

            foreach( String argument in args )
            {
                arguments += format( argument ) + " ";
            }
            Console.WriteLine( arguments );
            save( arguments );
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
