namespace GASvcLib
{
   namespace Host
   {
      using System.Collections.Generic;
      using System.ServiceModel;
      using System.Threading.Tasks;

      public class Distributor : IDistributor, ICallback
      {
         private int[ ][ ] viDistance;
         private int       viNumWorkers;
      
         public void MExecute( int[ ][ ] aiDistMat, int aiNumWorkers )
         {
            
            //List< Servant.WorkerClient > koProxy;

            /// -# Update the Constants
            Constants.NumCities = aiDistMat.Length;

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
            //koProxy = new List< Servant.WorkerClient >( this.viNumWorkers );
            //for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
            //{
            //   koProxy.Add( new Servant.WorkerClient( ) );
            //   koProxy[ kiI ].MInitialize( Constants.PopSize, Constants.NumCities, Constants.MutationRate, Constants.CrossoverRate,
            //                               this.viDistance, kiI ); 
            //}

            for( int kiIter = 0; kiIter < Constants.NumIterations; kiIter += Constants.ExchangeAfterIterations )
            {
               /// -# Launch each worker to run ExchangeAfterIterations number of iterations (default:500)
               for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
               {
                  //koProxy[ kiI ].MRun( Constants.ExchangeAfterIterations );
               }

               // TODO: Exchange
            }
         }

         public void MUpdateResult( Member aoMember )
         {
            throw new System.NotImplementedException( );
         }
      }
   }
}
