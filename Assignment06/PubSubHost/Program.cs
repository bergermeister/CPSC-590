using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubHost
{
   class Program
   {
      static void Main( string[ ] args )
      {
         try             
         {                 
            ServiceHost sh = new ServiceHost(typeof(PubSubLib.PubSub));                 
            Console.WriteLine("Pub Sub Service Ready, Listening on 7060");                 
            Console.WriteLine("Hit Enter to Stop..");                 
            sh.Open();                 
            Console.ReadLine();             
         }             
         catch (Exception ex)          
         {             
            Console.WriteLine(ex.Message);    
         } 
      }
   }
}
