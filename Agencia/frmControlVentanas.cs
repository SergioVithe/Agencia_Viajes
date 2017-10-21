using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia
{
    public partial class frmControlVentanas : UserControl
    {
        public frmControlVentanas()
        {
            InitializeComponent();
           // panel1.Height =  //btnMenuCatalogos.Height;
            //panel1.Top = btnMenuCatalogos.Top;
            frmCatalogos1.BringToFront();
        }

        private void frmCatalogos1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
