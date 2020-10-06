namespace affine_transformation
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
            this.imageToDrawBox = new System.Windows.Forms.PictureBox();
            this.ClearListButton = new System.Windows.Forms.Button();
            this.LineRadioButton = new System.Windows.Forms.RadioButton();
            this.drawingGroupBox = new System.Windows.Forms.GroupBox();
            this.DotRadioButton = new System.Windows.Forms.RadioButton();
            this.PolygonRadioButton = new System.Windows.Forms.RadioButton();
            this.polygonGroupBox = new System.Windows.Forms.GroupBox();
            this.scalePolygonAroundPointRadioButton = new System.Windows.Forms.RadioButton();
            this.scalePolygonAroundCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.rotatePolygonAroundPointRadioButton = new System.Windows.Forms.RadioButton();
            this.rotatePolygonAroundCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.movePolygonRadioButton = new System.Windows.Forms.RadioButton();
            this.lineGroupBox = new System.Windows.Forms.GroupBox();
            this.findCrossRadioButton = new System.Windows.Forms.RadioButton();
            this.rotateLineRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageToDrawBox)).BeginInit();
            this.drawingGroupBox.SuspendLayout();
            this.polygonGroupBox.SuspendLayout();
            this.lineGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageToDrawBox
            // 
            this.imageToDrawBox.Location = new System.Drawing.Point(220, 0);
            this.imageToDrawBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.imageToDrawBox.Name = "imageToDrawBox";
            this.imageToDrawBox.Size = new System.Drawing.Size(588, 378);
            this.imageToDrawBox.TabIndex = 7;
            this.imageToDrawBox.TabStop = false;
            this.imageToDrawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageToDrawBox_MouseDown_1);
            this.imageToDrawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageToDrawBox_MouseUp);
            // 
            // ClearListButton
            // 
            this.ClearListButton.Location = new System.Drawing.Point(21, 318);
            this.ClearListButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ClearListButton.Name = "ClearListButton";
            this.ClearListButton.Size = new System.Drawing.Size(175, 45);
            this.ClearListButton.TabIndex = 8;
            this.ClearListButton.Text = "Очистить";
            this.ClearListButton.UseVisualStyleBackColor = true;
            this.ClearListButton.Click += new System.EventHandler(this.ClearListButton_Click_1);
            // 
            // LineRadioButton
            // 
            this.LineRadioButton.AutoSize = true;
            this.LineRadioButton.Checked = true;
            this.LineRadioButton.Location = new System.Drawing.Point(16, 23);
            this.LineRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LineRadioButton.Name = "LineRadioButton";
            this.LineRadioButton.Size = new System.Drawing.Size(59, 17);
            this.LineRadioButton.TabIndex = 2;
            this.LineRadioButton.TabStop = true;
            this.LineRadioButton.Text = "Линия";
            this.LineRadioButton.UseVisualStyleBackColor = true;
            this.LineRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // drawingGroupBox
            // 
            this.drawingGroupBox.Controls.Add(this.DotRadioButton);
            this.drawingGroupBox.Controls.Add(this.PolygonRadioButton);
            this.drawingGroupBox.Controls.Add(this.LineRadioButton);
            this.drawingGroupBox.Location = new System.Drawing.Point(5, 3);
            this.drawingGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.drawingGroupBox.Name = "drawingGroupBox";
            this.drawingGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.drawingGroupBox.Size = new System.Drawing.Size(211, 94);
            this.drawingGroupBox.TabIndex = 6;
            this.drawingGroupBox.TabStop = false;
            this.drawingGroupBox.Text = "Рисование";
            // 
            // DotRadioButton
            // 
            this.DotRadioButton.AutoSize = true;
            this.DotRadioButton.Location = new System.Drawing.Point(16, 66);
            this.DotRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DotRadioButton.Name = "DotRadioButton";
            this.DotRadioButton.Size = new System.Drawing.Size(56, 17);
            this.DotRadioButton.TabIndex = 4;
            this.DotRadioButton.TabStop = true;
            this.DotRadioButton.Text = "Точка";
            this.DotRadioButton.UseVisualStyleBackColor = true;
            this.DotRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // PolygonRadioButton
            // 
            this.PolygonRadioButton.AutoSize = true;
            this.PolygonRadioButton.Location = new System.Drawing.Point(16, 45);
            this.PolygonRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PolygonRadioButton.Name = "PolygonRadioButton";
            this.PolygonRadioButton.Size = new System.Drawing.Size(110, 17);
            this.PolygonRadioButton.TabIndex = 3;
            this.PolygonRadioButton.Text = "Многоугольник";
            this.PolygonRadioButton.UseVisualStyleBackColor = true;
            this.PolygonRadioButton.Click += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // polygonGroupBox
            // 
            this.polygonGroupBox.Controls.Add(this.scalePolygonAroundPointRadioButton);
            this.polygonGroupBox.Controls.Add(this.scalePolygonAroundCenterRadioButton);
            this.polygonGroupBox.Controls.Add(this.rotatePolygonAroundPointRadioButton);
            this.polygonGroupBox.Controls.Add(this.rotatePolygonAroundCenterRadioButton);
            this.polygonGroupBox.Controls.Add(this.movePolygonRadioButton);
            this.polygonGroupBox.Location = new System.Drawing.Point(5, 101);
            this.polygonGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.polygonGroupBox.Name = "polygonGroupBox";
            this.polygonGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.polygonGroupBox.Size = new System.Drawing.Size(211, 134);
            this.polygonGroupBox.TabIndex = 9;
            this.polygonGroupBox.TabStop = false;
            this.polygonGroupBox.Text = "Полигоны";
            // 
            // scalePolygonAroundPointRadioButton
            // 
            this.scalePolygonAroundPointRadioButton.AutoSize = true;
            this.scalePolygonAroundPointRadioButton.Location = new System.Drawing.Point(16, 110);
            this.scalePolygonAroundPointRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scalePolygonAroundPointRadioButton.Name = "scalePolygonAroundPointRadioButton";
            this.scalePolygonAroundPointRadioButton.Size = new System.Drawing.Size(200, 17);
            this.scalePolygonAroundPointRadioButton.TabIndex = 6;
            this.scalePolygonAroundPointRadioButton.Text = "Масштабирование вокруг точки";
            this.scalePolygonAroundPointRadioButton.UseVisualStyleBackColor = true;
            this.scalePolygonAroundPointRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // scalePolygonAroundCenterRadioButton
            // 
            this.scalePolygonAroundCenterRadioButton.AutoSize = true;
            this.scalePolygonAroundCenterRadioButton.Location = new System.Drawing.Point(16, 88);
            this.scalePolygonAroundCenterRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scalePolygonAroundCenterRadioButton.Name = "scalePolygonAroundCenterRadioButton";
            this.scalePolygonAroundCenterRadioButton.Size = new System.Drawing.Size(206, 17);
            this.scalePolygonAroundCenterRadioButton.TabIndex = 5;
            this.scalePolygonAroundCenterRadioButton.Text = "Масштабирование вокруг центра";
            this.scalePolygonAroundCenterRadioButton.UseVisualStyleBackColor = true;
            this.scalePolygonAroundCenterRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rotatePolygonAroundPointRadioButton
            // 
            this.rotatePolygonAroundPointRadioButton.AutoSize = true;
            this.rotatePolygonAroundPointRadioButton.Location = new System.Drawing.Point(16, 66);
            this.rotatePolygonAroundPointRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rotatePolygonAroundPointRadioButton.Name = "rotatePolygonAroundPointRadioButton";
            this.rotatePolygonAroundPointRadioButton.Size = new System.Drawing.Size(146, 17);
            this.rotatePolygonAroundPointRadioButton.TabIndex = 4;
            this.rotatePolygonAroundPointRadioButton.Text = "Поворот вокруг точки";
            this.rotatePolygonAroundPointRadioButton.UseVisualStyleBackColor = true;
            this.rotatePolygonAroundPointRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rotatePolygonAroundCenterRadioButton
            // 
            this.rotatePolygonAroundCenterRadioButton.AutoSize = true;
            this.rotatePolygonAroundCenterRadioButton.Location = new System.Drawing.Point(16, 45);
            this.rotatePolygonAroundCenterRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rotatePolygonAroundCenterRadioButton.Name = "rotatePolygonAroundCenterRadioButton";
            this.rotatePolygonAroundCenterRadioButton.Size = new System.Drawing.Size(152, 17);
            this.rotatePolygonAroundCenterRadioButton.TabIndex = 3;
            this.rotatePolygonAroundCenterRadioButton.Text = "Поворот вокруг центра";
            this.rotatePolygonAroundCenterRadioButton.UseVisualStyleBackColor = true;
            this.rotatePolygonAroundCenterRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // movePolygonRadioButton
            // 
            this.movePolygonRadioButton.AutoSize = true;
            this.movePolygonRadioButton.Location = new System.Drawing.Point(16, 23);
            this.movePolygonRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.movePolygonRadioButton.Name = "movePolygonRadioButton";
            this.movePolygonRadioButton.Size = new System.Drawing.Size(81, 17);
            this.movePolygonRadioButton.TabIndex = 2;
            this.movePolygonRadioButton.Text = "Смещение";
            this.movePolygonRadioButton.UseVisualStyleBackColor = true;
            this.movePolygonRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lineGroupBox
            // 
            this.lineGroupBox.Controls.Add(this.findCrossRadioButton);
            this.lineGroupBox.Controls.Add(this.rotateLineRadioButton);
            this.lineGroupBox.Location = new System.Drawing.Point(5, 238);
            this.lineGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineGroupBox.Name = "lineGroupBox";
            this.lineGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineGroupBox.Size = new System.Drawing.Size(211, 65);
            this.lineGroupBox.TabIndex = 10;
            this.lineGroupBox.TabStop = false;
            this.lineGroupBox.Text = "Отрезки";
            // 
            // findCrossRadioButton
            // 
            this.findCrossRadioButton.AutoSize = true;
            this.findCrossRadioButton.Location = new System.Drawing.Point(16, 36);
            this.findCrossRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findCrossRadioButton.Name = "findCrossRadioButton";
            this.findCrossRadioButton.Size = new System.Drawing.Size(166, 17);
            this.findCrossRadioButton.TabIndex = 12;
            this.findCrossRadioButton.TabStop = true;
            this.findCrossRadioButton.Text = "Поиск точки пересечения";
            this.findCrossRadioButton.UseVisualStyleBackColor = true;
            this.findCrossRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rotateLineRadioButton
            // 
            this.rotateLineRadioButton.AutoSize = true;
            this.rotateLineRadioButton.Location = new System.Drawing.Point(16, 16);
            this.rotateLineRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotateLineRadioButton.Name = "rotateLineRadioButton";
            this.rotateLineRadioButton.Size = new System.Drawing.Size(209, 17);
            this.rotateLineRadioButton.TabIndex = 11;
            this.rotateLineRadioButton.TabStop = true;
            this.rotateLineRadioButton.Text = "Поворот на 90 градусов от центра";
            this.rotateLineRadioButton.UseVisualStyleBackColor = true;
            this.rotateLineRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 407);
            this.Controls.Add(this.lineGroupBox);
            this.Controls.Add(this.polygonGroupBox);
            this.Controls.Add(this.ClearListButton);
            this.Controls.Add(this.imageToDrawBox);
            this.Controls.Add(this.drawingGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Task";
            ((System.ComponentModel.ISupportInitialize)(this.imageToDrawBox)).EndInit();
            this.drawingGroupBox.ResumeLayout(false);
            this.drawingGroupBox.PerformLayout();
            this.polygonGroupBox.ResumeLayout(false);
            this.polygonGroupBox.PerformLayout();
            this.lineGroupBox.ResumeLayout(false);
            this.lineGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox drawingGroupBox;
        private System.Windows.Forms.RadioButton DotRadioButton;
        private System.Windows.Forms.RadioButton PolygonRadioButton;
        private System.Windows.Forms.RadioButton LineRadioButton;
        private System.Windows.Forms.GroupBox polygonGroupBox;
        private System.Windows.Forms.RadioButton scalePolygonAroundPointRadioButton;
        private System.Windows.Forms.RadioButton scalePolygonAroundCenterRadioButton;
        private System.Windows.Forms.RadioButton rotatePolygonAroundPointRadioButton;
        private System.Windows.Forms.RadioButton rotatePolygonAroundCenterRadioButton;
        private System.Windows.Forms.RadioButton movePolygonRadioButton;
        public System.Windows.Forms.PictureBox imageToDrawBox;
        private System.Windows.Forms.Button ClearListButton;
        private System.Windows.Forms.GroupBox lineGroupBox;
        private System.Windows.Forms.RadioButton findCrossRadioButton;
        private System.Windows.Forms.RadioButton rotateLineRadioButton;
    }
}

