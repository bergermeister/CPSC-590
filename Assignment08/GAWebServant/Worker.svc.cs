namespace GAWebServant
{
   using System;
   using System.ServiceModel;

   [ServiceBehavior( InstanceContextMode = InstanceContextMode.PerCall )]
   public class Worker : IWorker
   {
      public void MRun( GAWebLib.Worker aoWorker, int aiIterations )
      {
         ICallback koChannel;

         try
         {
            koChannel = OperationContext.Current.GetCallbackChannel< ICallback >( );
            aoWorker.MRun( aiIterations );
            koChannel.MOnComplete( aoWorker );
         }
         catch( Exception aoEx )
         {
            Console.WriteLine( aoEx.Message );         
         }
      }
   }
}
