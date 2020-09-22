namespace GeneticSolver
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
            this.Gen1 = new System.Windows.Forms.TextBox();
            this.Gen2 = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Gen1
            // 
            this.Gen1.Location = new System.Drawing.Point(12, 22);
            this.Gen1.Name = "Gen1";
            this.Gen1.Size = new System.Drawing.Size(244, 20);
            this.Gen1.TabIndex = 0;
            // 
            // Gen2
            // 
            this.Gen2.Location = new System.Drawing.Point(544, 22);
            this.Gen2.Name = "Gen2";
            this.Gen2.Size = new System.Drawing.Size(244, 20);
            this.Gen2.TabIndex = 1;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(291, 22);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(220, 72);
            this.GenerateButton.TabIndex = 2;
            this.GenerateButton.Text = "Genrate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.Gen2);
            this.Controls.Add(this.Gen1);
            this.Name = "Form1";
            this.Text = "GeneticSolver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Gen1;
        private System.Windows.Forms.TextBox Gen2;
        private System.Windows.Forms.Button GenerateButton;
    }
}

