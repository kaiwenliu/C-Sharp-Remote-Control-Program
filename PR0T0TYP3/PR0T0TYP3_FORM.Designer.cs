namespace PR0T0TYP3
{
	partial class PR0T0TYP3_FORM
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PR0T0TYP3_FORM));
			this.listenerAndBuilder = new System.Windows.Forms.TabControl();
			this.listenerPage = new System.Windows.Forms.TabPage();
			this.builderPage = new System.Windows.Forms.TabPage();
			this.portText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ipOrDns = new System.Windows.Forms.TextBox();
			this.buildButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.log = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.IpAddresses = new System.Windows.Forms.DataGridView();
			this.IP_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label5 = new System.Windows.Forms.Label();
			this.portListenText = new System.Windows.Forms.TextBox();
			this.portListenButton = new System.Windows.Forms.Button();
			this.listenerAndBuilder.SuspendLayout();
			this.listenerPage.SuspendLayout();
			this.builderPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IpAddresses)).BeginInit();
			this.SuspendLayout();
			// 
			// listenerAndBuilder
			// 
			this.listenerAndBuilder.Controls.Add(this.builderPage);
			this.listenerAndBuilder.Controls.Add(this.listenerPage);
			this.listenerAndBuilder.Location = new System.Drawing.Point(1, 1);
			this.listenerAndBuilder.Name = "listenerAndBuilder";
			this.listenerAndBuilder.SelectedIndex = 0;
			this.listenerAndBuilder.Size = new System.Drawing.Size(799, 450);
			this.listenerAndBuilder.TabIndex = 0;
			// 
			// listenerPage
			// 
			this.listenerPage.BackColor = System.Drawing.Color.MidnightBlue;
			this.listenerPage.Controls.Add(this.portListenButton);
			this.listenerPage.Controls.Add(this.portListenText);
			this.listenerPage.Controls.Add(this.label5);
			this.listenerPage.Controls.Add(this.IpAddresses);
			this.listenerPage.Location = new System.Drawing.Point(4, 25);
			this.listenerPage.Name = "listenerPage";
			this.listenerPage.Padding = new System.Windows.Forms.Padding(3);
			this.listenerPage.Size = new System.Drawing.Size(791, 421);
			this.listenerPage.TabIndex = 0;
			this.listenerPage.Text = "Listener";
			// 
			// builderPage
			// 
			this.builderPage.BackColor = System.Drawing.Color.MidnightBlue;
			this.builderPage.Controls.Add(this.label4);
			this.builderPage.Controls.Add(this.label3);
			this.builderPage.Controls.Add(this.pictureBox1);
			this.builderPage.Controls.Add(this.log);
			this.builderPage.Controls.Add(this.buildButton);
			this.builderPage.Controls.Add(this.label2);
			this.builderPage.Controls.Add(this.ipOrDns);
			this.builderPage.Controls.Add(this.label1);
			this.builderPage.Controls.Add(this.portText);
			this.builderPage.Location = new System.Drawing.Point(4, 25);
			this.builderPage.Name = "builderPage";
			this.builderPage.Padding = new System.Windows.Forms.Padding(3);
			this.builderPage.Size = new System.Drawing.Size(791, 421);
			this.builderPage.TabIndex = 1;
			this.builderPage.Text = "Builder";
			this.builderPage.Click += new System.EventHandler(this.tabPage2_Click);
			// 
			// portText
			// 
			this.portText.Location = new System.Drawing.Point(317, 75);
			this.portText.Name = "portText";
			this.portText.Size = new System.Drawing.Size(151, 22);
			this.portText.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Red;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(318, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Port Number:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Red;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(318, 179);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "IP Address/DNS:";
			// 
			// ipOrDns
			// 
			this.ipOrDns.Location = new System.Drawing.Point(317, 202);
			this.ipOrDns.Name = "ipOrDns";
			this.ipOrDns.Size = new System.Drawing.Size(151, 22);
			this.ipOrDns.TabIndex = 2;
			// 
			// buildButton
			// 
			this.buildButton.BackColor = System.Drawing.Color.Red;
			this.buildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buildButton.Location = new System.Drawing.Point(317, 285);
			this.buildButton.Name = "buildButton";
			this.buildButton.Size = new System.Drawing.Size(151, 43);
			this.buildButton.TabIndex = 4;
			this.buildButton.Text = "Build";
			this.buildButton.UseVisualStyleBackColor = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Blue;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 202);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(235, 126);
			this.label3.TabIndex = 5;
			this.label3.Text = "Disclaimer: If you decide to\r\nutilize this program for \r\nmalicious rather than \r\n" +
    "experimental purposes, \r\nyour consequences are not \r\nmy fault, as this program w" +
    "as\r\nonly made for experimentation";
			// 
			// log
			// 
			this.log.Location = new System.Drawing.Point(510, 33);
			this.log.Multiline = true;
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(258, 353);
			this.log.TabIndex = 6;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(3, 42);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(258, 190);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(511, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Error Log:";
			// 
			// IpAddresses
			// 
			this.IpAddresses.AllowUserToAddRows = false;
			this.IpAddresses.AllowUserToDeleteRows = false;
			this.IpAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.IpAddresses.BackgroundColor = System.Drawing.Color.Red;
			this.IpAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.IpAddresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP_Address});
			this.IpAddresses.GridColor = System.Drawing.Color.Coral;
			this.IpAddresses.Location = new System.Drawing.Point(226, -4);
			this.IpAddresses.Name = "IpAddresses";
			this.IpAddresses.RowTemplate.Height = 24;
			this.IpAddresses.Size = new System.Drawing.Size(569, 429);
			this.IpAddresses.TabIndex = 0;
			this.IpAddresses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// IP_Address
			// 
			this.IP_Address.HeaderText = "IP Address";
			this.IP_Address.Name = "IP_Address";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(63, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 17);
			this.label5.TabIndex = 1;
			this.label5.Text = "Listen on port:";
			// 
			// portListenText
			// 
			this.portListenText.Location = new System.Drawing.Point(62, 98);
			this.portListenText.Name = "portListenText";
			this.portListenText.Size = new System.Drawing.Size(100, 22);
			this.portListenText.TabIndex = 2;
			// 
			// portListenButton
			// 
			this.portListenButton.Location = new System.Drawing.Point(62, 143);
			this.portListenButton.Name = "portListenButton";
			this.portListenButton.Size = new System.Drawing.Size(100, 41);
			this.portListenButton.TabIndex = 3;
			this.portListenButton.Text = "Listen";
			this.portListenButton.UseVisualStyleBackColor = true;
			// 
			// PR0T0TYP3_FORM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MidnightBlue;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listenerAndBuilder);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PR0T0TYP3_FORM";
			this.Text = "PR0T0TYP3";
			this.listenerAndBuilder.ResumeLayout(false);
			this.listenerPage.ResumeLayout(false);
			this.listenerPage.PerformLayout();
			this.builderPage.ResumeLayout(false);
			this.builderPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IpAddresses)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl listenerAndBuilder;
		private System.Windows.Forms.TabPage listenerPage;
		private System.Windows.Forms.TabPage builderPage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox log;
		private System.Windows.Forms.Button buildButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ipOrDns;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox portText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView IpAddresses;
		private System.Windows.Forms.DataGridViewTextBoxColumn IP_Address;
		private System.Windows.Forms.Button portListenButton;
		private System.Windows.Forms.TextBox portListenText;
		private System.Windows.Forms.Label label5;
	}
}

