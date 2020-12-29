using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bootstrapper
{
    public partial class ClientLauncher : Form
    {
        public ClientLauncher()
        {
            InitializeComponent();
        }

        private void SetCustomURLCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IPTextBox.Enabled = !IPTextBox.Enabled;
            PlayerNameTextBox.Enabled = !PlayerNameTextBox.Enabled;
            AdditionalGameOptionsTextBox.Enabled = !AdditionalGameOptionsTextBox.Enabled;
            CustomURLTextBox.Visible = !CustomURLTextBox.Visible;
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if(SetCustomURLCheckBox.Checked)
            {
                GameLauncher.LaunchClient("", CustomURLTextBox.Text);
            } else
            {
                string options = $"?Name={PlayerNameTextBox.Text}{AdditionalGameOptionsTextBox.Text}";
                GameLauncher.LaunchClient(IPTextBox.Text, options);
            }
        }

        private void ClientLauncher_Load(object sender, EventArgs e)
        {

        }
    }
}
