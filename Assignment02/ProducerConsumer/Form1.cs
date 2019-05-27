using System;
using System.Windows.Forms;
using System.Threading;

namespace ProducerConsumer
{
   public partial class Form1 : Form
   {
      private delegate void ToDisplay( string aoMsg );

      private Thread           voConsumer;
      private Thread           voProducer;
      private Thread           voConsumerMR;
      private Thread           voProducerMR;
      private object           voLock = new object( );
      private bool             vbDataReady = false;
      private int              viData = 0;
      private ToDisplay        voDel = null;
      private ManualResetEvent voMR = new ManualResetEvent( false );

      public Form1( )
      {
         InitializeComponent();

         this.voDel = new ToDisplay( mDisplayStatus ); 
      }

      private void voBtnConsumerStart_Click(object sender, EventArgs e)
      {
         this.voConsumer = new Thread( new ThreadStart( this.mConsumer ) );
         this.voConsumer.Start( );
      }

      private void voBtnProducerStart_Click(object sender, EventArgs e)
      {
         this.voProducer = new Thread( new ThreadStart( this.mProducer ) );
         this.voProducer.Start( );
      }

      private void voBtnConsumerMR_Click(object sender, EventArgs e)
      {
         this.voConsumerMR = new Thread( new ThreadStart( this.mConsumerMR ) );
         this.voConsumerMR.Start( );
      }

      private void voBtnProducerMR_Click(object sender, EventArgs e)
      {
         this.voProducerMR = new Thread( new ThreadStart( this.mProducerMR ) );
         this.voProducerMR.Start( );
      }

      private void mDisplayStatus( string aoMsg )
      {
         this.voLabel.Text = aoMsg;
      }

      private void mConsumer( )
      {
         for( int kiI = 0; kiI < 2; kiI++ )
         {
            this.voStatus.Invoke( this.voDel, new string[ ]{ "Consumer thread started.." } );
            if( this.vbDataReady == false )
            {
               lock( this.voLock )
               {
                  Monitor.Wait( this.voLock );
               }
               // Monitor.Wait and Monitor.Pulse are required to be inside the same lock
               // they are testing
            }
            Thread.Sleep( 1000 );
            this.voStatus.Invoke( this.voDel, new string[ ]{ "Starting to consume data.." } );
            lock( this.voLock )
            {
               this.viData -= 2000;
               this.vbDataReady = false;
            }
            Thread.Sleep( 4000 ); // Pretend it takes 4 seconds to consume data
            this.voStatus.Invoke( this.voDel, new string[ ]{ "Data consumed: data = " + this.viData.ToString( ) } );
         }
      }

      private void mProducer( )
      {
         this.voStatus.Invoke( this.voDel, new string[ ]{ "Producer started.." } );
         Thread.Sleep( 9000 );   // 9 secs to produce data
         lock( this.voLock )
         {
            this.viData = 2375;
            this.vbDataReady = true;
         }
         lock( this.voLock )
         {
            Monitor.Pulse( this.voLock ); // Signal waiting thread
         }
      }

      private void mConsumerMR( )
      {
         // Use ManualResetEvent for synchronization
         for( int kiI = 0; kiI < 2; kiI++ )
         {
            this.voStatus.Invoke( this.voDel, new string[ ]{ "Consumer thread started.." } );
            if( this.vbDataReady == false )
            {
               this.voMR.WaitOne( );   // Wait for producer
               this.voMR.Reset( );     // Close the gate
            }
            Thread.Sleep( 1000 );
            this.voStatus.Invoke( this.voDel, new string[ ]{ "Starting to consume data.." } );
            lock( this.voLock )
            {
               this.viData -= 2000;
               this.vbDataReady = false;
            }
            Thread.Sleep( 4000 ); // Pretend it takes 4 seconds to consume data
            this.voStatus.Invoke( this.voDel, new string[ ]{ "Data consumed: data = " + this.viData.ToString( ) } );
         }
      }

      private void mProducerMR( )
      {
         this.voStatus.Invoke( this.voDel, new string[ ]{ "Producer started.." } );
         Thread.Sleep( 9000 );   // 9 seconds to produce data
         lock( this.voLock )
         {
            this.viData = 2375;
            this.vbDataReady = true;
         }
         this.voMR.Set( ); // Send signal to waiting thread;
      }
   }
}
