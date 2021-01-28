
namespace Inject.Net
{
  partial class FormMain
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
      this.label1 = new System.Windows.Forms.Label();
      this.cmbx_Processes = new System.Windows.Forms.ComboBox();
      this.btn_Refresh = new System.Windows.Forms.Button();
      this.rdbtn_Framework = new System.Windows.Forms.RadioButton();
      this.label2 = new System.Windows.Forms.Label();
      this.rdbtn_Core = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this.txt_DllPath = new System.Windows.Forms.TextBox();
      this.btn_DllPathBrowse = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.btn_RuntimeConfigPathBrowse = new System.Windows.Forms.Button();
      this.txt_RuntimeConfigPath = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txt_Type = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txt_Method = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txt_Arguement = new System.Windows.Forms.TextBox();
      this.btn_Inject = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(48, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Process:";
      // 
      // cmbx_Processes
      // 
      this.cmbx_Processes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbx_Processes.FormattingEnabled = true;
      this.cmbx_Processes.Location = new System.Drawing.Point(116, 9);
      this.cmbx_Processes.Name = "cmbx_Processes";
      this.cmbx_Processes.Size = new System.Drawing.Size(232, 21);
      this.cmbx_Processes.TabIndex = 1;
      this.cmbx_Processes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbx_Processes_Format);
      // 
      // btn_Refresh
      // 
      this.btn_Refresh.Location = new System.Drawing.Point(354, 9);
      this.btn_Refresh.Name = "btn_Refresh";
      this.btn_Refresh.Size = new System.Drawing.Size(56, 21);
      this.btn_Refresh.TabIndex = 2;
      this.btn_Refresh.Text = "Refresh";
      this.btn_Refresh.UseVisualStyleBackColor = true;
      this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
      // 
      // rdbtn_Framework
      // 
      this.rdbtn_Framework.AutoSize = true;
      this.rdbtn_Framework.Checked = true;
      this.rdbtn_Framework.Location = new System.Drawing.Point(116, 38);
      this.rdbtn_Framework.Name = "rdbtn_Framework";
      this.rdbtn_Framework.Size = new System.Drawing.Size(78, 17);
      this.rdbtn_Framework.TabIndex = 3;
      this.rdbtn_Framework.TabStop = true;
      this.rdbtn_Framework.Text = "Framework";
      this.rdbtn_Framework.UseVisualStyleBackColor = true;
      this.rdbtn_Framework.CheckedChanged += new System.EventHandler(this.rdbtn_Framework_CheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Runtime:";
      // 
      // rdbtn_Core
      // 
      this.rdbtn_Core.AutoSize = true;
      this.rdbtn_Core.Location = new System.Drawing.Point(300, 38);
      this.rdbtn_Core.Name = "rdbtn_Core";
      this.rdbtn_Core.Size = new System.Drawing.Size(48, 17);
      this.rdbtn_Core.TabIndex = 4;
      this.rdbtn_Core.Text = "Core";
      this.rdbtn_Core.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 67);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Dll Path:";
      // 
      // txt_DllPath
      // 
      this.txt_DllPath.Location = new System.Drawing.Point(116, 64);
      this.txt_DllPath.Name = "txt_DllPath";
      this.txt_DllPath.ReadOnly = true;
      this.txt_DllPath.Size = new System.Drawing.Size(232, 20);
      this.txt_DllPath.TabIndex = 5;
      // 
      // btn_DllPathBrowse
      // 
      this.btn_DllPathBrowse.Location = new System.Drawing.Point(354, 63);
      this.btn_DllPathBrowse.Name = "btn_DllPathBrowse";
      this.btn_DllPathBrowse.Size = new System.Drawing.Size(56, 21);
      this.btn_DllPathBrowse.TabIndex = 6;
      this.btn_DllPathBrowse.Text = "Browse";
      this.btn_DllPathBrowse.UseVisualStyleBackColor = true;
      this.btn_DllPathBrowse.Click += new System.EventHandler(this.btn_DllPathBrowse_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Enabled = false;
      this.label4.Location = new System.Drawing.Point(9, 94);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(101, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "runtimeconfig Path:";
      // 
      // btn_RuntimeConfigPathBrowse
      // 
      this.btn_RuntimeConfigPathBrowse.Enabled = false;
      this.btn_RuntimeConfigPathBrowse.Location = new System.Drawing.Point(354, 90);
      this.btn_RuntimeConfigPathBrowse.Name = "btn_RuntimeConfigPathBrowse";
      this.btn_RuntimeConfigPathBrowse.Size = new System.Drawing.Size(56, 21);
      this.btn_RuntimeConfigPathBrowse.TabIndex = 8;
      this.btn_RuntimeConfigPathBrowse.Text = "Browse";
      this.btn_RuntimeConfigPathBrowse.UseVisualStyleBackColor = true;
      this.btn_RuntimeConfigPathBrowse.Click += new System.EventHandler(this.btn_RuntimeConfigPathBrowse_Click);
      // 
      // txt_RuntimeConfigPath
      // 
      this.txt_RuntimeConfigPath.Enabled = false;
      this.txt_RuntimeConfigPath.Location = new System.Drawing.Point(116, 91);
      this.txt_RuntimeConfigPath.Name = "txt_RuntimeConfigPath";
      this.txt_RuntimeConfigPath.ReadOnly = true;
      this.txt_RuntimeConfigPath.Size = new System.Drawing.Size(232, 20);
      this.txt_RuntimeConfigPath.TabIndex = 7;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(9, 120);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(35, 13);
      this.label5.TabIndex = 0;
      this.label5.Text = "Type:";
      // 
      // txt_Type
      // 
      this.txt_Type.Location = new System.Drawing.Point(116, 117);
      this.txt_Type.Name = "txt_Type";
      this.txt_Type.Size = new System.Drawing.Size(232, 20);
      this.txt_Type.TabIndex = 9;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(9, 146);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(47, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "Method:";
      // 
      // txt_Method
      // 
      this.txt_Method.Location = new System.Drawing.Point(116, 143);
      this.txt_Method.Name = "txt_Method";
      this.txt_Method.Size = new System.Drawing.Size(232, 20);
      this.txt_Method.TabIndex = 10;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(9, 172);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(64, 13);
      this.label7.TabIndex = 0;
      this.label7.Text = "Arguement:";
      // 
      // txt_Arguement
      // 
      this.txt_Arguement.Location = new System.Drawing.Point(116, 169);
      this.txt_Arguement.Name = "txt_Arguement";
      this.txt_Arguement.Size = new System.Drawing.Size(232, 20);
      this.txt_Arguement.TabIndex = 11;
      // 
      // btn_Inject
      // 
      this.btn_Inject.Font = new System.Drawing.Font("Tahoma", 7F);
      this.btn_Inject.Location = new System.Drawing.Point(354, 169);
      this.btn_Inject.Name = "btn_Inject";
      this.btn_Inject.Size = new System.Drawing.Size(56, 20);
      this.btn_Inject.TabIndex = 12;
      this.btn_Inject.Text = "Inject";
      this.btn_Inject.UseVisualStyleBackColor = true;
      this.btn_Inject.Click += new System.EventHandler(this.btn_Inject_Click);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(422, 201);
      this.Controls.Add(this.btn_Inject);
      this.Controls.Add(this.txt_Arguement);
      this.Controls.Add(this.txt_Method);
      this.Controls.Add(this.txt_Type);
      this.Controls.Add(this.txt_RuntimeConfigPath);
      this.Controls.Add(this.txt_DllPath);
      this.Controls.Add(this.rdbtn_Core);
      this.Controls.Add(this.rdbtn_Framework);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.btn_RuntimeConfigPathBrowse);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.btn_DllPathBrowse);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btn_Refresh);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cmbx_Processes);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "FormMain";
      this.Text = "Inject.Net";
      this.Shown += new System.EventHandler(this.FormMain_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbx_Processes;
    private System.Windows.Forms.Button btn_Refresh;
    private System.Windows.Forms.RadioButton rdbtn_Framework;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.RadioButton rdbtn_Core;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txt_DllPath;
    private System.Windows.Forms.Button btn_DllPathBrowse;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btn_RuntimeConfigPathBrowse;
    private System.Windows.Forms.TextBox txt_RuntimeConfigPath;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txt_Type;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txt_Method;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txt_Arguement;
    private System.Windows.Forms.Button btn_Inject;
  }
}

