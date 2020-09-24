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
            //"Among us - Public"
            string pickedValue = ComboBox.SelectedItem.ToString();

            if (MutePressed != null)
            {
                MutePressed.Invoke("Among us - Public", true);
            }
        }

        private void UnmuteAll_Click(object sender, EventArgs e)
        {
            string pickedValue = ComboBox.SelectedItem.ToString();

            if(UnmutePressed != null)
            {
                UnmutePressed.Invoke("Among us - Public", false);
            }
        }

        public void SetComboBoxValues(IList<string> i_Values)
        {
            ComboBox.DataSource = i_Values;
        }
    }
}
