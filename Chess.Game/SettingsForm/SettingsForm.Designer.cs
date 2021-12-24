namespace Chess.Game.SettingsForm
{
  partial class SettingsForm
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
      this.buttonAccept = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.radioButtonHighlightOn = new System.Windows.Forms.RadioButton();
      this.radioButtonHighlightOff = new System.Windows.Forms.RadioButton();
      this.groupBoxPossibleFields = new System.Windows.Forms.GroupBox();
      this.groupBoxPossibleFields.SuspendLayout();
      this.SuspendLayout();
      // 
      // buttonAccept
      // 
      this.buttonAccept.Location = new System.Drawing.Point(118, 174);
      this.buttonAccept.Name = "buttonAccept";
      this.buttonAccept.Size = new System.Drawing.Size(94, 29);
      this.buttonAccept.TabIndex = 0;
      this.buttonAccept.Text = "OK";
      this.buttonAccept.UseVisualStyleBackColor = true;
      this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.Location = new System.Drawing.Point(18, 174);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(94, 29);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "EXIT";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // radioButtonHighlightOn
      // 
      this.radioButtonHighlightOn.AutoSize = true;
      this.radioButtonHighlightOn.Location = new System.Drawing.Point(6, 26);
      this.radioButtonHighlightOn.Name = "radioButtonHighlightOn";
      this.radioButtonHighlightOn.Size = new System.Drawing.Size(52, 24);
      this.radioButtonHighlightOn.TabIndex = 3;
      this.radioButtonHighlightOn.TabStop = true;
      this.radioButtonHighlightOn.Text = "ON";
      this.radioButtonHighlightOn.UseVisualStyleBackColor = true;
      // 
      // radioButtonHighlightOff
      // 
      this.radioButtonHighlightOff.AutoSize = true;
      this.radioButtonHighlightOff.Location = new System.Drawing.Point(64, 26);
      this.radioButtonHighlightOff.Name = "radioButtonHighlightOff";
      this.radioButtonHighlightOff.Size = new System.Drawing.Size(55, 24);
      this.radioButtonHighlightOff.TabIndex = 4;
      this.radioButtonHighlightOff.TabStop = true;
      this.radioButtonHighlightOff.Text = "OFF";
      this.radioButtonHighlightOff.UseVisualStyleBackColor = true;
      // 
      // groupBoxPossibleFields
      // 
      this.groupBoxPossibleFields.Controls.Add(this.radioButtonHighlightOn);
      this.groupBoxPossibleFields.Controls.Add(this.radioButtonHighlightOff);
      this.groupBoxPossibleFields.Location = new System.Drawing.Point(12, 12);
      this.groupBoxPossibleFields.Name = "groupBoxPossibleFields";
      this.groupBoxPossibleFields.Size = new System.Drawing.Size(206, 66);
      this.groupBoxPossibleFields.TabIndex = 5;
      this.groupBoxPossibleFields.TabStop = false;
      this.groupBoxPossibleFields.Text = "Highlight possible Fields";
      // 
      // SettingsForm
      // 
      this.AcceptButton = this.buttonAccept;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(230, 215);
      this.Controls.Add(this.groupBoxPossibleFields);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonAccept);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SettingsForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "SettingsForm";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingsForm_Paint);
      this.groupBoxPossibleFields.ResumeLayout(false);
      this.groupBoxPossibleFields.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button buttonAccept;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.RadioButton radioButtonHighlightOn;
    private System.Windows.Forms.RadioButton radioButtonHighlightOff;
    private System.Windows.Forms.GroupBox groupBoxPossibleFields;
  }
}