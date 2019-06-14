using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelSwarmIntelligence
{
   public partial class Form1 : Form
   {
      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnParallelRosenbrock_Click( object sender, EventArgs e )
      {
         int                    kiNumSwarms = 10;
         int                    kiI;
         Task< SwarmResult >[ ] koTask    = new Task< SwarmResult >[ kiNumSwarms ];
         List< SwarmResult >    koResult  = new List< SwarmResult >( );
         Task                   koFinal;

         for( kiI = 0; kiI < koTask.Length; kiI++ )
         {
            koTask[ kiI ] = Task.Factory.StartNew< SwarmResult >( ( aoContext ) =>
            {
               SwarmResult koRes;
               SwarmSystem koSys = new SwarmSystem( ( int )aoContext );
               koSys.MInitialize( 20, 20 );
               koRes = koSys.MDoPS0( );
               return( koRes );
            }, kiI );
         }

         koFinal = Task.Factory.ContinueWhenAll( koTask, ( aoTask ) =>
         {
            Console.WriteLine( aoTask.Length.ToString( ) + " tasks" );
            for( kiI = 0; kiI < aoTask.Length; kiI++ )
            {
               koResult.Add( aoTask[ kiI ].Result );
            }
         } );

         koFinal.Wait( );
         koResult.Sort( );
         this.voDataGridView.DataSource = koResult;
         this.voDataGridView.Refresh( );
         this.voLblBest.Text = koResult[ 0 ].ToString( );
      }

      private void voBtnSequentialRosenbrock_Click( object sender, EventArgs e )
      {
         SwarmResult koResult;
         SwarmSystem koSys = new SwarmSystem( 0 );
         koSys.MInitialize( 20, 20 );
         koResult = koSys.MDoPS0( );
         this.voLblBest.Text = koResult.ToString( );
      }

      private void voBtnParallelHimmelblau_Click( object sender, EventArgs e )
      {
         int                    kiNumSwarms = 80;
         int                    kiI;
         Task< SwarmResult >[ ] koTask    = new Task< SwarmResult >[ kiNumSwarms ];
         List< SwarmResult >    koResult  = new List< SwarmResult >( );
         List< SwarmResult >    koUnique = new List< SwarmResult >( );
         Task                   koFinal;

         for( kiI = 0; kiI < koTask.Length; kiI++ )
         {
            koTask[ kiI ] = Task.Factory.StartNew< SwarmResult >( ( aoContext ) =>
            {
               SwarmResult koRes;
               SwarmSystem koSys = new SwarmSystem( ( int )aoContext );
               koSys.MInitialize( 6, 6 );
               koRes = koSys.MDoHimmelblau( );
               return( koRes );
            }, kiI );
         }

         koFinal = Task.Factory.ContinueWhenAll( koTask, ( aoTask ) =>
         {
            Console.WriteLine( aoTask.Length.ToString( ) + " tasks" );
            for( kiI = 0; kiI < aoTask.Length; kiI++ )
            {
               koResult.Add( aoTask[ kiI ].Result );
            }
         } );

         koFinal.Wait( );
         koResult.Sort( );
         koUnique.Add( koResult[ 0 ] );
         foreach( SwarmResult koSwarm in koResult )
         {
            bool kbUnique = true;
            foreach( SwarmResult koUSwarm in koUnique )
            {
               if( koUSwarm.VdValue > 0.5 )
               {
                  kbUnique = false;
               }
               else 
               {
                  double kdDist = Math.Sqrt( ( koSwarm.VdX - koUSwarm.VdX ) * ( koSwarm.VdX - koUSwarm.VdX ) + ( koSwarm.VdY - koUSwarm.VdY ) * ( koSwarm.VdY - koUSwarm.VdY ) );
                  if( kdDist < 1.00000001 )
                  {
                     kbUnique = false;
                  }
               }
            }
            if( kbUnique )
            {
               koUnique.Add( koSwarm );
            }
         }
         this.voDataGridView.DataSource = koUnique; // koResult;
         this.voDataGridView.Refresh( );
         this.voLblBest.Text = koResult[ 0 ].ToString( );
      }
   }
}
