using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using System.Configuration;

namespace TSGAMT2010
{
    public partial class Form1 : Form
    {
        TSGA ga;
        bool deserialized = false;

        GAMember bestMember;
        Thread tga;

        //-----------for the multithreaded version----------
        int numThreads = 1;
        TSGA[] GAs;
        Thread[] TGAs;
        object lockobj = new object();
        object[] synchObjsB;
        object[] synchObjsA;
        Thread thXchg;
        int[] dataready;
        int[] xchgdone;
        //--------------------------------------------------

        int[,] DistMat =
			{
				{0, 20, 25, 15, 45, 32 },
				{20, 0, 35, 17, 28, 39 },
				{25, 35, 0, 45, 35, 22 },
				{15, 17, 45, 0, 15, 42 },
				{45, 28, 35, 15, 0, 52 },
				{32, 39, 22, 42, 52, 0 }
			};

        private bool bcapture = false;
        Bitmap bMap;
        Bitmap bOrigMap;
        ArrayList PointsList = new ArrayList();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRunGA.Enabled = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            lblBestResult.Visible = true;
            lblBestResult0.Visible = false;
            lblBestResult1.Visible = false;
            lblBestResult2.Visible = false;
            lblBestResult3.Visible = false;
            grpGASettings.Visible = true;
            grpThreads.Visible = false;
            grpGASettings.Visible = true;

            try
            {
                // read the application configuration file and initialize constants
                picMap.Image = Image.FromFile(@"usmap.jpg");
                bMap = new Bitmap(picMap.Image);
                bOrigMap = new Bitmap(picMap.Image);

                TSGAConstants.CrossoverRate = (float)(float.Parse(ConfigurationManager.AppSettings["CrossoverRate"]));
                TSGAConstants.MutationRate = (float)(float.Parse(ConfigurationManager.AppSettings["MutationRate"]));
                TSGAConstants.PopSize = int.Parse(ConfigurationManager.AppSettings["PopSize"]);
                TSGAConstants.NumIterations = int.Parse(ConfigurationManager.AppSettings["NumIterations"]);
                TSGAConstants.NumCities = int.Parse(ConfigurationManager.AppSettings["NumCities"]);

                txtMutationRate.Text = TSGAConstants.MutationRate.ToString();
                txtCrossOverRate.Text = TSGAConstants.CrossoverRate.ToString();
                lblNumCities.Text = TSGAConstants.NumCities.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            bcapture = true;
            timer1.Enabled = false;
            picMap.Image = bOrigMap;
            bMap = new Bitmap(bOrigMap);
            PointsList.Clear();
        }

        private void btnEndCapture_Click(object sender, EventArgs e)
        {
            bcapture = false;
            btnRunGA.Enabled = true;
            timer1.Enabled = false;
            Bitmap b1 = new Bitmap(bOrigMap);
            MyImageProc.DrawTour(b1, ref b1, PointsList);
            picMap.Image = b1;
            TSGAConstants.NumCities = PointsList.Count;
            lblNumCities.Text = TSGAConstants.NumCities.ToString();
            TSGAConstants.MutationRate = float.Parse(txtMutationRate.Text);
            TSGAConstants.CrossoverRate = float.Parse(txtCrossOverRate.Text);


            if (deserialized == false)
            {
                //-------------now compute the distance matrix---
                DistMat = new int[PointsList.Count, PointsList.Count];
                int dX = 0;
                int dY = 0;
                int dist;
                for (int i = 0; i < PointsList.Count; i++)
                    for (int j = i; j < PointsList.Count; j++)
                    {
                        if (i == j)
                            DistMat[i, j] = 0;
                        else
                        {
                            dX = Math.Abs(((Point)PointsList[i]).X - ((Point)PointsList[j]).X);
                            dY = Math.Abs(((Point)PointsList[i]).Y - ((Point)PointsList[j]).Y);
                            dist = (int)(Math.Sqrt(dX * dX + dY * dY));
                            DistMat[i, j] = dist;
                            DistMat[j, i] = dist;
                        }
                    }
            }
				
        }

        private void btnRunGA_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Starting GA for TSP";
            //	ReadDistMat();
            ga = new TSGA(TSGAConstants.PopSize, TSGAConstants.NumCities,
                TSGAConstants.MutationRate, TSGAConstants.CrossoverRate, DistMat, ref lockobj);
            tga = new Thread(new ThreadStart(ga.RunGA));
            timer1.Enabled = true;
            tga.Start();
            btnRunGA.Enabled = false;
        }

        void RunGA()
        {
            //----------
            ga.InitializePopulation();
            ga.EvaluatePopulation();
            Array.Sort(ga.pop);  // sort population
            //int bestFitness = ga.pop[0].fitness;
            int bestFitness = ga[0].fitness;  // because of indexer
            lock (this)
            {
                bestMember = (GAMember)ga[0].Clone();
            }
            for (int j = 0; j < TSGAConstants.NumIterations; j++)
            {
                // each loop is one generation
                ga.SelectPopulation();
                ga.CrossoverPopulation();
                ga.EvaluatePopulation();
                Array.Sort(ga.pop);  // sort population
                lblStatus2.Text = ("Best cand:" + j.ToString() + " " + ga.pop[0].fitness.ToString() +
                    "  " + ga.pop[0].ToString());

                lock (this)
                {
                    if (ga.pop[0].fitness < bestMember.fitness)
                        bestMember = (GAMember)ga[0].Clone();
                }

                ga.MutatePopulation();
                ga.EvaluatePopulation();
                Array.Sort(ga.pop);  // sort population

                if (ga.pop[0].fitness < bestFitness)
                {
                    bestFitness = ga.pop[0].fitness;
                    lblStatus2.Text = bestFitness.ToString();
                }
            }
        }


        private void ReadDistMat()
        {
            string fname = @"d:\csharpprogs\common\DistMat.txt";
            FileInfo fr = new FileInfo(fname); // input file 
            StreamReader reader = fr.OpenText();  // OpenText returns StreamReader
            string sline; string[] substrings;
            char[] separators = { ' ', ',', '\t' };
            int numcities;
            sline = reader.ReadLine();
            numcities = int.Parse(sline);
            DistMat = new int[numcities, numcities];
            sline = reader.ReadLine();
            for (int i = 0; i < numcities; i++)
            {
                substrings = sline.Split(separators, numcities); // numcities maximum size to split
                for (int j = 0; j < numcities; j++)
                    DistMat[i, j] = int.Parse(substrings[j]);
                sline = reader.ReadLine();
            }
            reader.Close();
        }

        private void picMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (bcapture == true)
            {
                Point p1 = new Point(e.X, e.Y);
                PointsList.Add(p1);
                Bitmap b1 = bMap;
                MyImageProc.DrawX(b1, ref bMap, p1);
                picMap.Image = bMap;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblBestResult.Text = "Fitness:" + ga.bestMember.fitness.ToString() + "\n" +
                ga.bestMember.ToString();

            Bitmap b1 = new Bitmap(bOrigMap);
            MyImageProc.DrawBestTour(b1, ref bMap, PointsList, ga.bestMember.mem);
            picMap.Image = bMap;
            lblStatus2.Text = ("It,Fitness:" + ga.iterationCount.ToString() + " " + ga.pop[0].fitness.ToString() +
                "  "  );
        }

        private void tabTSGA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabTSGA.SelectedTab.Name == "tabTSGAMT")
            {
                lblBestResult.Visible = false;
                lblBestResult0.Visible = true;
                lblBestResult1.Visible = true;
                lblBestResult2.Visible = true;
                lblBestResult3.Visible = true;
                grpGASettings.Visible = false;
                grpThreads.Visible = true;
                grpThreads.Location = grpGASettings.Location;
                grpGASettings.Visible = false;

            }
            if (tabTSGA.SelectedTab.Name == "tabTSGAST")
            {
                lblBestResult.Visible = true;
                lblBestResult0.Visible = false;
                lblBestResult1.Visible = false;
                lblBestResult2.Visible = false;
                lblBestResult3.Visible = false;
                grpGASettings.Visible = true;
                grpThreads.Visible = false;
                grpGASettings.Visible = true;
            }
        }

        private void btnStartThreads_Click(object sender, EventArgs e)
        {
            if (PointsList.Count == 0)
            {
                MessageBox.Show("No City Matrix loaded, Choose File Load" +
                    "\n or from the TSGA(simple threaded) map, capture  points");
                return;
            }
            if (opt2.Checked == true)
                numThreads = 2;
            if (opt3.Checked == true)
                numThreads = 3;
            if (opt4.Checked == true)
                numThreads = 4;

            GAs = new TSGA[numThreads];
            TGAs = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                GAs[i] = new TSGA(TSGAConstants.PopSize, TSGAConstants.NumCities,
                    (float)((i + 1) * 0.02), TSGAConstants.CrossoverRate, DistMat, ref lockobj);
                //   i*0.2 is the mutation rate for each thread
                TGAs[i] = new Thread(new ThreadStart(GAs[i].RunGA));
                TGAs[i].Start();
                btnStartThreads.Enabled = false;
                timer2.Enabled = true;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lock (lockobj)
            {
                try
                {
                    int bestOne = 0;
                    lblBestResult0.Text = "Thread 1: It:" + GAs[0].iterationCount.ToString() + " " +
                        "Fitness:" + GAs[0].bestMember.fitness.ToString() + " MutationRate:" + GAs[0].mutationRate.ToString() +
                        "\n" + GAs[0].bestMember.ToString();
                    lblBestResult1.Text = "Thread 2: It:" + GAs[1].iterationCount.ToString() + " " +
                        "Fitness:" + GAs[1].bestMember.fitness.ToString() + " MutationRate:" + GAs[1].mutationRate.ToString() +
                        "\n" + GAs[1].bestMember.ToString();
                    if (numThreads >= 3)
                    {
                        lblBestResult2.Text = "Thread 3: It:" + GAs[2].iterationCount.ToString() + " " +
                            "Fitness:" + GAs[2].bestMember.fitness.ToString() + " MutationRate:" + GAs[2].mutationRate.ToString() +
                            "\n" + GAs[2].bestMember.ToString();
                        if (numThreads >= 4)
                        {
                            lblBestResult3.Text = "Thread 4: It:" + GAs[3].iterationCount.ToString() + " " +
                                "Fitness:" + GAs[3].bestMember.fitness.ToString() + " MutationRate:" + GAs[3].mutationRate.ToString() +
                                "\n" + GAs[3].bestMember.ToString();
                        }
                    }

                    int bfitness = 0;
                    if (GAs[0].bestMember.fitness < GAs[1].bestMember.fitness)
                        bestOne = 0;
                    else
                        bestOne = 1;
                    bfitness = GAs[bestOne].bestMember.fitness;

                    if (numThreads >= 3)
                    {
                        if (GAs[2].bestMember.fitness < bfitness)
                        {
                            bestOne = 2;
                            bfitness = GAs[bestOne].bestMember.fitness;
                        }
                        if (numThreads >= 4)
                        {
                            if (GAs[3].bestMember.fitness < bfitness)
                            {
                                bestOne = 3;
                                bfitness = GAs[bestOne].bestMember.fitness;
                            }
                        }

                    }

                    bMap = new Bitmap(bOrigMap);
                    Bitmap b1 = new Bitmap(bOrigMap);
                    MyImageProc.DrawBestTour(b1, ref bMap, PointsList, GAs[bestOne].bestMember.mem);
                    MyImageProc.ResizeImage(bMap, ref bMap,
                        new Rectangle(0, 0, picMap0.Width, picMap0.Height));
                    picMap0.Image = bMap;
                   // lblBestThread.Text = "Current Best Thread: " + (bestOne + 1).ToString() + "\n" +
                   //     "Current Best Fitness: " + bfitness.ToString();

                    int ThreadMonitored = 1;
                    if (optT1.Checked == true)
                        ThreadMonitored = 0;
                    if (optT2.Checked == true)
                        ThreadMonitored = 1;
                    if (optT3.Checked == true)
                        ThreadMonitored = 2;
                    if (optT4.Checked == true)
                        ThreadMonitored = 3;

                    bMap = new Bitmap(bOrigMap);
                    MyImageProc.DrawBestTour(b1, ref bMap, PointsList, GAs[ThreadMonitored].bestMember.mem);
                    MyImageProc.ResizeImage(bMap, ref bMap,
                        new Rectangle(0, 0, picMap1.Width, picMap1.Height));
                    picMap1.Image = bMap;
                    lblThreadMonitored.Text = "Thread Monitored: " +
                        (ThreadMonitored + 1).ToString() + " Fitness: " +
                        GAs[ThreadMonitored].bestMember.fitness.ToString() +
                        " MutationRate:" + GAs[ThreadMonitored].mutationRate.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnStopThreads_Click(object sender, EventArgs e)
        {
            if (TGAs != null)
            {
                for (int i = 0; i < TGAs.Length; i++)
                {
                    if (TGAs[i].IsAlive)
                        TGAs[i].Abort();
                }
            }
            if (thXchg != null)
                if (thXchg.IsAlive)
                    thXchg.Abort();
            btnStartThreads.Enabled = true;
            timer2.Enabled = false;
        }

        private void btnStartThreadsXchg_Click(object sender, EventArgs e)
        {
            if (PointsList.Count == 0)
            {
                MessageBox.Show("No City Matrix loaded, Choose File Load" +
                    "\n or from the TSGA(simple threaded) map, capture  points");
                return;
            }
            int i = 0;
            if (opt2.Checked == true)
                numThreads = 2;
            if (opt3.Checked == true)
                numThreads = 3;
            if (opt4.Checked == true)
                numThreads = 4;

            GAs = new TSGA[numThreads];
            TGAs = new Thread[numThreads];

            synchObjsA = new object[numThreads];
            synchObjsB = new object[numThreads];
            dataready = new int[numThreads];
            xchgdone = new int[numThreads];

            for (i = 0; i < numThreads; i++)
            {
                synchObjsA[i] = new object();
                synchObjsB[i] = new object();

            }

            for (i = 0; i < numThreads; i++)
            {
                GAs[i] = new TSGA(TSGAConstants.PopSize, TSGAConstants.NumCities,
                    (float)((i + 1) * 0.02), TSGAConstants.CrossoverRate, DistMat, ref lockobj, ref synchObjsA,
                    ref synchObjsB, dataready, xchgdone, i);
                //   i*0.2 is the mutation rate for each thread
                TGAs[i] = new Thread(new ThreadStart(GAs[i].RunGA_XCHG));
                TGAs[i].Start();
                btnStartThreads.Enabled = false;
                timer2.Enabled = true;
            }

            //----start the exchange in another thread so that
            //---- user interface continues to show updates
            thXchg = new Thread(new ThreadStart(this.ExchangeData));
            Thread.Sleep(100);
            thXchg.Start();
        }

        void ExchangeData()
        {
            int i;

            Random r = new Random(System.DateTime.Now.Millisecond);
            bool done = true;
            while (true)
            {
                for (i = 0; i < numThreads; i++)  // wait for all threads to synchronize 
                {
                    if (TGAs[i].IsAlive)
                    {
                        if (dataready[i] == 0)
                        {
                            lock (GAs[i].synchObjsA[i])
                            {
                                Monitor.Wait(GAs[i].synchObjsA[i]);
                            }
                        }
                        lock (lockobj)
                        {
                            dataready[i] = 0;
                        }
                    }
                }

                //----------exchange data between threads------
                for (i = 0; i < numThreads; i++)
                {
                    int t1 = (int)(r.NextDouble() * numThreads);
                    int t2 = (int)(r.NextDouble() * numThreads);
                    if (t1 == t2) // while (t1 == t2)
                        t2 = (int)(r.NextDouble() * numThreads);

                    GAMember temp; int m1 = 0; int m2 = 0;
                    for (int j = 0; j < TSGAConstants.NumMembersToExchange; j++)  // exchange 3 values
                    {
                        m1 = (int)(r.NextDouble() * TSGAConstants.PopSize);
                        m2 = (int)(r.NextDouble() * TSGAConstants.PopSize);
                        lock (lockobj)
                        {
                            temp = GAs[t1].pop[m1];
                            GAs[t1].pop[m1] = GAs[t2].pop[m2];
                            GAs[t2].pop[m2] = temp;
                        }
                    }
                }
                for (i = 0; i < numThreads; i++)
                {
                    lock (lockobj)
                    {
                        xchgdone[i] = 1;
                    }
                    lock (synchObjsB[i])
                    {
                        Monitor.PulseAll(synchObjsB[i]); // tell each thread to proceed
                    }
                }
                done = true;
                for (i = 0; i < numThreads; i++)
                {
                    if (TGAs[i].IsAlive)
                        done = false;
                }
                if (done == true)
                    break;  // all threads done
            }
        }

    }
}
