
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
      this.boradGrid = new System.Windows.Forms.TableLayoutPanel();
      this.lblPointsWhite = new System.Windows.Forms.Label();
      this.lblPointsBlack = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.boradGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.boradGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.boradGrid.ColumnCount = 8;
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.Location = new System.Drawing.Point(12, 53);
      this.boradGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.boradGrid.Name = "tableLayoutPanel1";
      this.boradGrid.RowCount = 8;
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
      this.boradGrid.Size = new System.Drawing.Size(855, 863);
      this.boradGrid.TabIndex = 0;
      // 
      // lblPointsWhite
      // 
      this.lblPointsWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblPointsWhite.AutoSize = true;
      this.lblPointsWhite.Location = new System.Drawing.Point(12, 940);
      this.lblPointsWhite.Name = "lblPointsWhite";
      this.lblPointsWhite.Size = new System.Drawing.Size(17, 20);
      this.lblPointsWhite.TabIndex = 5;
      this.lblPointsWhite.Text = "0";
      // 
      // lblPointsBlack
      // 
      this.lblPointsBlack.AutoSize = true;
      this.lblPointsBlack.Location = new System.Drawing.Point(12, 9);
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
      this.Controls.Add(this.boradGrid);
      this.Name = "GameForm";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel boradGrid;
    private System.Windows.Forms.Label lblPointsWhite;
    private System.Windows.Forms.Label lblPointsBlack;
  }
}

