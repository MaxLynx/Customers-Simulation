using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomersSimulation
{
    public partial class Form1 : Form
    {
        FormController formController;
        public Form1()
        {
            InitializeComponent();
            formController = new FormController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formController.Simulate();
            textBox1.Text = formController.GetAverageWaitingTime();
            textBox2.Text = formController.GetAverageCountInQueue();
        }
    }
}
