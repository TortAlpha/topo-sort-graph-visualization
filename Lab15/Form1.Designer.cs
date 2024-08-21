namespace Lab15
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
            components = new System.ComponentModel.Container();
            addNodeButton = new Button();
            addNodeLable = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            saveButton = new Button();
            loadButton = new Button();
            sortedTextBox = new TextBox();
            sortButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // addNodeButton
            // 
            addNodeButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addNodeButton.Location = new Point(77, 31);
            addNodeButton.Margin = new Padding(2, 1, 2, 1);
            addNodeButton.Name = "addNodeButton";
            addNodeButton.Size = new Size(81, 29);
            addNodeButton.TabIndex = 0;
            addNodeButton.Text = "Add";
            addNodeButton.UseVisualStyleBackColor = true;
            addNodeButton.Click += addNodeButton_Click;
            // 
            // addNodeLable
            // 
            addNodeLable.AutoSize = true;
            addNodeLable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addNodeLable.Location = new Point(62, 9);
            addNodeLable.Margin = new Padding(2, 0, 2, 0);
            addNodeLable.Name = "addNodeLable";
            addNodeLable.Size = new Size(110, 21);
            addNodeLable.TabIndex = 1;
            addNodeLable.Text = "Add new node";
            addNodeLable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 72);
            pictureBox1.Margin = new Padding(2, 1, 2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1330, 510);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1097, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 3;
            label1.Text = "Save to file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1208, 9);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 21);
            label2.TabIndex = 4;
            label2.Text = "Load form file";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(524, 9);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 21);
            label3.TabIndex = 5;
            label3.Text = "Sorted Graph";
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            saveButton.Location = new Point(1097, 32);
            saveButton.Margin = new Padding(2, 1, 2, 1);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(81, 30);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // loadButton
            // 
            loadButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loadButton.Location = new Point(1221, 32);
            loadButton.Margin = new Padding(2, 1, 2, 1);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(81, 30);
            loadButton.TabIndex = 7;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // sortedTextBox
            // 
            sortedTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sortedTextBox.Location = new Point(203, 32);
            sortedTextBox.Margin = new Padding(2, 1, 2, 1);
            sortedTextBox.Name = "sortedTextBox";
            sortedTextBox.Size = new Size(740, 29);
            sortedTextBox.TabIndex = 8;
            sortedTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // sortButton
            // 
            sortButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sortButton.Location = new Point(947, 32);
            sortButton.Margin = new Padding(2, 1, 2, 1);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(81, 30);
            sortButton.TabIndex = 9;
            sortButton.Text = "Sort";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 580);
            Controls.Add(sortButton);
            Controls.Add(sortedTextBox);
            Controls.Add(loadButton);
            Controls.Add(saveButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(addNodeLable);
            Controls.Add(addNodeButton);
            DoubleBuffered = true;
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Graph";
            Paint += Form1_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addNodeButton;
        private Label addNodeLable;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button saveButton;
        private Button loadButton;
        private TextBox sortedTextBox;
        private Button sortButton;
    }
}
