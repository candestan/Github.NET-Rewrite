using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitHubNET_Rewrite;

namespace GitHubNET_Rewrite_Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            GitHubNET.USER User = new GitHubNET.USER(textBox1.Text);
            pictureBox1.ImageLocation = User.Avatar_URL.OriginalString;
        }
    }
}
