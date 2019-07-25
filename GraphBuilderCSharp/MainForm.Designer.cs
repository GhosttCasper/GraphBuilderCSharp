namespace GraphBuilderCSharp
{
    partial class MainForm
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.GraphFieldPanel = new GraphBuilderCSharp.DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.AutoSize = true;
            this.buttonLoad.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLoad.Location = new System.Drawing.Point(15, 15);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 28);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load Graph";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // GraphFieldPanel
            // 
            this.GraphFieldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphFieldPanel.AutoSize = true;
            this.GraphFieldPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GraphFieldPanel.Location = new System.Drawing.Point(15, 50);
            this.GraphFieldPanel.MaximumSize = new System.Drawing.Size(1350, 700);
            this.GraphFieldPanel.Name = "GraphFieldPanel";
            this.GraphFieldPanel.Size = new System.Drawing.Size(755, 430);
            this.GraphFieldPanel.TabIndex = 0;
            this.GraphFieldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphFieldPanel_Paint);
            this.GraphFieldPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphFieldPanel_MouseDown);
            this.GraphFieldPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphFieldPanel_MouseMove);
            this.GraphFieldPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphFieldPanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.GraphFieldPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Graph Builder";
            this.AutoSizeChanged += new System.EventHandler(this.MainForm_AutoSizeChanged);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private DoubleBufferedPanel GraphFieldPanel;
    }
}

