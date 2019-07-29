namespace GAWebHost
{
   using System;
   using System.Collections.Generic;
   using System.ServiceModel;
   using GAWebLib;

   public class Distributor : IDistributor, Servant.IWorkerCallback, Servant2.IWorkerCallback
   {
      private double[ ][ ]                 vdDistance;
      private int                          viNumWorkers;
      private List< Habitat > voEcosystem;

      private static Random voRand = new Random( DateTime.Now.Millisecond );
      
      public void MExecute( double[ ][ ] adDistMat, int aiNumWorkers )
      {
         Servant.WorkerClient  koClient1;
         Servant2.WorkerClient koClient2;
         ICallback             koChannel;
         Member[ ]             koBest;

         // TODO: Force workers to 2 for now
         aiNumWorkers = 2;

         try
         {
            Console.WriteLine( "{0} - Distributor: START", DateTime.Now );

            koChannel = OperationContext.Current.GetCallbackChannel< ICallback >( );
         
            /// -# Copy the distance matrix
            this.vdDistance = adDistMat;

            /// -# Setup the Distance Matrix for the workers
            Member.VdDistMatrix = this.vdDistance;
            Worker.VdDistance   = this.vdDistance;

            /// -# Store the number of Workers
            this.viNumWorkers = aiNumWorkers;

            /// -# Create list of best results
            koBest = new Member[ this.viNumWorkers ];

            /// -# Create a list of workers and updated flags
            this.voEcosystem = new List< Habitat >( this.viNumWorkers );

            /// -# Update the Constants
            Constants.NumCities = adDistMat.Length;

            /// -# Initialize Workers
            for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
            {
               this.voEcosystem.Add( new Habitat( new Worker( ) ) );
               this.voEcosystem[ kiI ].VoWorker.MInitialize( Constants.PopSize, 
                                                          Constants.NumCities, 
                                                          Constants.MutationRate, 
                                                          Constants.CrossoverRate, 
                                                          kiI );
            }

            /// -# Distribute the work load
            koClient1 = new Servant.WorkerClient( new InstanceContext( this ), "Worker" );
            koClient2 = new Servant2.WorkerClient( new InstanceContext( this ), "Worker" );
            for( int kiIter = 0; kiIter < Constants.NumIterations; kiIter += Constants.ExchangeAfterIterations )
            {
               /// -# Launch each worker to run ExchangeAfterIterations number of iterations (default:500)
               koClient1.MRun( this.voEcosystem[ 0 ].VoWorker, this.vdDistance, Constants.ExchangeAfterIterations );
               koClient2.MRun( this.voEcosystem[ 1 ].VoWorker, this.vdDistance, Constants.ExchangeAfterIterations );

               /// -# Wait for the workers to complete
               for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
               {
                  while( !this.voEcosystem[ kiI ].VbComplete );
                  this.voEcosystem[ kiI ].VbComplete = false;
                  koBest[ kiI ] = this.voEcosystem[ kiI ].VoWorker.VoBest;
               }

               /// -# Send Update to client
               koChannel.MOnUpdate( koBest );
               Console.WriteLine( "{0} - Distributor: UPDATE", DateTime.Now );

               this.mExchangeBBO( );
               //this.mExchangeData( );       
               for( int kiI = 0; kiI < this.viNumWorkers; kiI++ )
               {
                  this.voEcosystem[ kiI ].VoWorker.MMutatePopulation( );
                  this.voEcosystem[ kiI ].VoWorker.MEvaluatePopulation( );
                  Array.Sort( this.voEcosystem[ kiI ].VoWorker.VoPopulation );
               }
            }

            /// -# Return the best of each worker
            koChannel.MOnComplete( koBest );
            Console.WriteLine( "{0} - Distributor: END", DateTime.Now );
         }
         catch( Exception aoEx )
         {
            Console.WriteLine( aoEx.Message );
         }
      }

      public void MOnComplete( Worker aoWorker )
      {
         Console.WriteLine( "{0} - Distributor: WORKER {1} COMPLETE", DateTime.Now, aoWorker.ViWorkerNum );
         this.voEcosystem[ aoWorker.ViWorkerNum ].VoWorker = ( Worker )aoWorker.Clone( );
         this.voEcosystem[ aoWorker.ViWorkerNum ].VbComplete = true;
      }

      private void mExchangeData( )
      {
         int    kiI, kiW1, kiW2, kiM1, kiM2;
         Member koTemp;

         // Exchange data for each worker
         for( kiI = 0; kiI < this.viNumWorkers; kiI++ )
         {
            kiW1 = ( int )( voRand.NextDouble( ) * this.viNumWorkers );
            kiW2 = ( int )( voRand.NextDouble( ) * this.viNumWorkers );

            if( kiW1 == kiW2 )
            {
               kiW2 = ( int )( voRand.NextDouble( ) * this.viNumWorkers );
            }
             
            kiM1 = 0; 
            kiM2 = 0;
            
            for( int kiJ = 0; kiJ < Constants.NumMembersToExchange; kiJ++ )  // exchange 3 values
            {
               kiM1 = ( int )( voRand.NextDouble( ) * Constants.PopSize );
               kiM2 = ( int )( voRand.NextDouble( ) * Constants.PopSize );
               koTemp = this.voEcosystem[ kiW1 ].VoWorker.VoPopulation[ kiM1 ];
               this.voEcosystem[ kiW1 ].VoWorker.VoPopulation[ kiM1 ] = this.voEcosystem[ kiW2 ].VoWorker.VoPopulation[ kiM2 ];
               this.voEcosystem[ kiW2 ].VoWorker.VoPopulation[ kiM2 ] = koTemp;
            }
         }
      }

      private void mExchangeBBO( )
      {
         double kdTotal = 0.0;
         Member koTemp;
         int    kiMi, kiMj;

         /// -# Calcualte Lambda and Mu
         for( int i = 0; i < this.viNumWorkers; i++ )
         {
            kdTotal += this.voEcosystem[ i ].VoWorker.VoBest.VdFitness;
         }

         for( int i = 0; i < this.viNumWorkers; i++ )
         {
            this.voEcosystem[ i ].VdMu = this.voEcosystem[ i ].VoWorker.VoBest.VdFitness / kdTotal;
            this.voEcosystem[ i ].VdLambda = 1.0 - this.voEcosystem[ i ].VdMu;
         }

         /// -# Select Hi with probability proportional to Lambda
         for( int i = 0; i < this.viNumWorkers; i++ )
         {
            /// -# If Immigrating
            if( voRand.NextDouble( ) > this.voEcosystem[ i ].VdLambda )
            {
               /// -# Select Hj with probability proportional to Mu
               for( int j = 0; j < this.viNumWorkers; j++ )
               {
                  if( ( i != j ) && ( voRand.NextDouble( ) > this.voEcosystem[ i ].VdMu ) )
                  {
                     kiMi = ( int )( voRand.NextDouble( ) * Constants.PopSize );
                     kiMj = ( int )( voRand.NextDouble( ) * Constants.PopSize );

                     /// -# Randomly select an SIV sigma from Hj
                     koTemp = this.voEcosystem[ j ].VoWorker.VoPopulation[ kiMj ];

                     /// -# Replace a random SIV in Hi with sigma
                     this.voEcosystem[ j ].VoWorker.VoPopulation[ kiMj ] = this.voEcosystem[ i ].VoWorker.VoPopulation[ kiMi ];
                     this.voEcosystem[ i ].VoWorker.VoPopulation[ kiMi ] = koTemp;
                  }
               }
            }
         }
      }
   }
}
