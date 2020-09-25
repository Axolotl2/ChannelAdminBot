namespace ChannelAdminBot
{
    partial class ChannelAdminController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelAdminController));
            this.m_UnMuteAll = new System.Windows.Forms.Button();
            this.m_MuteAll = new System.Windows.Forms.Button();
            this.m_ChannelsComboBox = new System.Windows.Forms.ComboBox();
            this.m_MuteSelected = new System.Windows.Forms.Button();
            this.m_UnMuteSelected = new System.Windows.Forms.Button();
            this.m_UsersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // m_UnMuteAll
            // 
            this.m_UnMuteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_UnMuteAll.Location = new System.Drawing.Point(121, 12);
            this.m_UnMuteAll.Name = "m_UnMuteAll";
            this.m_UnMuteAll.Size = new System.Drawing.Size(103, 23);
            this.m_UnMuteAll.TabIndex = 1;
            this.m_UnMuteAll.Text = "UnMute All";
            this.m_UnMuteAll.UseVisualStyleBackColor = true;
            this.m_UnMuteAll.Click += new System.EventHandler(this.UnMuteAll_Click);
            // 
            // m_MuteAll
            // 
            this.m_MuteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_MuteAll.Location = new System.Drawing.Point(12, 12);
            this.m_MuteAll.Name = "m_MuteAll";
            this.m_MuteAll.Size = new System.Drawing.Size(103, 23);
            this.m_MuteAll.TabIndex = 2;
            this.m_MuteAll.Text = "Mute All";
            this.m_MuteAll.UseVisualStyleBackColor = true;
            this.m_MuteAll.Click += new System.EventHandler(this.MuteAll_Click);
            // 
            // m_ChannelsComboBox
            // 
            this.m_ChannelsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_ChannelsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_ChannelsComboBox.FormattingEnabled = true;
            this.m_ChannelsComboBox.Location = new System.Drawing.Point(12, 55);
            this.m_ChannelsComboBox.Name = "m_ChannelsComboBox";
            this.m_ChannelsComboBox.Size = new System.Drawing.Size(212, 21);
            this.m_ChannelsComboBox.TabIndex = 3;
            this.m_ChannelsComboBox.SelectedIndexChanged += new System.EventHandler(this.m_ChannelsComboBox_SelectedIndexChanged);
            // 
            // m_MuteSelected
            // 
            this.m_MuteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_MuteSelected.Location = new System.Drawing.Point(12, 94);
            this.m_MuteSelected.Name = "m_MuteSelected";
            this.m_MuteSelected.Size = new System.Drawing.Size(103, 23);
            this.m_MuteSelected.TabIndex = 4;
            this.m_MuteSelected.Text = "Mute Selected";
            this.m_MuteSelected.UseVisualStyleBackColor = true;
            this.m_MuteSelected.Click += new System.EventHandler(this.MuteSelected_Click);
            // 
            // m_UnMuteSelected
            // 
            this.m_UnMuteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_UnMuteSelected.Location = new System.Drawing.Point(121, 94);
            this.m_UnMuteSelected.Name = "m_UnMuteSelected";
            this.m_UnMuteSelected.Size = new System.Drawing.Size(103, 23);
            this.m_UnMuteSelected.TabIndex = 5;
            this.m_UnMuteSelected.Text = "UnMute Selected";
            this.m_UnMuteSelected.UseVisualStyleBackColor = true;
            this.m_UnMuteSelected.Click += new System.EventHandler(this.UnMuteSelected_Click);
            // 
            // m_UsersCheckedListBox
            // 
            this.m_UsersCheckedListBox.CheckOnClick = true;
            this.m_UsersCheckedListBox.FormattingEnabled = true;
            this.m_UsersCheckedListBox.Location = new System.Drawing.Point(12, 133);
            this.m_UsersCheckedListBox.Name = "m_UsersCheckedListBox";
            this.m_UsersCheckedListBox.Size = new System.Drawing.Size(212, 109);
            this.m_UsersCheckedListBox.TabIndex = 6;
            // 
            // ChannelAdminController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 262);
            this.Controls.Add(this.m_UsersCheckedListBox);
            this.Controls.Add(this.m_UnMuteSelected);
            this.Controls.Add(this.m_MuteSelected);
            this.Controls.Add(this.m_ChannelsComboBox);
            this.Controls.Add(this.m_MuteAll);
            this.Controls.Add(this.m_UnMuteAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelAdminController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord Mute Controller";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChannelAdminController_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button m_UnMuteAll;
        private System.Windows.Forms.Button m_MuteAll;
        private System.Windows.Forms.ComboBox m_ChannelsComboBox;
        private System.Windows.Forms.Button m_MuteSelected;
        private System.Windows.Forms.Button m_UnMuteSelected;
        private System.Windows.Forms.CheckedListBox m_UsersCheckedListBox;
    }
}

