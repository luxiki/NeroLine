using System;
using System.Windows.Forms;

namespace Nero_Wiev
{

   

    public partial class AddSmdForm : Form
    {
        

        public AddSmdForm()
        {
            InitializeComponent();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            SmdName = tbNameSmd.Text;
            SmdRotate = tbRotateSmd.Text;
            this.Close();
        }

        public string SmdName { get; private set; }
        public string SmdRotate { get; private set; }

    }


}
