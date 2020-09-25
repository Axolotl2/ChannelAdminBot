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
        public event Action<string, bool> MuteAllPressed;
        public event Action<string, bool> UnMuteAllPressed;
        public event Action<string, List<string>, bool> MuteSelectedPressed;
        public event Action<string, List<string>, bool> UnMuteSelectedPressed;

        public ChannelAdminController()
        {
            InitializeComponent();
        }

        public string PickedChannel
        {
            get
            {
                return (m_ChannelsComboBox.SelectedItem as string);
            }
        }

        private void MuteAll_Click(object sender, EventArgs e)
        {
            //"Among us - Public"
            string pickedValue = m_ChannelsComboBox.SelectedItem.ToString();

            if (MuteAllPressed != null)
            {
                MuteAllPressed.Invoke(pickedValue, true);
            }
        }

        private void UnMuteAll_Click(object sender, EventArgs e)
        {
            string pickedValue = m_ChannelsComboBox.SelectedItem.ToString();

            if(UnMuteAllPressed != null)
            {
                UnMuteAllPressed.Invoke(pickedValue, false);
            }
        }

        public void SetComboBoxValues(IList<string> i_Values)
        {
            m_ChannelsComboBox.DataSource = i_Values;
        }

        public void SetCheckedListBoxValues(List<string> i_Users)
        {
            foreach(string user in i_Users)
            {
                m_UsersCheckedListBox.Items.Add(user);
            }
        }

        private void ChannelAdminController_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }

        private void MuteSelected_Click(object sender, EventArgs e)
        {
            string pickedValue = m_ChannelsComboBox.SelectedItem.ToString();
            List<string> users = getSelectedUsers();

            if (MuteSelectedPressed != null)
            {
                MuteSelectedPressed.Invoke(pickedValue, users, true);
            }
        }

        private void UnMuteSelected_Click(object sender, EventArgs e)
        {
            string pickedValue = m_ChannelsComboBox.SelectedItem.ToString();
            List<string> users = getSelectedUsers();

            if (UnMuteSelectedPressed != null)
            {
                UnMuteSelectedPressed.Invoke(pickedValue, users, false);
            }
        }

        private List<string> getSelectedUsers()
        {
            List<string> users = new List<string>();
            ListBox.SelectedObjectCollection usersCollection;

            usersCollection = m_UsersCheckedListBox.SelectedItems;

            foreach(object user in usersCollection)
            {
                users.Add(user as string);
            }

            return users;
        }
    }
}
