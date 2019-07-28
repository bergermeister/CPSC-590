namespace GAWebServant2
{
   using System;
   using System.ServiceModel;

   [ServiceBehavior( InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple ) ]
   public class Worker : IWorker
   {
      public void MRun( GAWebLib.Worker aoWorker, double[ ][ ] adDistMat, int aiIterations )
      {
         ICallback koChannel;

         try
         {
            Console.WriteLine( "{0} - Worker {1}: START", DateTime.Now, aoWorker.ViWorkerNum );

            /// -# Instantiate the callback channel
            koChannel = OperationContext.Current.GetCallbackChannel< ICallback >( );

            /// -# Setup the Distance Matrix
            GAWebLib.Member.VdDistMatrix = adDistMat;
            GAWebLib.Worker.VdDistance   = adDistMat;

            /// -# Run the Worker instance
            aoWorker.MRun( aiIterations );

            /// -# Issue callback
            koChannel.MOnComplete( aoWorker );

            Console.WriteLine( "{0} - Worker {1}: END", DateTime.Now, aoWorker.ViWorkerNum );
         }
         catch( Exception aoEx )
         {
            Console.WriteLine( aoEx.Message );         
         }
      }
   }
}
