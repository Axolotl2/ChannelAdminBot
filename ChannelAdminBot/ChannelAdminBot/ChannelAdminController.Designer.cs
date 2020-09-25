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
            this.UnmuteAll = new System.Windows.Forms.Button();
            this.MuteAll = new System.Windows.Forms.Button();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // UnmuteAll
            // 
            this.UnmuteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UnmuteAll.Location = new System.Drawing.Point(161, 15);
            this.UnmuteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UnmuteAll.Name = "UnmuteAll";
            this.UnmuteAll.Size = new System.Drawing.Size(137, 28);
            this.UnmuteAll.TabIndex = 1;
            this.UnmuteAll.Text = "UnMute All";
            this.UnmuteAll.UseVisualStyleBackColor = true;
            this.UnmuteAll.Click += new System.EventHandler(this.UnmuteAll_Click);
            // 
            // MuteAll
            // 
            this.MuteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MuteAll.Location = new System.Drawing.Point(16, 15);
            this.MuteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MuteAll.Name = "MuteAll";
            this.MuteAll.Size = new System.Drawing.Size(137, 28);
            this.MuteAll.TabIndex = 2;
            this.MuteAll.Text = "Mute All";
            this.MuteAll.UseVisualStyleBackColor = true;
            this.MuteAll.Click += new System.EventHandler(this.MuteAll_Click);
            // 
            // ComboBox
            // 
            this.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Location = new System.Drawing.Point(16, 68);
            this.ComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(281, 24);
            this.ComboBox.TabIndex = 3;
            // 
            // ChannelAdminController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 108);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.MuteAll);
            this.Controls.Add(this.UnmuteAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelAdminController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord Mute Controller";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChannelAdminController_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button UnmuteAll;
        private System.Windows.Forms.Button MuteAll;
        private System.Windows.Forms.ComboBox ComboBox;
    }
}

