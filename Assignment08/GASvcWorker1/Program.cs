namespace GASvcWorker1
{
   using System;
   using System.ServiceModel;

   class Program
   {
      static void Main( string[ ] koArgs )
      {
         ServiceHost koSH;

         try             
         {                 
            koSH = new ServiceHost( typeof( GASvcLib.Servant.Worker ) );                 
            Console.WriteLine( "Genetic Algorithm Worker 1 Service Ready, Listening on 7061" );
            Console.WriteLine( "Hit Enter to Stop.." );
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
