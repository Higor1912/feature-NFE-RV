namespace Order_Flow
{
    partial class form_excluir
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
            this.btn_excluirform = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_excluirform
            // 
            this.btn_excluirform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.btn_excluirform.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluirform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluirform.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_excluirform.Location = new System.Drawing.Point(98, 65);
            this.btn_excluirform.Name = "btn_excluirform";
            this.btn_excluirform.Size = new System.Drawing.Size(75, 23);
            this.btn_excluirform.TabIndex = 36;
            this.btn_excluirform.Text = "Excluir";
            this.btn_excluirform.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(216)))), ((int)(((byte)(227)))));
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 24);
            this.label7.TabIndex = 41;
            this.label7.Text = "ID/Chave do produto";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(3, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(264, 20);
            this.textBox2.TabIndex = 42;
            // 
            // form_excluir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(270, 104);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_excluirform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "form_excluir";
            this.Text = "form_excluir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_excluirform;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
    }
}