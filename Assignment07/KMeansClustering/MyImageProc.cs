using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KMeansClustering
{
   public class MyImageProc
   {
      public static bool MDrawX( Graphics aoG, Point aoPt1 )
      {
         Brush koBr = new SolidBrush( Color.Red );
         Point koP1 = new Point( aoPt1.X - 4, aoPt1.Y - 4 );
         Point koP2 = new Point( aoPt1.X + 4, aoPt1.Y + 4 );
         Point koP3 = new Point( aoPt1.X + 4, aoPt1.Y - 4 );
         Point koP4 = new Point( aoPt1.X - 4, aoPt1.Y + 4 );

         aoG.DrawLine( new Pen( Color.Red, 2 ), koP1, koP2 );
         aoG.DrawLine( new Pen( Color.Red, 2 ), koP3, koP4 );

         return( true );
      }

      public static bool MDrawClusters( PictureBox aoPB, List< MyPoint > aoPList, double adScale, int aiClusterCount )
      {
         Graphics koG = aoPB.CreateGraphics( );
         Color[ ] koCColors = new Color[ aiClusterCount ];
         Brush    koBr = new SolidBrush( Color.Red );
         Point    koP1, koP2;
         Point    koP1a, koP2a, koP3a, koP4a;
         Point    koPStart;
         
         koG.Clear( Color.White );             
         
         // set cluster colors             
         for( int kiI = 0; kiI < aiClusterCount; kiI++ )
         {
            switch( kiI )
            {
            case 0:  koCColors[ kiI ] = Color.Red;                break;
            case 1:  koCColors[ kiI ] = Color.Green;              break;
            case 2:  koCColors[ kiI ] = Color.Purple;             break;
            case 3:  koCColors[ kiI ] = Color.Aqua;               break;
            case 4:  koCColors[ kiI ] = Color.Black;              break;
            case 5:  koCColors[ kiI ] = Color.Orange;             break;
            case 6:  koCColors[ kiI ] = Color.Salmon;             break;    
            case 7:  koCColors[ kiI ] = Color.Yellow;             break;    
            case 8:  koCColors[ kiI ] = Color.Pink;               break;  
            case 9:  koCColors[ kiI ] = Color.LightBlue;          break;       
            case 10: koCColors[ kiI ] = Color.Lavender;           break;      
            case 11: koCColors[ kiI ] = Color.LightGreen;         break;        
            case 12: koCColors[ kiI ] = Color.LightSeaGreen;      break;           
            case 13: koCColors[ kiI ] = Color.LightSteelBlue;     break;            
            case 14: koCColors[ kiI ] = Color.Lime;               break;  
            case 15: koCColors[ kiI ] = Color.Magenta;            break;     
            case 16: koCColors[ kiI ] = Color.MediumAquamarine;   break;
            case 17: koCColors[ kiI ] = Color.PaleVioletRed;      break;
            case 18: koCColors[ kiI ] = Color.Firebrick;          break;
            case 19: koCColors[ kiI ] = Color.DodgerBlue;         break;
            case 20: koCColors[ kiI ] = Color.HotPink;            break;
            case 21: koCColors[ kiI ] = Color.Orchid;             break;
            case 22: koCColors[ kiI ] = Color.Sienna;             break;
            case 23: koCColors[ kiI ] = Color.Turquoise;          break;
            case 24: koCColors[ kiI ] = Color.YellowGreen;        break;
            case 25: koCColors[ kiI ] = Color.Tomato;             break;
            case 26: koCColors[ kiI ] = Color.Indigo;             break;
            case 27: koCColors[ kiI ] = Color.PaleVioletRed;      break;
            case 28: koCColors[ kiI ] = Color.Peru;               break;
            case 29: koCColors[ kiI ] = Color.Plum;               break;
            default:
               if( ( kiI % 2 ) == 0 ) koCColors[ kiI ] = Color.FromArgb( 255, 180 - ( kiI * 2), 100 + ( kiI * 2 ) );                 
               else                   koCColors[ kiI ] = Color.FromArgb( 100 + kiI * 2, 180 - ( kiI * 2 ), 255 );
               break; 
            }
         }
            
         koP1  = new Point { X = ( int )aoPList[ 0 ].VdX, Y = ( int )aoPList[ 0 ].VdY };
         koP1a = new Point( ( int )( koP1.X * adScale ) - 2, ( int )( koP1.Y * adScale ) - 2 ); 
         koP2a = new Point( ( int )( koP1.X * adScale ) + 2, ( int )( koP1.Y * adScale ) + 2 );         
         koP3a = new Point( ( int )( koP1.X * adScale ) + 2, ( int )( koP1.Y * adScale ) - 2 );    
         koP4a = new Point( ( int )( koP1.X * adScale ) - 2, ( int )( koP1.Y * adScale ) + 2 );  
         koG.DrawLine( new Pen( koCColors[ aoPList[ 0 ].ViClusterId ], 1 ), koP1a, koP2a );     
         koG.DrawLine( new Pen( koCColors[ aoPList[ 0 ].ViClusterId ], 1 ), koP3a, koP4a );        

         koPStart = new Point( koP1.X, koP1.Y );       
         for ( int kiI = 1; kiI < aoPList.Count; kiI++ )           
         {                
            koP2 = new Point { X = ( int )aoPList[ kiI ].VdX, Y = ( int )aoPList[ kiI ].VdY };     
            koP1a = new Point( ( int )( koP2.X * adScale ) - 2, ( int )( koP2.Y * adScale ) - 2 );   
            koP2a = new Point( ( int )( koP2.X * adScale ) + 2, ( int )( koP2.Y * adScale ) + 2 );   
            koP3a = new Point( ( int )( koP2.X * adScale ) + 2, ( int )( koP2.Y * adScale ) - 2 );   
            koP4a = new Point( ( int )( koP2.X * adScale ) - 2, ( int )( koP2.Y * adScale ) + 2 );               
            koG.DrawLine( new Pen( koCColors[ aoPList[ kiI ].ViClusterId ], 1 ), koP1a, koP2a );                     
            koG.DrawLine( new Pen( koCColors[ aoPList[ kiI ].ViClusterId ] ), koP3a, koP4a );             
         }             
            
         return( true );       
      }
   }
}
