﻿namespace GUIforNeuron
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InputDirectory = new System.Windows.Forms.Button();
            this.OutputConsole = new System.Windows.Forms.TextBox();
            this.FistLayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(35, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // InputDirectory
            // 
            this.InputDirectory.Location = new System.Drawing.Point(619, 28);
            this.InputDirectory.Name = "InputDirectory";
            this.InputDirectory.Size = new System.Drawing.Size(232, 23);
            this.InputDirectory.TabIndex = 1;
            this.InputDirectory.Text = "Open file";
            this.InputDirectory.UseVisualStyleBackColor = true;
            this.InputDirectory.Click += new System.EventHandler(this.InputDirectory_Click);
            // 
            // OutputConsole
            // 
            this.OutputConsole.Location = new System.Drawing.Point(552, 246);
            this.OutputConsole.Multiline = true;
            this.OutputConsole.Name = "OutputConsole";
            this.OutputConsole.Size = new System.Drawing.Size(365, 262);
            this.OutputConsole.TabIndex = 2;
            // 
            // FistLayer
            // 
            this.FistLayer.Location = new System.Drawing.Point(619, 57);
            this.FistLayer.Name = "FistLayer";
            this.FistLayer.Size = new System.Drawing.Size(232, 23);
            this.FistLayer.TabIndex = 3;
            this.FistLayer.Text = "Fist layer";
            this.FistLayer.UseVisualStyleBackColor = true;
            this.FistLayer.Click += new System.EventHandler(this.FistLayer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 541);
            this.Controls.Add(this.FistLayer);
            this.Controls.Add(this.OutputConsole);
            this.Controls.Add(this.InputDirectory);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button InputDirectory;
        private System.Windows.Forms.TextBox OutputConsole;
        private System.Windows.Forms.Button FistLayer;
    }
}

