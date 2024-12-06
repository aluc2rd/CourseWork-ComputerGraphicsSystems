namespace Std
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
            this.tmoBox = new System.Windows.Forms.GroupBox();
            this.IntersectionButton = new System.Windows.Forms.Button();
            this.DiffButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SelectFigure = new System.Windows.Forms.Button();
            this.transformationBox = new System.Windows.Forms.GroupBox();
            this.numericUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.CenterButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RcButton = new System.Windows.Forms.Button();
            this.MHButton = new System.Windows.Forms.Button();
            this.move = new System.Windows.Forms.Button();
            this.MFButton = new System.Windows.Forms.Button();
            this.figureBox = new System.Windows.Forms.GroupBox();
            this.buttonColor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownSizeFlag = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNHeight = new System.Windows.Forms.NumericUpDown();
            this.labelA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FlagButton = new System.Windows.Forms.Button();
            this.PrlgButton = new System.Windows.Forms.Button();
            this.labelN = new System.Windows.Forms.Label();
            this.LineButton = new System.Windows.Forms.Button();
            this.SplainButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.DelFigureButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tmoBox.SuspendLayout();
            this.transformationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).BeginInit();
            this.figureBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tmoBox
            // 
            this.tmoBox.Controls.Add(this.IntersectionButton);
            this.tmoBox.Controls.Add(this.DiffButton);
            this.tmoBox.Location = new System.Drawing.Point(13, 749);
            this.tmoBox.Margin = new System.Windows.Forms.Padding(4);
            this.tmoBox.Name = "tmoBox";
            this.tmoBox.Padding = new System.Windows.Forms.Padding(4);
            this.tmoBox.Size = new System.Drawing.Size(372, 92);
            this.tmoBox.TabIndex = 23;
            this.tmoBox.TabStop = false;
            this.tmoBox.Text = "ТМО";
            // 
            // IntersectionButton
            // 
            this.IntersectionButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.IntersectionButton.Location = new System.Drawing.Point(190, 23);
            this.IntersectionButton.Margin = new System.Windows.Forms.Padding(4);
            this.IntersectionButton.Name = "IntersectionButton";
            this.IntersectionButton.Size = new System.Drawing.Size(174, 49);
            this.IntersectionButton.TabIndex = 6;
            this.IntersectionButton.Text = "Симметрическая разность";
            this.IntersectionButton.UseVisualStyleBackColor = false;
            this.IntersectionButton.Click += new System.EventHandler(this.Intersection_Click);
            // 
            // DiffButton
            // 
            this.DiffButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DiffButton.Location = new System.Drawing.Point(10, 23);
            this.DiffButton.Margin = new System.Windows.Forms.Padding(4);
            this.DiffButton.Name = "DiffButton";
            this.DiffButton.Size = new System.Drawing.Size(174, 49);
            this.DiffButton.TabIndex = 9;
            this.DiffButton.Text = "Пересечение";
            this.DiffButton.UseVisualStyleBackColor = false;
            this.DiffButton.Click += new System.EventHandler(this.Diff_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClearButton.Location = new System.Drawing.Point(23, 851);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(171, 49);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Очистка";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearBox_Click);
            // 
            // SelectFigure
            // 
            this.SelectFigure.BackColor = System.Drawing.SystemColors.HighlightText;
            this.SelectFigure.Location = new System.Drawing.Point(79, 292);
            this.SelectFigure.Margin = new System.Windows.Forms.Padding(4);
            this.SelectFigure.Name = "SelectFigure";
            this.SelectFigure.Size = new System.Drawing.Size(190, 40);
            this.SelectFigure.TabIndex = 3;
            this.SelectFigure.Text = "Выделить фигуру";
            this.SelectFigure.UseVisualStyleBackColor = false;
            this.SelectFigure.Click += new System.EventHandler(this.SelectFigure_Click);
            // 
            // transformationBox
            // 
            this.transformationBox.Controls.Add(this.numericUpDownAngle);
            this.transformationBox.Controls.Add(this.SelectFigure);
            this.transformationBox.Controls.Add(this.CenterButton);
            this.transformationBox.Controls.Add(this.label3);
            this.transformationBox.Controls.Add(this.RcButton);
            this.transformationBox.Controls.Add(this.MHButton);
            this.transformationBox.Controls.Add(this.move);
            this.transformationBox.Controls.Add(this.MFButton);
            this.transformationBox.Location = new System.Drawing.Point(13, 377);
            this.transformationBox.Margin = new System.Windows.Forms.Padding(4);
            this.transformationBox.Name = "transformationBox";
            this.transformationBox.Padding = new System.Windows.Forms.Padding(4);
            this.transformationBox.Size = new System.Drawing.Size(372, 352);
            this.transformationBox.TabIndex = 17;
            this.transformationBox.TabStop = false;
            this.transformationBox.Text = "Преобразования";
            // 
            // numericUpDownAngle
            // 
            this.numericUpDownAngle.Location = new System.Drawing.Point(210, 75);
            this.numericUpDownAngle.Name = "numericUpDownAngle";
            this.numericUpDownAngle.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownAngle.TabIndex = 31;
            this.numericUpDownAngle.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // CenterButton
            // 
            this.CenterButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CenterButton.Location = new System.Drawing.Point(182, 23);
            this.CenterButton.Margin = new System.Windows.Forms.Padding(4);
            this.CenterButton.Name = "CenterButton";
            this.CenterButton.Size = new System.Drawing.Size(159, 40);
            this.CenterButton.TabIndex = 17;
            this.CenterButton.Text = "Задать центр";
            this.CenterButton.UseVisualStyleBackColor = false;
            this.CenterButton.Click += new System.EventHandler(this.SetCenterButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "угол поворота";
            // 
            // RcButton
            // 
            this.RcButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.RcButton.Location = new System.Drawing.Point(18, 23);
            this.RcButton.Margin = new System.Windows.Forms.Padding(4);
            this.RcButton.Name = "RcButton";
            this.RcButton.Size = new System.Drawing.Size(159, 40);
            this.RcButton.TabIndex = 9;
            this.RcButton.Text = "Rc (поворот)";
            this.RcButton.UseVisualStyleBackColor = false;
            this.RcButton.Click += new System.EventHandler(this.RcButton_Click);
            // 
            // MHButton
            // 
            this.MHButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MHButton.Location = new System.Drawing.Point(18, 104);
            this.MHButton.Margin = new System.Windows.Forms.Padding(4);
            this.MHButton.Name = "MHButton";
            this.MHButton.Size = new System.Drawing.Size(323, 40);
            this.MHButton.TabIndex = 8;
            this.MHButton.Text = "MH (отражение по горизонтали)";
            this.MHButton.UseVisualStyleBackColor = false;
            this.MHButton.Click += new System.EventHandler(this.MHButton_Click);
            // 
            // move
            // 
            this.move.BackColor = System.Drawing.SystemColors.HighlightText;
            this.move.Location = new System.Drawing.Point(105, 233);
            this.move.Margin = new System.Windows.Forms.Padding(4);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(133, 40);
            this.move.TabIndex = 1;
            this.move.Text = "Перемещение";
            this.move.UseVisualStyleBackColor = false;
            this.move.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // MFButton
            // 
            this.MFButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MFButton.Location = new System.Drawing.Point(18, 152);
            this.MFButton.Margin = new System.Windows.Forms.Padding(4);
            this.MFButton.Name = "MFButton";
            this.MFButton.Size = new System.Drawing.Size(323, 63);
            this.MFButton.TabIndex = 2;
            this.MFButton.Text = "Mf (зеркальное отражение относительно центра фигуры)";
            this.MFButton.UseVisualStyleBackColor = false;
            this.MFButton.Click += new System.EventHandler(this.MfButton_Click);
            // 
            // figureBox
            // 
            this.figureBox.Controls.Add(this.buttonColor);
            this.figureBox.Controls.Add(this.groupBox1);
            this.figureBox.Controls.Add(this.LineButton);
            this.figureBox.Controls.Add(this.SplainButton);
            this.figureBox.Location = new System.Drawing.Point(13, 14);
            this.figureBox.Margin = new System.Windows.Forms.Padding(4);
            this.figureBox.Name = "figureBox";
            this.figureBox.Padding = new System.Windows.Forms.Padding(4);
            this.figureBox.Size = new System.Drawing.Size(372, 355);
            this.figureBox.TabIndex = 18;
            this.figureBox.TabStop = false;
            this.figureBox.Text = "Фигуры";
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.SystemColors.HighlightText;
            this.buttonColor.Location = new System.Drawing.Point(110, 295);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(159, 33);
            this.buttonColor.TabIndex = 25;
            this.buttonColor.Text = "Выбор цвета";
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownSizeFlag);
            this.groupBox1.Controls.Add(this.numericUpDownWidth);
            this.groupBox1.Controls.Add(this.numericUpDownNHeight);
            this.groupBox1.Controls.Add(this.labelA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FlagButton);
            this.groupBox1.Controls.Add(this.PrlgButton);
            this.groupBox1.Controls.Add(this.labelN);
            this.groupBox1.Location = new System.Drawing.Point(9, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(355, 193);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // numericUpDownSizeFlag
            // 
            this.numericUpDownSizeFlag.Location = new System.Drawing.Point(216, 55);
            this.numericUpDownSizeFlag.Name = "numericUpDownSizeFlag";
            this.numericUpDownSizeFlag.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownSizeFlag.TabIndex = 31;
            this.numericUpDownSizeFlag.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(238, 147);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownWidth.TabIndex = 30;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownNHeight
            // 
            this.numericUpDownNHeight.Location = new System.Drawing.Point(103, 145);
            this.numericUpDownNHeight.Name = "numericUpDownNHeight";
            this.numericUpDownNHeight.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownNHeight.TabIndex = 29;
            this.numericUpDownNHeight.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelA.Location = new System.Drawing.Point(109, 55);
            this.labelA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(100, 17);
            this.labelA.TabIndex = 28;
            this.labelA.Text = "размер флага";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(172, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "ширина";
            // 
            // FlagButton
            // 
            this.FlagButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.FlagButton.Location = new System.Drawing.Point(48, 14);
            this.FlagButton.Margin = new System.Windows.Forms.Padding(4);
            this.FlagButton.Name = "FlagButton";
            this.FlagButton.Size = new System.Drawing.Size(249, 37);
            this.FlagButton.TabIndex = 10;
            this.FlagButton.Text = "Flag ";
            this.FlagButton.UseVisualStyleBackColor = false;
            this.FlagButton.Click += new System.EventHandler(this.FlagButton_Click);
            // 
            // PrlgButton
            // 
            this.PrlgButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.PrlgButton.Location = new System.Drawing.Point(48, 99);
            this.PrlgButton.Margin = new System.Windows.Forms.Padding(4);
            this.PrlgButton.Name = "PrlgButton";
            this.PrlgButton.Size = new System.Drawing.Size(249, 39);
            this.PrlgButton.TabIndex = 1;
            this.PrlgButton.Text = "Prlg (параллелограмм)";
            this.PrlgButton.UseVisualStyleBackColor = false;
            this.PrlgButton.Click += new System.EventHandler(this.PrlgButton_Click);
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelN.Location = new System.Drawing.Point(41, 147);
            this.labelN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(55, 17);
            this.labelN.TabIndex = 20;
            this.labelN.Text = "высота";
            // 
            // LineButton
            // 
            this.LineButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LineButton.Location = new System.Drawing.Point(191, 244);
            this.LineButton.Margin = new System.Windows.Forms.Padding(4);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(159, 33);
            this.LineButton.TabIndex = 9;
            this.LineButton.Text = "Линия";
            this.LineButton.UseVisualStyleBackColor = false;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // SplainButton
            // 
            this.SplainButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.SplainButton.Location = new System.Drawing.Point(20, 244);
            this.SplainButton.Margin = new System.Windows.Forms.Padding(4);
            this.SplainButton.Name = "SplainButton";
            this.SplainButton.Size = new System.Drawing.Size(159, 33);
            this.SplainButton.TabIndex = 2;
            this.SplainButton.Text = "Кубический сплайн";
            this.SplainButton.UseVisualStyleBackColor = false;
            this.SplainButton.Click += new System.EventHandler(this.SplineButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(404, 6);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1518, 1045);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // DelFigureButton
            // 
            this.DelFigureButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DelFigureButton.Location = new System.Drawing.Point(203, 851);
            this.DelFigureButton.Margin = new System.Windows.Forms.Padding(4);
            this.DelFigureButton.Name = "DelFigureButton";
            this.DelFigureButton.Size = new System.Drawing.Size(174, 49);
            this.DelFigureButton.TabIndex = 24;
            this.DelFigureButton.Text = "Удалить";
            this.DelFigureButton.UseVisualStyleBackColor = false;
            this.DelFigureButton.Click += new System.EventHandler(this.DelFigureButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.DelFigureButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.tmoBox);
            this.Controls.Add(this.transformationBox);
            this.Controls.Add(this.figureBox);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ГСК Курасовая работа";
            this.tmoBox.ResumeLayout(false);
            this.transformationBox.ResumeLayout(false);
            this.transformationBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).EndInit();
            this.figureBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox tmoBox;
        private System.Windows.Forms.Button IntersectionButton;
        private System.Windows.Forms.Button DiffButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SelectFigure;
        private System.Windows.Forms.GroupBox transformationBox;
        private System.Windows.Forms.Button move;
        private System.Windows.Forms.Button MFButton;
        private System.Windows.Forms.GroupBox figureBox;
        private System.Windows.Forms.Button PrlgButton;
        private System.Windows.Forms.Button SplainButton;
        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button FlagButton;
        private System.Windows.Forms.Button RcButton;
        private System.Windows.Forms.Button DelFigureButton;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Button CenterButton;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeFlag;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownNHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownAngle;
        public System.Windows.Forms.Button MHButton;
    }
}

