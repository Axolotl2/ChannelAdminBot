﻿namespace ChannelAdminBot
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
            this.m_GuildsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_UnMuteAll
            // 
            this.m_UnMuteAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_UnMuteAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_UnMuteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_UnMuteAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_UnMuteAll.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_UnMuteAll.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.m_UnMuteAll.Location = new System.Drawing.Point(154, 12);
            this.m_UnMuteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_UnMuteAll.Name = "m_UnMuteAll";
            this.m_UnMuteAll.Size = new System.Drawing.Size(133, 32);
            this.m_UnMuteAll.TabIndex = 1;
            this.m_UnMuteAll.Text = "UnMute All";
            this.m_UnMuteAll.UseVisualStyleBackColor = false;
            this.m_UnMuteAll.Click += new System.EventHandler(this.UnMuteAll_Click);
            // 
            // m_MuteAll
            // 
            this.m_MuteAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_MuteAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_MuteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_MuteAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_MuteAll.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_MuteAll.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.m_MuteAll.Location = new System.Drawing.Point(13, 12);
            this.m_MuteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_MuteAll.Name = "m_MuteAll";
            this.m_MuteAll.Size = new System.Drawing.Size(133, 32);
            this.m_MuteAll.TabIndex = 0;
            this.m_MuteAll.Text = "Mute All";
            this.m_MuteAll.UseVisualStyleBackColor = false;
            this.m_MuteAll.Click += new System.EventHandler(this.MuteAll_Click);
            // 
            // m_ChannelsComboBox
            // 
            this.m_ChannelsComboBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_ChannelsComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_ChannelsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_ChannelsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_ChannelsComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ChannelsComboBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_ChannelsComboBox.FormattingEnabled = true;
            this.m_ChannelsComboBox.Location = new System.Drawing.Point(13, 87);
            this.m_ChannelsComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_ChannelsComboBox.Name = "m_ChannelsComboBox";
            this.m_ChannelsComboBox.Size = new System.Drawing.Size(274, 26);
            this.m_ChannelsComboBox.TabIndex = 3;
            this.m_ChannelsComboBox.SelectedIndexChanged += new System.EventHandler(this.m_ChannelsComboBox_SelectedIndexChanged);
            // 
            // m_MuteSelected
            // 
            this.m_MuteSelected.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_MuteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_MuteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_MuteSelected.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_MuteSelected.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_MuteSelected.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.m_MuteSelected.Location = new System.Drawing.Point(13, 151);
            this.m_MuteSelected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_MuteSelected.Name = "m_MuteSelected";
            this.m_MuteSelected.Size = new System.Drawing.Size(133, 32);
            this.m_MuteSelected.TabIndex = 4;
            this.m_MuteSelected.Text = "Mute Selected";
            this.m_MuteSelected.UseVisualStyleBackColor = false;
            this.m_MuteSelected.Click += new System.EventHandler(this.MuteSelected_Click);
            // 
            // m_UnMuteSelected
            // 
            this.m_UnMuteSelected.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_UnMuteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_UnMuteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_UnMuteSelected.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_UnMuteSelected.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_UnMuteSelected.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.m_UnMuteSelected.Location = new System.Drawing.Point(154, 151);
            this.m_UnMuteSelected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_UnMuteSelected.Name = "m_UnMuteSelected";
            this.m_UnMuteSelected.Size = new System.Drawing.Size(133, 32);
            this.m_UnMuteSelected.TabIndex = 5;
            this.m_UnMuteSelected.Text = "UnMute Selected";
            this.m_UnMuteSelected.UseVisualStyleBackColor = false;
            this.m_UnMuteSelected.Click += new System.EventHandler(this.UnMuteSelected_Click);
            // 
            // m_UsersCheckedListBox
            // 
            this.m_UsersCheckedListBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_UsersCheckedListBox.CheckOnClick = true;
            this.m_UsersCheckedListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_UsersCheckedListBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_UsersCheckedListBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_UsersCheckedListBox.FormattingEnabled = true;
            this.m_UsersCheckedListBox.Location = new System.Drawing.Point(13, 191);
            this.m_UsersCheckedListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_UsersCheckedListBox.MultiColumn = true;
            this.m_UsersCheckedListBox.Name = "m_UsersCheckedListBox";
            this.m_UsersCheckedListBox.Size = new System.Drawing.Size(274, 172);
            this.m_UsersCheckedListBox.Sorted = true;
            this.m_UsersCheckedListBox.TabIndex = 6;
            // 
            // m_GuildsComboBox
            // 
            this.m_GuildsComboBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_GuildsComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_GuildsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_GuildsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_GuildsComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_GuildsComboBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_GuildsComboBox.FormattingEnabled = true;
            this.m_GuildsComboBox.Location = new System.Drawing.Point(13, 53);
            this.m_GuildsComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_GuildsComboBox.Name = "m_GuildsComboBox";
            this.m_GuildsComboBox.Size = new System.Drawing.Size(274, 26);
            this.m_GuildsComboBox.TabIndex = 2;
            this.m_GuildsComboBox.SelectedIndexChanged += new System.EventHandler(this.m_GuildsComboBox_SelectedIndexChanged);
            // 
            // ChannelAdminController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(298, 370);
            this.Controls.Add(this.m_GuildsComboBox);
            this.Controls.Add(this.m_UsersCheckedListBox);
            this.Controls.Add(this.m_UnMuteSelected);
            this.Controls.Add(this.m_MuteSelected);
            this.Controls.Add(this.m_ChannelsComboBox);
            this.Controls.Add(this.m_MuteAll);
            this.Controls.Add(this.m_UnMuteAll);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelAdminController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord Mute Controller";
            this.Load += new System.EventHandler(this.ChannelAdminController_Load);
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
        private System.Windows.Forms.ComboBox m_GuildsComboBox;
    }
}

