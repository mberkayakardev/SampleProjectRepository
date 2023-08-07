using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dideneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(Program.ServiceProvider.GetRequiredService<ILogger>());
            f.Show();
        }
    }
}