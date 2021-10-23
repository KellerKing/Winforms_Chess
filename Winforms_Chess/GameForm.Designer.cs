
namespace Winforms_Chess
{
  partial class GameForm
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.pbPointsWhite = new System.Windows.Forms.PictureBox();
      this.pbPlayerBlack = new System.Windows.Forms.PictureBox();
      this.lblPointsWhite = new System.Windows.Forms.Label();
      this.lblPointsBlack = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pbPointsWhite)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbPlayerBlack)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.tableLayoutPanel1.ColumnCount = 8;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 53);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 863);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // pbPointsWhite
      // 
      this.pbPointsWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.pbPointsWhite.Location = new System.Drawing.Point(12, 923);
      this.pbPointsWhite.Name = "pbPointsWhite";
      this.pbPointsWhite.Size = new System.Drawing.Size(125, 34);
      this.pbPointsWhite.TabIndex = 3;
      this.pbPointsWhite.TabStop = false;
      // 
      // pbPlayerBlack
      // 
      this.pbPlayerBlack.Location = new System.Drawing.Point(12, 12);
      this.pbPlayerBlack.Name = "pbPlayerBlack";
      this.pbPlayerBlack.Size = new System.Drawing.Size(125, 34);
      this.pbPlayerBlack.TabIndex = 4;
      this.pbPlayerBlack.TabStop = false;
      // 
      // lblPointsWhite
      // 
      this.lblPointsWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblPointsWhite.AutoSize = true;
      this.lblPointsWhite.Location = new System.Drawing.Point(152, 937);
      this.lblPointsWhite.Name = "lblPointsWhite";
      this.lblPointsWhite.Size = new System.Drawing.Size(17, 20);
      this.lblPointsWhite.TabIndex = 5;
      this.lblPointsWhite.Text = "0";
      // 
      // lblPointsBlack
      // 
      this.lblPointsBlack.AutoSize = true;
      this.lblPointsBlack.Location = new System.Drawing.Point(152, 12);
      this.lblPointsBlack.Name = "lblPointsBlack";
      this.lblPointsBlack.Size = new System.Drawing.Size(17, 20);
      this.lblPointsBlack.TabIndex = 6;
      this.lblPointsBlack.Text = "0";
      // 
      // GameForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(879, 969);
      this.Controls.Add(this.lblPointsBlack);
      this.Controls.Add(this.lblPointsWhite);
      this.Controls.Add(this.pbPlayerBlack);
      this.Controls.Add(this.pbPointsWhite);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "GameForm";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pbPointsWhite)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbPlayerBlack)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox pbPointsWhite;
    private System.Windows.Forms.PictureBox pbPlayerBlack;
    private System.Windows.Forms.Label lblPointsWhite;
    private System.Windows.Forms.Label lblPointsBlack;
  }
}

