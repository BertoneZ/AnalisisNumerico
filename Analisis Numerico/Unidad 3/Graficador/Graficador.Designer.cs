
namespace Analisis_Numerico
{
    partial class Graficador
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxAxis = new PictureBox();
            pictureBoxContainer = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAxis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxContainer).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxAxis
            // 
            pictureBoxAxis.BackColor = Color.WhiteSmoke;
            pictureBoxAxis.Location = new Point(0, 0);
            pictureBoxAxis.Margin = new Padding(5, 6, 5, 6);
            pictureBoxAxis.Name = "pictureBoxAxis";
            pictureBoxAxis.Size = new Size(1667, 1923);
            pictureBoxAxis.TabIndex = 1;
            pictureBoxAxis.TabStop = false;
            // 
            // pictureBoxContainer
            // 
            pictureBoxContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxContainer.BackColor = Color.WhiteSmoke;
            pictureBoxContainer.Location = new Point(25, 48);
            pictureBoxContainer.Margin = new Padding(5, 6, 5, 6);
            pictureBoxContainer.Name = "pictureBoxContainer";
            pictureBoxContainer.Size = new Size(1538, 1878);
            pictureBoxContainer.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxContainer.TabIndex = 2;
            pictureBoxContainer.TabStop = false;
            // 
            // Graficador
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(pictureBoxContainer);
            Controls.Add(pictureBoxAxis);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Graficador";
            Size = new Size(1672, 1929);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAxis).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxContainer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAxis;
        private System.Windows.Forms.PictureBox pictureBoxContainer;
    }
}
