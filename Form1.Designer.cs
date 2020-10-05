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
            this.rotateLineRadioButton = new System.Windows.Forms.RadioButton();
            this.findCrossRadioButton = new System.Windows.Forms.RadioButton();
            this.pointsPoligonsGroupBox = new System.Windows.Forms.GroupBox();
            this.pointInPolytopeRadioButton = new System.Windows.Forms.RadioButton();
            this.pointInNotPolytopeRadioButton = new System.Windows.Forms.RadioButton();
            this.pointAndEdgeRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageToDrawBox)).BeginInit();
            this.drawingGroupBox.SuspendLayout();
            this.polygonGroupBox.SuspendLayout();
            this.lineGroupBox.SuspendLayout();
            this.pointsPoligonsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageToDrawBox
            // 
            this.imageToDrawBox.Location = new System.Drawing.Point(330, 0);
            this.imageToDrawBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageToDrawBox.Name = "imageToDrawBox";
            this.imageToDrawBox.Size = new System.Drawing.Size(882, 582);
            this.imageToDrawBox.TabIndex = 7;
            this.imageToDrawBox.TabStop = false;
            this.imageToDrawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageToDrawBox_MouseDown_1);
            this.imageToDrawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageToDrawBox_MouseUp);
            // 
            // ClearListButton
            // 
            this.ClearListButton.Location = new System.Drawing.Point(7, 598);
            this.ClearListButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ClearListButton.Name = "ClearListButton";
            this.ClearListButton.Size = new System.Drawing.Size(125, 29);
            this.ClearListButton.TabIndex = 8;
            this.ClearListButton.Text = "Очистить";
            this.ClearListButton.UseVisualStyleBackColor = true;
            this.ClearListButton.Click += new System.EventHandler(this.ClearListButton_Click_1);
            // 
            // LineRadioButton
            // 
            this.LineRadioButton.AutoSize = true;
            this.LineRadioButton.Checked = true;
            this.LineRadioButton.Location = new System.Drawing.Point(24, 35);
            this.LineRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LineRadioButton.Name = "LineRadioButton";
            this.LineRadioButton.Size = new System.Drawing.Size(82, 24);
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
            this.drawingGroupBox.Location = new System.Drawing.Point(7, 5);
            this.drawingGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawingGroupBox.Name = "drawingGroupBox";
            this.drawingGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawingGroupBox.Size = new System.Drawing.Size(316, 145);
            this.drawingGroupBox.TabIndex = 6;
            this.drawingGroupBox.TabStop = false;
            this.drawingGroupBox.Text = "Рисование";
            // 
            // DotRadioButton
            // 
            this.DotRadioButton.AutoSize = true;
            this.DotRadioButton.Location = new System.Drawing.Point(24, 102);
            this.DotRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DotRadioButton.Name = "DotRadioButton";
            this.DotRadioButton.Size = new System.Drawing.Size(78, 24);
            this.DotRadioButton.TabIndex = 4;
            this.DotRadioButton.TabStop = true;
            this.DotRadioButton.Text = "Точка";
            this.DotRadioButton.UseVisualStyleBackColor = true;
            this.DotRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // PolygonRadioButton
            // 
            this.PolygonRadioButton.AutoSize = true;
            this.PolygonRadioButton.Location = new System.Drawing.Point(24, 69);
            this.PolygonRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PolygonRadioButton.Name = "PolygonRadioButton";
            this.PolygonRadioButton.Size = new System.Drawing.Size(149, 24);
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
            this.polygonGroupBox.Location = new System.Drawing.Point(7, 155);
            this.polygonGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.polygonGroupBox.Name = "polygonGroupBox";
            this.polygonGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.polygonGroupBox.Size = new System.Drawing.Size(316, 206);
            this.polygonGroupBox.TabIndex = 9;
            this.polygonGroupBox.TabStop = false;
            this.polygonGroupBox.Text = "Полигоны";
            // 
            // scalePolygonAroundPointRadioButton
            // 
            this.scalePolygonAroundPointRadioButton.AutoSize = true;
            this.scalePolygonAroundPointRadioButton.Location = new System.Drawing.Point(24, 169);
            this.scalePolygonAroundPointRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scalePolygonAroundPointRadioButton.Name = "scalePolygonAroundPointRadioButton";
            this.scalePolygonAroundPointRadioButton.Size = new System.Drawing.Size(277, 24);
            this.scalePolygonAroundPointRadioButton.TabIndex = 6;
            this.scalePolygonAroundPointRadioButton.Text = "Масштабирование вокруг точки";
            this.scalePolygonAroundPointRadioButton.UseVisualStyleBackColor = true;
            this.scalePolygonAroundPointRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // scalePolygonAroundCenterRadioButton
            // 
            this.scalePolygonAroundCenterRadioButton.AutoSize = true;
            this.scalePolygonAroundCenterRadioButton.Location = new System.Drawing.Point(24, 135);
            this.scalePolygonAroundCenterRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scalePolygonAroundCenterRadioButton.Name = "scalePolygonAroundCenterRadioButton";
            this.scalePolygonAroundCenterRadioButton.Size = new System.Drawing.Size(287, 24);
            this.scalePolygonAroundCenterRadioButton.TabIndex = 5;
            this.scalePolygonAroundCenterRadioButton.Text = "Масштабирование вокруг центра";
            this.scalePolygonAroundCenterRadioButton.UseVisualStyleBackColor = true;
            this.scalePolygonAroundCenterRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rotatePolygonAroundPointRadioButton
            // 
            this.rotatePolygonAroundPointRadioButton.AutoSize = true;
            this.rotatePolygonAroundPointRadioButton.Location = new System.Drawing.Point(24, 102);
            this.rotatePolygonAroundPointRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotatePolygonAroundPointRadioButton.Name = "rotatePolygonAroundPointRadioButton";
            this.rotatePolygonAroundPointRadioButton.Size = new System.Drawing.Size(201, 24);
            this.rotatePolygonAroundPointRadioButton.TabIndex = 4;
            this.rotatePolygonAroundPointRadioButton.Text = "Поворот вокруг точки";
            this.rotatePolygonAroundPointRadioButton.UseVisualStyleBackColor = true;
            this.rotatePolygonAroundPointRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rotatePolygonAroundCenterRadioButton
            // 
            this.rotatePolygonAroundCenterRadioButton.AutoSize = true;
            this.rotatePolygonAroundCenterRadioButton.Location = new System.Drawing.Point(24, 69);
            this.rotatePolygonAroundCenterRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotatePolygonAroundCenterRadioButton.Name = "rotatePolygonAroundCenterRadioButton";
            this.rotatePolygonAroundCenterRadioButton.Size = new System.Drawing.Size(211, 24);
            this.rotatePolygonAroundCenterRadioButton.TabIndex = 3;
            this.rotatePolygonAroundCenterRadioButton.Text = "Поворот вокруг центра";
            this.rotatePolygonAroundCenterRadioButton.UseVisualStyleBackColor = true;
            this.rotatePolygonAroundCenterRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // movePolygonRadioButton
            // 
            this.movePolygonRadioButton.AutoSize = true;
            this.movePolygonRadioButton.Location = new System.Drawing.Point(24, 35);
            this.movePolygonRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.movePolygonRadioButton.Name = "movePolygonRadioButton";
            this.movePolygonRadioButton.Size = new System.Drawing.Size(114, 24);
            this.movePolygonRadioButton.TabIndex = 2;
            this.movePolygonRadioButton.Text = "Смещение";
            this.movePolygonRadioButton.UseVisualStyleBackColor = true;
            this.movePolygonRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lineGroupBox
            // 
            this.lineGroupBox.Controls.Add(this.findCrossRadioButton);
            this.lineGroupBox.Controls.Add(this.rotateLineRadioButton);
            this.lineGroupBox.Location = new System.Drawing.Point(7, 366);
            this.lineGroupBox.Name = "lineGroupBox";
            this.lineGroupBox.Size = new System.Drawing.Size(316, 100);
            this.lineGroupBox.TabIndex = 10;
            this.lineGroupBox.TabStop = false;
            this.lineGroupBox.Text = "Отрезки";
            // 
            // rotateLineRadioButton
            // 
            this.rotateLineRadioButton.AutoSize = true;
            this.rotateLineRadioButton.Location = new System.Drawing.Point(24, 25);
            this.rotateLineRadioButton.Name = "rotateLineRadioButton";
            this.rotateLineRadioButton.Size = new System.Drawing.Size(297, 24);
            this.rotateLineRadioButton.TabIndex = 11;
            this.rotateLineRadioButton.TabStop = true;
            this.rotateLineRadioButton.Text = "Поворот на 90 градусов от центра";
            this.rotateLineRadioButton.UseVisualStyleBackColor = true;
            this.rotateLineRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // findCrossRadioButton
            // 
            this.findCrossRadioButton.AutoSize = true;
            this.findCrossRadioButton.Location = new System.Drawing.Point(24, 55);
            this.findCrossRadioButton.Name = "findCrossRadioButton";
            this.findCrossRadioButton.Size = new System.Drawing.Size(230, 24);
            this.findCrossRadioButton.TabIndex = 12;
            this.findCrossRadioButton.TabStop = true;
            this.findCrossRadioButton.Text = "Поиск точки пересечения";
            this.findCrossRadioButton.UseVisualStyleBackColor = true;
            this.findCrossRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // pointsPoligonsGroupBox
            // 
            this.pointsPoligonsGroupBox.Controls.Add(this.pointAndEdgeRadioButton);
            this.pointsPoligonsGroupBox.Controls.Add(this.pointInNotPolytopeRadioButton);
            this.pointsPoligonsGroupBox.Controls.Add(this.pointInPolytopeRadioButton);
            this.pointsPoligonsGroupBox.Location = new System.Drawing.Point(7, 472);
            this.pointsPoligonsGroupBox.Name = "pointsPoligonsGroupBox";
            this.pointsPoligonsGroupBox.Size = new System.Drawing.Size(321, 119);
            this.pointsPoligonsGroupBox.TabIndex = 11;
            this.pointsPoligonsGroupBox.TabStop = false;
            this.pointsPoligonsGroupBox.Text = "Точки и многоугольники";
            // 
            // pointInPolytopeRadioButton
            // 
            this.pointInPolytopeRadioButton.AutoSize = true;
            this.pointInPolytopeRadioButton.Location = new System.Drawing.Point(24, 25);
            this.pointInPolytopeRadioButton.Name = "pointInPolytopeRadioButton";
            this.pointInPolytopeRadioButton.Size = new System.Drawing.Size(286, 24);
            this.pointInPolytopeRadioButton.TabIndex = 0;
            this.pointInPolytopeRadioButton.TabStop = true;
            this.pointInPolytopeRadioButton.Text = "Точка и выпуклый многоугольник";
            this.pointInPolytopeRadioButton.UseVisualStyleBackColor = true;
            this.pointInPolytopeRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // pointInNotPolytopeRadioButton
            // 
            this.pointInNotPolytopeRadioButton.AutoSize = true;
            this.pointInNotPolytopeRadioButton.Location = new System.Drawing.Point(24, 55);
            this.pointInNotPolytopeRadioButton.Name = "pointInNotPolytopeRadioButton";
            this.pointInNotPolytopeRadioButton.Size = new System.Drawing.Size(304, 24);
            this.pointInNotPolytopeRadioButton.TabIndex = 1;
            this.pointInNotPolytopeRadioButton.TabStop = true;
            this.pointInNotPolytopeRadioButton.Text = "Точка и невыпуклый многоугольник";
            this.pointInNotPolytopeRadioButton.UseVisualStyleBackColor = true;
            this.pointInNotPolytopeRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // pointAndEdgeRadioButton
            // 
            this.pointAndEdgeRadioButton.AutoSize = true;
            this.pointAndEdgeRadioButton.Location = new System.Drawing.Point(24, 85);
            this.pointAndEdgeRadioButton.Name = "pointAndEdgeRadioButton";
            this.pointAndEdgeRadioButton.Size = new System.Drawing.Size(266, 24);
            this.pointAndEdgeRadioButton.TabIndex = 2;
            this.pointAndEdgeRadioButton.TabStop = true;
            this.pointAndEdgeRadioButton.Text = "Точка и ребро многоугольника";
            this.pointAndEdgeRadioButton.UseVisualStyleBackColor = true;
            this.pointAndEdgeRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 626);
            this.Controls.Add(this.pointsPoligonsGroupBox);
            this.Controls.Add(this.lineGroupBox);
            this.Controls.Add(this.polygonGroupBox);
            this.Controls.Add(this.ClearListButton);
            this.Controls.Add(this.imageToDrawBox);
            this.Controls.Add(this.drawingGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pointsPoligonsGroupBox.ResumeLayout(false);
            this.pointsPoligonsGroupBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox pointsPoligonsGroupBox;
        private System.Windows.Forms.RadioButton pointAndEdgeRadioButton;
        private System.Windows.Forms.RadioButton pointInNotPolytopeRadioButton;
        private System.Windows.Forms.RadioButton pointInPolytopeRadioButton;
    }
}

