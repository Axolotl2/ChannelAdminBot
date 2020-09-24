using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChannelAdminBot
{
    public partial class ChannelAdminController : Form
    {
        public event Action<string, bool> MutePressed;
        public event Action<string, bool> UnmutePressed;

        public ChannelAdminController()
        {
            InitializeComponent();
        }

        private void MuteAll_Click(object sender, EventArgs e)
        {
            if (MutePressed != null)
            {
                MutePressed.Invoke("Among us - Public", true);
            }
        }

        private void UnmuteAll_Click(object sender, EventArgs e)
        {
            if(UnmutePressed != null)
            {
                UnmutePressed.Invoke("Among us - Public", false);
            }
        }
    }
}
