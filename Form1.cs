using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadLifeCycle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Thread childThread = new Thread(ThreadCycle);

            Console.WriteLine("Initial State: " + childThread.ThreadState);

            childThread.Start();

            Console.WriteLine("After Start(): " + childThread.ThreadState);

            //Thread.Sleep(100);
            //Console.WriteLine("During Sleep: " + childThread.ThreadState);

            //Console.WriteLine("Calling Abort(): " );
            //childThread.Abort();

            Thread.Sleep(500);
            Console.WriteLine("After Abort!:" + childThread.ThreadState);
        }

        private void ThreadCycle()
        {
            try {
                Console.WriteLine("Child Thread Started!");
                Thread.Sleep(5000);
                Console.WriteLine("Child Thread Finished Normally!");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("Child Thread Aborted!");
            }
        }
    }
}
