namespace GAWebHost
{
   using System;
   using System.Collections.Generic;
   using System.ServiceModel;
   using System.Threading.Tasks;
   using GAWebLib;

   public class Distributor : IDistributor, Servant.IWorkerCallback
   {
      private int[ ][ ]                    viDistance;
      private int                          viNumWorkers;
      private List< Pair< Worker, bool > > voWorkers;
      
      public void MExecute( int[ ][ ] aiDistMat, int aiNumWorkers )
      {
         Servant.WorkerClient koClient;
         ICallback            koChannel;
         Member[ ]            koBest;

         try
         {
            koChannel = OperationContext.Current.GetCallbackChannel< ICallback >( );
         
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

            /// -# Create list of best results
            koBest = new Member[ this.viNumWorkers ];

            /// -# Create a list of workers and updated flags
            this.voWorkers = new List< Pair< Worker, bool > >( this.viNumWorkers );

            /// -# Update the Constants
            Constants.NumCities = aiDistMat.Length;
         
            /// -# Initialize Workers
            Parallel.For( 0, this.viNumWorkers, ( kiI ) =>
            {
               this.voWorkers[ kiI ] = new Pair< Worker, bool >( new Worker( ), false );
               this.voWorkers[ kiI ].VoItem1.MInitialize( Constants.PopSize, Constants.NumCities, 
                                                          Constants.MutationRate, Constants.CrossoverRate,
                                                          this.viDistance, kiI );
            } );

            /// -# Distribute the work load
            for( int kiIter = 0; kiIter < Constants.NumIterations; kiIter += Constants.ExchangeAfterIterations )
            {
               /// -# Launch each worker to run ExchangeAfterIterations number of iterations (default:500)
               for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
               {
                  koClient = new Servant.WorkerClient( new InstanceContext( this ), "Worker" );
                  koClient.MRun( this.voWorkers[ kiI ].VoItem1, Constants.ExchangeAfterIterations );
               }

               /// -# Wait for the workers to complete
               for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
               {
                  while( !this.voWorkers[ kiI ].VoItem2 );
                  this.voWorkers[ kiI ].VoItem2 = false;
                  koBest[ kiI ] = this.voWorkers[ kiI ].VoItem1.voBest;
               }

               /// -# Send Update to client
               koChannel.MOnUpdate( koBest );

               this.mExchangeData( );            
            }

            /// -# Return the best of each worker
            koChannel.MOnComplete( koBest );
         }
         catch( Exception aoEx )
         {
            Console.WriteLine( aoEx.Message );
         }
      }

      public void MOnComplete( Worker aoWorker )
      {
         this.voWorkers[ aoWorker.viWorkerNum ].VoItem1 = aoWorker;
         this.voWorkers[ aoWorker.viWorkerNum ].VoItem2 = true;
      }

      private void mExchangeData( )
      {
         int    kiI, kiW1, kiW2, kiM1, kiM2;
         Random koRand = new Random( DateTime.Now.Millisecond );
         Member koTemp;

         // Exchange data for each worker
         for( kiI = 0; kiI < this.viNumWorkers; kiI++ )
         {
            kiW1 = ( int )( koRand.NextDouble( ) * this.viNumWorkers );
            kiW2 = ( int )( koRand.NextDouble( ) * this.viNumWorkers );

            if( kiW1 == kiW2 )
            {
               kiW2 = ( int )( koRand.NextDouble( ) * this.viNumWorkers );
            }
             
            kiM1 = 0; 
            kiM2 = 0;
            
            for( int kiJ = 0; kiJ < Constants.NumMembersToExchange; kiJ++ )  // exchange 3 values
            {
               kiM1 = ( int )( koRand.NextDouble( ) * Constants.PopSize );
               kiM2 = ( int )( koRand.NextDouble( ) * Constants.PopSize );
               koTemp = this.voWorkers[ kiW1 ].VoItem1.voPopulation[ kiM1 ];
               this.voWorkers[ kiW1 ].VoItem1.voPopulation[ kiM1 ] = this.voWorkers[ kiW2 ].VoItem1.voPopulation[ kiM2 ];
               this.voWorkers[ kiW2 ].VoItem1.voPopulation[ kiM2 ] = koTemp;
            }
         }
      }
   }
}
