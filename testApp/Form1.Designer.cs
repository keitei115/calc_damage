namespace testApp
{
    partial class Form1
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
            btnClick = new Button();
            label = new Label();
            inputX = new TextBox();
            inputY = new TextBox();
            SuspendLayout();
            // 
            // btnClick
            // 
            btnClick.Font = new Font("コーポレート・ロゴ（ラウンド）ver3 Bold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnClick.Location = new Point(255, 183);
            btnClick.Name = "btnClick";
            btnClick.Size = new Size(195, 98);
            btnClick.TabIndex = 0;
            btnClick.Text = "クリック";
            btnClick.UseVisualStyleBackColor = true;
            btnClick.Click += btnClick_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(581, 117);
            label.Name = "label";
            label.Size = new Size(38, 15);
            label.TabIndex = 1;
            label.Text = "label1";
            label.Click += label_Click;
            // 
            // inputX
            // 
            inputX.Location = new Point(202, 114);
            inputX.Name = "inputX";
            inputX.Size = new Size(100, 23);
            inputX.TabIndex = 2;
            inputX.KeyPress += inputX_KeyPress;
            // 
            // inputY
            // 
            inputY.Location = new Point(393, 114);
            inputY.Name = "inputY";
            inputY.Size = new Size(100, 23);
            inputY.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(inputY);
            Controls.Add(inputX);
            Controls.Add(label);
            Controls.Add(btnClick);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClick;
        private Label label;
        private TextBox inputX;
        private TextBox inputY;
    }
}