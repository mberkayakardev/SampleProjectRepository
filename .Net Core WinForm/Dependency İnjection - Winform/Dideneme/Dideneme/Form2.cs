using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dideneme
{
    public partial class Form2 : Form
    {
        private readonly ILogger logger;
        public Form2(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            logger.GetHello();
            logger.SetHello();
        }
    }
}
