using Discord;
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
    delegate void SetCheckedListBoxValuedCallBack(List<string> i_Users);

    public partial class ChannelAdminController : Form
    {
        public event Action<string, string, bool> MuteAllPressed;
        public event Action<string, string, bool> UnMuteAllPressed;
        public event Action<string, string, List<string>, bool> MuteSelectedPressed;
        public event Action<string, string, List<string>, bool> UnMuteSelectedPressed;
        public event Action GuildPicked;
        public event Action ChannelPicked;
        private string m_PickedGuild;
        private string m_PickedChannel;

        public ChannelAdminController()
        {
            InitializeComponent();
        }

        public string PickedChannel
        {
            get
            {
                return m_PickedChannel;
            }
        }

        public string PickedGuild
        {
            get
            {
                return m_PickedGuild;
            }
        }

        private void MuteAll_Click(object sender, EventArgs e)
        {
            string pickedGuild = PickedGuild;
            string pickedChannel = PickedChannel;

            if (MuteAllPressed != null)
            {
                MuteAllPressed.Invoke(pickedGuild, pickedChannel, true);
            }
        }

        private void UnMuteAll_Click(object sender, EventArgs e)
        {
            string pickedGuild = PickedGuild;
            string pickedChannel = PickedChannel;

            if (UnMuteAllPressed != null)
            {
                UnMuteAllPressed.Invoke(pickedGuild, pickedChannel, false);
            }
        }

        public void SetChannelsComboBoxValues(IList<string> i_Values)
        {
            (i_Values as List<string>).Sort();
            m_ChannelsComboBox.DataSource = i_Values;
        }

        public void SetGuildsComboBoxValues(IList<string> i_Values)
        {
            (i_Values as List<string>).Sort();
            m_GuildsComboBox.DataSource = i_Values;
        }

        public void SetCheckedListBoxValues(List<string> i_Users)
        {
            SetCheckedListBoxValuedCallBack callBack;
            List<string> usersToRemove = new List<string>();

            if (m_UsersCheckedListBox.InvokeRequired)
            {
                callBack = new SetCheckedListBoxValuedCallBack(SetCheckedListBoxValues);
                Invoke(callBack, new object[] { i_Users });
            }
            else
            {
                foreach (string user in m_UsersCheckedListBox.Items)
                {
                    if (!i_Users.Contains(user))
                    {
                        usersToRemove.Add(user);
                    }
                }

                foreach (string user in usersToRemove)
                {
                    m_UsersCheckedListBox.Items.Remove(user);
                }

                foreach (string user in i_Users)
                {
                    if (!m_UsersCheckedListBox.Items.Contains(user))
                    {
                        m_UsersCheckedListBox.Items.Add(user);
                    }
                }
            }
        }

        private void ChannelAdminController_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }

        private void MuteSelected_Click(object sender, EventArgs e)
        {
            string pickedGuild = PickedGuild;
            string pickedChannel = PickedChannel;
            List<string> users = getSelectedUsers();

            if (MuteSelectedPressed != null)
            {
                MuteSelectedPressed.Invoke(pickedGuild, pickedChannel, users, true);
            }
        }

        private void UnMuteSelected_Click(object sender, EventArgs e)
        {
            string pickedGuild = PickedGuild;
            string pickedChannel = PickedChannel;
            List<string> users = getSelectedUsers();

            if (UnMuteSelectedPressed != null)
            {
                UnMuteSelectedPressed.Invoke(pickedGuild, pickedChannel, users, false);
            }
        }

        private List<string> getSelectedUsers()
        {
            List<string> users = new List<string>();
            ListBox.SelectedObjectCollection usersCollection;

            usersCollection = m_UsersCheckedListBox.SelectedItems;
            foreach (object user in usersCollection)
            {
                users.Add(user as string);
            }

            return users;
        }

        private void m_ChannelsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_PickedChannel = (string)m_ChannelsComboBox.SelectedItem;
            if (ChannelPicked != null)
            {
                ChannelPicked.Invoke();
            }
        }

        private void m_GuildsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_PickedGuild = (string)m_GuildsComboBox.SelectedItem;
            if (GuildPicked != null)
            {
                GuildPicked.Invoke();
            }
        }
    }
}
