using System;
using System.Threading;

namespace ReaderWriterLockExample
{
   class TcWorker
   {
      private static ReaderWriterLock voRWL = new ReaderWriterLock( );

      static int    viResource = 0;
      static int    viTOReader = 0;
      static int    viTOWriter = 0;
      static int    viReads    = 0;
      static int    viWrites   = 0;
      static bool   vbRunning  = true;
      static Random voRand     = new Random( );
      
      private ManualResetEvent voMR;
      private int              viID;

      public TcWorker( ManualResetEvent aoMR )
      {
         this.voMR = aoMR;
      }

      public int ViID
      {
         get{ return( this.viID ); }
      }

      public static bool VbRunning
      {
         set{ vbRunning = value; }
      }

      public void MHandle( object aoContext )
      {
         double kdAction;

         this.viID = ( int )aoContext;

         while( vbRunning )
         {
            kdAction = voRand.NextDouble( );
            if( kdAction < 0.8 )
            {
               this.MRead( 10 );
            }
            else if( kdAction < 0.81 )
            {
               this.MRelease( 50 );
            }
            else if( kdAction < 0.90 )
            {
               this.MUpgrade( 100 );
            }
            else
            {
               this.MWrite( 50 );
            }
         }

         this.voMR.Set( );
      }

      /**
       * @brief
       * Request and release a reader lock, and handle time-outs
       */
      public void MRead( int aiTimeout )
      {
         try
         {
            /// -# Request reader lock
            voRWL.AcquireReaderLock( aiTimeout );
            try 
            {
               /// -# Read from the shared resource.
               this.MDisplay( "Read: " + viResource.ToString( ) );
               Interlocked.Increment( ref viReads );
            }
            finally
            {
               /// -# Ensure that the lock is released.
               voRWL.ReleaseReaderLock( );
            }
         }
         catch( ApplicationException ) 
         {
            /// -# The reader lock request timed out.
            Interlocked.Increment( ref viTOReader );
         }
      }

      /**
       * @brief 
       * Requests and releases the writer lock, and handle time-outs.
       */
      public void MWrite( int aiTimeout )
      {
         try
         {
            /// -# Request writer lock
            voRWL.AcquireWriterLock( aiTimeout );
            try 
            {
               /// -# Write to the shared resource
               viResource = voRand.Next( 500 );
               this.MDisplay( "Wrote: " + viResource.ToString( ) );
               Interlocked.Increment( ref viWrites );
            }
            finally 
            {
               /// -# Ensure that the lock is released.
               voRWL.ReleaseWriterLock( );
            }
         }
         catch( ApplicationException )
         {
            /// -# The writer lock request timed out.
            Interlocked.Increment( ref viTOWriter );
         }
      }

      /**
       * @brief
       * Requests a reader lock, upgrades the reader lock to the writer lock, 
       * and downgrades it to a reader lock again.
       */
      public void MUpgrade( int aiTimeout )
      {
         LockCookie koLC;

         try 
         {
            /// -# Request reader lock
            voRWL.AcquireReaderLock( aiTimeout );
            try 
            {
               /// -# Read from the shared resource
               this.MDisplay( "Read: " + viResource.ToString( ) );
               Interlocked.Increment( ref viReads );

               // To write to the resource, either release the reader lock and
               // request the writer lock, or upgrade the reader lock. Upgrading
               // the reader lock puts the thread in the write queue, behind any
               // other threads that might be waiting for the writer lock.
               try
               {
                  /// -# Upgrade to writer lock
                  koLC = voRWL.UpgradeToWriterLock( aiTimeout );
                  try 
                  {
                     /// -# Write to resource
                     viResource = voRand.Next( 500 );
                     this.MDisplay( "Wrote: " + viResource.ToString( ) );
                     Interlocked.Increment( ref viWrites );
                  }
                  finally 
                  {
                     /// -# Ensure that the writer lock is released.
                     voRWL.DowngradeFromWriterLock( ref koLC );
                  }
               }
               catch( ApplicationException )
               {
                  /// -# The upgrade request timed out.
                  Interlocked.Increment( ref viTOWriter );
               }

               /// -# Read from resource
               this.MDisplay( "Read: " + viResource.ToString( ) );
               Interlocked.Increment( ref viReads );
            }
            finally 
            {
               /// -# Ensure that the lock is released.
               voRWL.ReleaseReaderLock();
            }
         }
         catch( ApplicationException )
         {
            /// -# The reader lock request timed out.
            Interlocked.Increment( ref viTOReader );
         }
      }

      /**
       * @brief
       * Release all locks and later restores the lock state. Uses sequence numbers to determine
       * whether another thread has obtained a writer lock since this thread last accessed the 
       * resource.
       */
      public void MRelease( int aiTimeout )
      {
         int        kiLastWriter;
         int        kiResource;
         LockCookie koLC;

         try 
         {
            /// -# Request reader lock
            voRWL.AcquireReaderLock( aiTimeout );
            try 
            {
               /// -# Read and cache resource value
               kiResource = viResource;
               this.MDisplay( "Read: " + kiResource.ToString( ) );
               Interlocked.Increment( ref viReads );

               /// -# Save the current writer sequence number.
               kiLastWriter = voRWL.WriterSeqNum;

               /// -# Release the lock and save a cookie so the lock can be restored later.
               koLC = voRWL.ReleaseLock( );

               /// -# Wait for a random interval and then restore the previous state of the lock.
               Thread.Sleep( voRand.Next( 250 ) );
               voRWL.RestoreLock( ref koLC );

               /// -# Check whether other threads obtained the writer lock in the interval.
               ///    If not, then the cached value of the resource is still valid.
               if( voRWL.AnyWritersSince( kiLastWriter ) )
               {
                  kiResource = viResource;
                  Interlocked.Increment( ref viReads );
                  this.MDisplay( "Change: " + kiResource );
               }
               else 
               {
                  this.MDisplay( "Change: None" );
               }
            }
            finally 
            {
               /// -# Ensure that the lock is released.
               voRWL.ReleaseReaderLock( );
            }
         }
         catch( ApplicationException )
         {
            /// -# The reader lock request timed out.
            Interlocked.Increment( ref viTOReader );
         }
      }

      /**
       * @brief
       * Helper method briefly displays the most recent thread action.
       */
      public void MDisplay( string aoMsg )
      {
         Console.WriteLine( "{0} | {1} | {2}.", Thread.CurrentThread.Name, this.viID, aoMsg );
      }

      public static void MResults( )
      {
         Console.WriteLine( "Reads: {0} | Writes: {1} | Reader Time-outs: {2} | Writer Time-outs: {3}",
                            viReads, viWrites, viTOReader, viTOWriter );
      }
   }
}
