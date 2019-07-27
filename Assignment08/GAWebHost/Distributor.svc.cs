namespace GAWebHost
{
   using System.Collections.Generic;
   using System.ServiceModel;
   using System.Threading.Tasks;
   using GAWebLib;

   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Distributor" in code, svc and config file together.
   // NOTE: In order to launch WCF Test Client for testing this service, please select Distributor.svc or Distributor.svc.cs at the Solution Explorer and start debugging.
   public class Distributor : IDistributor
   {
      private int[ ][ ]                         viDistance;
      private int                               viNumWorkers;
      private List< GAWebServant.WorkerClient > voProxy;
      
      public void MExecute( int[ ][ ] aiDistMat, int aiNumWorkers )
      {
         /// -# Copy the distance matrix
         this.viDistance = new int[ aiDistMat.Length ][ ];
         Parallel.For( 0, aiDistMat.Length, ( i ) =>
         {
            this.viDistance[ i ] = new int[ aiDistMat[ i ].Length ];
            for( int j = 0; j < aiDistMat[ i ].Length; j++ )
            {
               this.viDistance[ i ][ j ] = aiDistMat[ i ][ j ];
            }
         } );

         /// -# Store the number of Workers
         this.viNumWorkers = aiNumWorkers;

         /// -# Create a proxy for each worker
         for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
         {
            this.voProxy.Add( new GAWebServant.WorkerClient( ) );
            this.voProxy[ kiI ].MInitialize( Constants.PopSize, Constants.NumCities, Constants.MutationRate, Constants.CrossoverRate,
                                             this.viDistance, kiI ); 
         }
         /*
         ICallback aoCallBackChannel = OperationContext.Current.GetCallbackChannel< ICallback >( );
         if( ( ( ICommunicationObject )aoCallBackChannel ).State == CommunicationState.Opened )
         {
            aoCallBackChannel.MUpdateResult( new GAWebLib.Member( 200, this.viDistance ) );
         }
         */
      }
   }
}
