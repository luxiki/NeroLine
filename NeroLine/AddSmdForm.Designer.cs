namespace Nero_Wiev
{
    partial class AddSmdForm
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
            this.tbNameSmd = new System.Windows.Forms.TextBox();
            this.tbRotateSmd = new System.Windows.Forms.TextBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNameSmd
            // 
            this.tbNameSmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNameSmd.Location = new System.Drawing.Point(21, 12);
            this.tbNameSmd.MaxLength = 24;
            this.tbNameSmd.Name = "tbNameSmd";
            this.tbNameSmd.Size = new System.Drawing.Size(241, 20);
            this.tbNameSmd.TabIndex = 0;
            this.tbNameSmd.Text = "Название компонента";
            // 
            // tbRotateSmd
            // 
            this.tbRotateSmd.Location = new System.Drawing.Point(21, 46);
            this.tbRotateSmd.MaxLength = 4;
            this.tbRotateSmd.Name = "tbRotateSmd";
            this.tbRotateSmd.Size = new System.Drawing.Size(61, 20);
            this.tbRotateSmd.TabIndex = 1;
            this.tbRotateSmd.Text = "Угол";
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(187, 46);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 2;
            this.butAdd.Text = "Добавить";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // AddSmdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.tbRotateSmd);
            this.Controls.Add(this.tbNameSmd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSmdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление компонента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNameSmd;
        private System.Windows.Forms.TextBox tbRotateSmd;
        private System.Windows.Forms.Button butAdd;
    }
}