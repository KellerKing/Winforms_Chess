
namespace Chess.Menue
{
  partial class MainForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.rbPlayerBlack = new System.Windows.Forms.RadioButton();
      this.rbPlayerWhite = new System.Windows.Forms.RadioButton();
      this.btnPlay = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.rbSinglePlayer = new System.Windows.Forms.RadioButton();
      this.rbDoublePlayer = new System.Windows.Forms.RadioButton();
      this.groupBoxSideChoose = new System.Windows.Forms.GroupBox();
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBoxSideChoose.SuspendLayout();
      this.SuspendLayout();
      // 
      // rbPlayerBlack
      // 
      this.rbPlayerBlack.AutoSize = true;
      this.rbPlayerBlack.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbPlayerBlack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbPlayerBlack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbPlayerBlack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.rbPlayerBlack.ForeColor = System.Drawing.Color.White;
      this.rbPlayerBlack.Location = new System.Drawing.Point(6, 56);
      this.rbPlayerBlack.Name = "rbPlayerBlack";
      this.rbPlayerBlack.Size = new System.Drawing.Size(78, 24);
      this.rbPlayerBlack.TabIndex = 0;
      this.rbPlayerBlack.Text = "BLACK";
      this.rbPlayerBlack.UseVisualStyleBackColor = true;
      // 
      // rbPlayerWhite
      // 
      this.rbPlayerWhite.AutoSize = true;
      this.rbPlayerWhite.Checked = true;
      this.rbPlayerWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbPlayerWhite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbPlayerWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbPlayerWhite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.rbPlayerWhite.ForeColor = System.Drawing.Color.White;
      this.rbPlayerWhite.Location = new System.Drawing.Point(6, 26);
      this.rbPlayerWhite.Name = "rbPlayerWhite";
      this.rbPlayerWhite.Size = new System.Drawing.Size(78, 24);
      this.rbPlayerWhite.TabIndex = 1;
      this.rbPlayerWhite.TabStop = true;
      this.rbPlayerWhite.Text = "WHITE";
      this.rbPlayerWhite.UseVisualStyleBackColor = true;
      // 
      // btnPlay
      // 
      this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnPlay.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.White;
      this.btnPlay.FlatAppearance.BorderSize = 0;
      this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.btnPlay.ForeColor = System.Drawing.Color.White;
      this.btnPlay.Image = global::Chess.Menue.Properties.Resources.IconPlay_Small;
      this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnPlay.Location = new System.Drawing.Point(0, 222);
      this.btnPlay.Name = "btnPlay";
      this.btnPlay.Size = new System.Drawing.Size(539, 73);
      this.btnPlay.TabIndex = 2;
      this.btnPlay.Text = "PLAY";
      this.btnPlay.UseVisualStyleBackColor = true;
      this.btnPlay.Click += new System.EventHandler(this.button1_Click);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
      this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.groupBoxSideChoose);
      this.panel1.Controls.Add(this.btnPlay);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(539, 295);
      this.panel1.TabIndex = 3;
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(96)))));
      this.groupBox2.Controls.Add(this.rbSinglePlayer);
      this.groupBox2.Controls.Add(this.rbDoublePlayer);
      this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.groupBox2.Location = new System.Drawing.Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(515, 97);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Count";
      // 
      // rbSinglePlayer
      // 
      this.rbSinglePlayer.AutoSize = true;
      this.rbSinglePlayer.Checked = true;
      this.rbSinglePlayer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbSinglePlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbSinglePlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbSinglePlayer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.rbSinglePlayer.ForeColor = System.Drawing.Color.White;
      this.rbSinglePlayer.Location = new System.Drawing.Point(6, 26);
      this.rbSinglePlayer.Name = "rbSinglePlayer";
      this.rbSinglePlayer.Size = new System.Drawing.Size(136, 24);
      this.rbSinglePlayer.TabIndex = 1;
      this.rbSinglePlayer.TabStop = true;
      this.rbSinglePlayer.Text = "SINGLEPLAYER";
      this.rbSinglePlayer.UseVisualStyleBackColor = true;
      this.rbSinglePlayer.CheckedChanged += new System.EventHandler(this.PlayerCount_CheckedChanged);
      // 
      // rbDoublePlayer
      // 
      this.rbDoublePlayer.AutoSize = true;
      this.rbDoublePlayer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbDoublePlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbDoublePlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
      this.rbDoublePlayer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.rbDoublePlayer.ForeColor = System.Drawing.Color.White;
      this.rbDoublePlayer.Location = new System.Drawing.Point(6, 56);
      this.rbDoublePlayer.Name = "rbDoublePlayer";
      this.rbDoublePlayer.Size = new System.Drawing.Size(143, 24);
      this.rbDoublePlayer.TabIndex = 0;
      this.rbDoublePlayer.Text = "DOUBLEPLAYER";
      this.rbDoublePlayer.UseVisualStyleBackColor = true;
      this.rbDoublePlayer.CheckedChanged += new System.EventHandler(this.PlayerCount_CheckedChanged);
      // 
      // groupBoxSideChoose
      // 
      this.groupBoxSideChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxSideChoose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(96)))));
      this.groupBoxSideChoose.Controls.Add(this.rbPlayerWhite);
      this.groupBoxSideChoose.Controls.Add(this.rbPlayerBlack);
      this.groupBoxSideChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.groupBoxSideChoose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.groupBoxSideChoose.Location = new System.Drawing.Point(12, 119);
      this.groupBoxSideChoose.Name = "groupBoxSideChoose";
      this.groupBoxSideChoose.Size = new System.Drawing.Size(515, 97);
      this.groupBoxSideChoose.TabIndex = 3;
      this.groupBoxSideChoose.TabStop = false;
      this.groupBoxSideChoose.Text = "Player";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(539, 295);
      this.Controls.Add(this.panel1);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.panel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBoxSideChoose.ResumeLayout(false);
      this.groupBoxSideChoose.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RadioButton rbPlayerBlack;
    private System.Windows.Forms.RadioButton rbPlayerWhite;
    private System.Windows.Forms.Button btnPlay;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBoxSideChoose;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton rbSinglePlayer;
    private System.Windows.Forms.RadioButton rbDoublePlayer;
  }
}

