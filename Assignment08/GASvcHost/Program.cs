using System;
using System.ServiceModel;

namespace GASvcHost
{
   class Program
   {
      static void Main( string[ ] koArgs )
      {
         try
         {
            ServiceHost koSH = new ServiceHost( typeof( GASvcLib.GASvc ) );
            Console.WriteLine( "Genetic Algorithm Service Ready, Listening on 7060" );
            Console.WriteLine( "Hit Enter to Stop..." );
            koSH.Open( );
            Console.ReadLine( );
         }
         catch( Exception aoEx )
         {
            Console.WriteLine( aoEx.Message );
         }
      }
   }
}
