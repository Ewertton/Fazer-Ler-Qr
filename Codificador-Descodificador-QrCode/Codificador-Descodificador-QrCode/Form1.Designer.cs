namespace Codificador_Descodificador_QrCode
{
    partial class Form1
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
            this.criar = new System.Windows.Forms.Button();
            this.ler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // criar
            // 
            this.criar.Location = new System.Drawing.Point(48, 162);
            this.criar.Name = "criar";
            this.criar.Size = new System.Drawing.Size(113, 37);
            this.criar.TabIndex = 0;
            this.criar.Text = "Create Qr";
            this.criar.UseVisualStyleBackColor = true;
            this.criar.Click += new System.EventHandler(this.criar_Click);
            // 
            // ler
            // 
            this.ler.Location = new System.Drawing.Point(231, 162);
            this.ler.Name = "ler";
            this.ler.Size = new System.Drawing.Size(113, 37);
            this.ler.TabIndex = 1;
            this.ler.Text = "Read Qr";
            this.ler.UseVisualStyleBackColor = true;
            this.ler.Click += new System.EventHandler(this.ler_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 273);
            this.Controls.Add(this.ler);
            this.Controls.Add(this.criar);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "QrCode-Encoder-Decoder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button criar;
        private System.Windows.Forms.Button ler;
    }
}

