
namespace Winforms_Chess.PieceSelectForm
{
  partial class PieceSelectForm
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
      this.pictureBoxBishop = new System.Windows.Forms.PictureBox();
      this.pictureBoxKnight = new System.Windows.Forms.PictureBox();
      this.pictureBoxRook = new System.Windows.Forms.PictureBox();
      this.pictureBoxQueen = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBishop)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKnight)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRook)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQueen)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBoxBishop
      // 
      this.pictureBoxBishop.Location = new System.Drawing.Point(13, 13);
      this.pictureBoxBishop.Name = "pictureBoxBishop";
      this.pictureBoxBishop.Size = new System.Drawing.Size(100, 100);
      this.pictureBoxBishop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxBishop.TabIndex = 0;
      this.pictureBoxBishop.TabStop = false;
      this.pictureBoxBishop.Click += new System.EventHandler(this.pictureBox_Click);
      // 
      // pictureBoxKnight
      // 
      this.pictureBoxKnight.Location = new System.Drawing.Point(119, 13);
      this.pictureBoxKnight.Name = "pictureBoxKnight";
      this.pictureBoxKnight.Size = new System.Drawing.Size(100, 100);
      this.pictureBoxKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxKnight.TabIndex = 1;
      this.pictureBoxKnight.TabStop = false;
      this.pictureBoxKnight.Click += new System.EventHandler(this.pictureBox_Click);
      // 
      // pictureBoxRook
      // 
      this.pictureBoxRook.Location = new System.Drawing.Point(225, 12);
      this.pictureBoxRook.Name = "pictureBoxRook";
      this.pictureBoxRook.Size = new System.Drawing.Size(100, 100);
      this.pictureBoxRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxRook.TabIndex = 2;
      this.pictureBoxRook.TabStop = false;
      this.pictureBoxRook.Click += new System.EventHandler(this.pictureBox_Click);
      // 
      // pictureBoxQueen
      // 
      this.pictureBoxQueen.Location = new System.Drawing.Point(332, 12);
      this.pictureBoxQueen.Name = "pictureBoxQueen";
      this.pictureBoxQueen.Size = new System.Drawing.Size(100, 100);
      this.pictureBoxQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxQueen.TabIndex = 3;
      this.pictureBoxQueen.TabStop = false;
      this.pictureBoxQueen.Click += new System.EventHandler(this.pictureBox_Click);
      // 
      // PieceSelectForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
      this.ClientSize = new System.Drawing.Size(444, 128);
      this.Controls.Add(this.pictureBoxQueen);
      this.Controls.Add(this.pictureBoxRook);
      this.Controls.Add(this.pictureBoxKnight);
      this.Controls.Add(this.pictureBoxBishop);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "PieceSelectForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "PieceSelectForm";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBishop)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKnight)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRook)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQueen)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxBishop;
    private System.Windows.Forms.PictureBox pictureBoxKnight;
    private System.Windows.Forms.PictureBox pictureBoxRook;
    private System.Windows.Forms.PictureBox pictureBoxQueen;
  }
}