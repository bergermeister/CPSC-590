using System;
using System.Windows.Forms;
using System.Threading;

namespace MutexTest
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void voBtnTest_Click( object aoSender, EventArgs aoArgs )
      {
         bool  kbReqCreation = true; // To request creation of a mutex
         bool  kbAlreadyExists;      // If a mutex already exists
         int   kiId = System.AppDomain.GetCurrentThreadId( );
         Mutex koM = new Mutex( kbReqCreation, "MyMutex", out kbAlreadyExists );

         // Check to see if the mutex is owned by this thread
         if( !( kbReqCreation && kbAlreadyExists ) )
         {
            this.voLbl.Text = "Mutex already exists, waiting on its release..." + kiId.ToString( );
            koM.WaitOne( );
         }

         this.voLbl.Text = "Starting to use the resource, .. mutex owner" + kiId.ToString( );

         // If this is the owner thread, you can use the shared resource
         Thread.Sleep( 10000 );
         // Done usuing this resource
         this.voLbl.Text = "Done using mutex, releasing resource ..." + kiId.ToString( );
         koM.ReleaseMutex( );
      }
   }
}
