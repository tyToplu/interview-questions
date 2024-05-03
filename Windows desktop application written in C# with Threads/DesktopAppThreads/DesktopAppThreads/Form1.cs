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
using System.Windows.Forms.VisualStyles;

namespace DesktopAppThreads
{
    public partial class Form1 : Form
    {
        static readonly object lockObj1 = new object();
        static readonly object lockObj2 = new object();

        static string resultFromTask1;
        static string resultFromTask2;
        ThreadClass threadClass;


        public Form1()
        {
            InitializeComponent();
        }


       
        private void button1_Click(object sender, EventArgs e)
        {

            String BoundStr = textBox1.Text;

            if (String.IsNullOrEmpty(BoundStr))
            {
                MessageBox.Show("Text can not be empty");
                return;
            }


            Thread taskThread = new Thread(() => RunTaskInThread(BoundStr, ref resultFromTask1, lockObj1));
            taskThread.Start();
            taskThread.Join();
            richTextBox1.Text = resultFromTask1;

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            threadClass = new ThreadClass(new PrimeCalculation());
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            String BoundStr = textBox2.Text;
        
            if (String.IsNullOrEmpty(BoundStr))
            {
                MessageBox.Show("Text can not be empty");
                return;
            }


            Thread taskThread = new Thread(() => RunTaskInThread(BoundStr, ref resultFromTask2, lockObj2));
            taskThread.Start();
            taskThread.Join();
            richTextBox2.Text = resultFromTask2;
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsANumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsANumber(e);
        }
        private void CheckIsANumber(KeyPressEventArgs e)
        {   
            if (!char.IsNumber(e.KeyChar) &&
            !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void RunTaskInThread(string boundStr, ref string result, object lockObj)
        {
            Task<string> task = Task.Run(() => threadClass.SetPrimeNumbersJob(boundStr));
            string taskResult = task.Result;

            lock (lockObj)
            {
                result = taskResult;
            }
        }


    }
}
