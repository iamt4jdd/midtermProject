﻿namespace midtermProject_Paint
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
            this.toolPanel = new System.Windows.Forms.Panel();
            this.currentColorBtn = new System.Windows.Forms.Button();
            this.btnWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dashBtn = new System.Windows.Forms.Button();
            this.brushBtn = new System.Windows.Forms.Button();
            this.penBtn = new System.Windows.Forms.Button();
            this.colordiaBtn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.circleBtn = new System.Windows.Forms.Button();
            this.polygonBtn = new System.Windows.Forms.Button();
            this.rectangleBtn = new System.Windows.Forms.Button();
            this.ellipseBtn = new System.Windows.Forms.Button();
            this.arcBtn = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectBtn = new System.Windows.Forms.Button();
            this.eraseBtn = new System.Windows.Forms.Button();
            this.unGroupBtn = new System.Windows.Forms.Button();
            this.groupBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWidth)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colordiaBtn)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolPanel
            // 
            this.toolPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.toolPanel.Controls.Add(this.currentColorBtn);
            this.toolPanel.Controls.Add(this.btnWidth);
            this.toolPanel.Controls.Add(this.label2);
            this.toolPanel.Controls.Add(this.panel6);
            this.toolPanel.Controls.Add(this.colordiaBtn);
            this.toolPanel.Controls.Add(this.label1);
            this.toolPanel.Controls.Add(this.panel4);
            this.toolPanel.Controls.Add(this.panel3);
            this.toolPanel.Location = new System.Drawing.Point(1, -4);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(1319, 171);
            this.toolPanel.TabIndex = 0;
            // 
            // currentColorBtn
            // 
            this.currentColorBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.currentColorBtn.Location = new System.Drawing.Point(860, 42);
            this.currentColorBtn.Name = "currentColorBtn";
            this.currentColorBtn.Size = new System.Drawing.Size(69, 62);
            this.currentColorBtn.TabIndex = 0;
            this.currentColorBtn.UseVisualStyleBackColor = false;
            // 
            // btnWidth
            // 
            this.btnWidth.Location = new System.Drawing.Point(1130, 42);
            this.btnWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.btnWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.btnWidth.Name = "btnWidth";
            this.btnWidth.Size = new System.Drawing.Size(150, 27);
            this.btnWidth.TabIndex = 12;
            this.btnWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.btnWidth.ValueChanged += new System.EventHandler(this.btnWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1149, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Change width";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dashBtn);
            this.panel6.Controls.Add(this.brushBtn);
            this.panel6.Controls.Add(this.penBtn);
            this.panel6.Location = new System.Drawing.Point(625, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(187, 135);
            this.panel6.TabIndex = 9;
            // 
            // dashBtn
            // 
            this.dashBtn.BackColor = System.Drawing.Color.White;
            this.dashBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.dash;
            this.dashBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashBtn.Location = new System.Drawing.Point(14, 71);
            this.dashBtn.Name = "dashBtn";
            this.dashBtn.Size = new System.Drawing.Size(62, 52);
            this.dashBtn.TabIndex = 2;
            this.dashBtn.UseVisualStyleBackColor = false;
            this.dashBtn.Click += new System.EventHandler(this.dashBtn_Click);
            // 
            // brushBtn
            // 
            this.brushBtn.BackColor = System.Drawing.Color.White;
            this.brushBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.brush;
            this.brushBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.brushBtn.Location = new System.Drawing.Point(108, 7);
            this.brushBtn.Name = "brushBtn";
            this.brushBtn.Size = new System.Drawing.Size(62, 52);
            this.brushBtn.TabIndex = 1;
            this.brushBtn.UseVisualStyleBackColor = false;
            this.brushBtn.Click += new System.EventHandler(this.brushBtn_Click);
            // 
            // penBtn
            // 
            this.penBtn.BackColor = System.Drawing.Color.White;
            this.penBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.pen;
            this.penBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.penBtn.Location = new System.Drawing.Point(14, 7);
            this.penBtn.Name = "penBtn";
            this.penBtn.Size = new System.Drawing.Size(62, 52);
            this.penBtn.TabIndex = 0;
            this.penBtn.UseVisualStyleBackColor = false;
            this.penBtn.Click += new System.EventHandler(this.penBtn_Click);
            // 
            // colordiaBtn
            // 
            this.colordiaBtn.BackColor = System.Drawing.Color.Transparent;
            this.colordiaBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.pallet;
            this.colordiaBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.colordiaBtn.Location = new System.Drawing.Point(990, 17);
            this.colordiaBtn.Name = "colordiaBtn";
            this.colordiaBtn.Size = new System.Drawing.Size(68, 62);
            this.colordiaBtn.TabIndex = 8;
            this.colordiaBtn.TabStop = false;
            this.colordiaBtn.Click += new System.EventHandler(this.colordiaBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(956, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Customise Colors";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.circleBtn);
            this.panel4.Controls.Add(this.polygonBtn);
            this.panel4.Controls.Add(this.rectangleBtn);
            this.panel4.Controls.Add(this.ellipseBtn);
            this.panel4.Controls.Add(this.arcBtn);
            this.panel4.Controls.Add(this.lineBtn);
            this.panel4.Location = new System.Drawing.Point(245, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(346, 135);
            this.panel4.TabIndex = 4;
            // 
            // circleBtn
            // 
            this.circleBtn.BackColor = System.Drawing.Color.White;
            this.circleBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.circle;
            this.circleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.circleBtn.Location = new System.Drawing.Point(15, 71);
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.Size = new System.Drawing.Size(62, 52);
            this.circleBtn.TabIndex = 6;
            this.circleBtn.UseVisualStyleBackColor = false;
            this.circleBtn.Click += new System.EventHandler(this.circleBtn_Click);
            // 
            // polygonBtn
            // 
            this.polygonBtn.BackColor = System.Drawing.Color.White;
            this.polygonBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.polygon;
            this.polygonBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.polygonBtn.Location = new System.Drawing.Point(94, 71);
            this.polygonBtn.Name = "polygonBtn";
            this.polygonBtn.Size = new System.Drawing.Size(62, 52);
            this.polygonBtn.TabIndex = 5;
            this.polygonBtn.UseVisualStyleBackColor = false;
            this.polygonBtn.Click += new System.EventHandler(this.polygonBtn_Click);
            // 
            // rectangleBtn
            // 
            this.rectangleBtn.BackColor = System.Drawing.Color.White;
            this.rectangleBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.rectangle;
            this.rectangleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rectangleBtn.Location = new System.Drawing.Point(264, 7);
            this.rectangleBtn.Name = "rectangleBtn";
            this.rectangleBtn.Size = new System.Drawing.Size(62, 52);
            this.rectangleBtn.TabIndex = 3;
            this.rectangleBtn.UseVisualStyleBackColor = false;
            this.rectangleBtn.Click += new System.EventHandler(this.rectangleBtn_Click);
            // 
            // ellipseBtn
            // 
            this.ellipseBtn.BackColor = System.Drawing.Color.White;
            this.ellipseBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.ellipse;
            this.ellipseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ellipseBtn.Location = new System.Drawing.Point(179, 7);
            this.ellipseBtn.Name = "ellipseBtn";
            this.ellipseBtn.Size = new System.Drawing.Size(62, 52);
            this.ellipseBtn.TabIndex = 2;
            this.ellipseBtn.UseVisualStyleBackColor = false;
            this.ellipseBtn.Click += new System.EventHandler(this.ellipseBtn_Click);
            // 
            // arcBtn
            // 
            this.arcBtn.BackColor = System.Drawing.Color.White;
            this.arcBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.curve;
            this.arcBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.arcBtn.Location = new System.Drawing.Point(94, 7);
            this.arcBtn.Name = "arcBtn";
            this.arcBtn.Size = new System.Drawing.Size(62, 52);
            this.arcBtn.TabIndex = 1;
            this.arcBtn.UseVisualStyleBackColor = false;
            this.arcBtn.Click += new System.EventHandler(this.arcBtn_Click);
            // 
            // lineBtn
            // 
            this.lineBtn.BackColor = System.Drawing.Color.White;
            this.lineBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.line;
            this.lineBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lineBtn.Location = new System.Drawing.Point(15, 7);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(62, 52);
            this.lineBtn.TabIndex = 0;
            this.lineBtn.UseVisualStyleBackColor = false;
            this.lineBtn.Click += new System.EventHandler(this.lineBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.selectBtn);
            this.panel3.Controls.Add(this.eraseBtn);
            this.panel3.Controls.Add(this.unGroupBtn);
            this.panel3.Controls.Add(this.groupBtn);
            this.panel3.Location = new System.Drawing.Point(15, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 135);
            this.panel3.TabIndex = 1;
            // 
            // selectBtn
            // 
            this.selectBtn.BackColor = System.Drawing.Color.White;
            this.selectBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.select;
            this.selectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectBtn.Location = new System.Drawing.Point(117, 71);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(62, 52);
            this.selectBtn.TabIndex = 3;
            this.selectBtn.UseVisualStyleBackColor = false;
            // 
            // eraseBtn
            // 
            this.eraseBtn.BackColor = System.Drawing.Color.White;
            this.eraseBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.eraser;
            this.eraseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eraseBtn.Location = new System.Drawing.Point(20, 71);
            this.eraseBtn.Name = "eraseBtn";
            this.eraseBtn.Size = new System.Drawing.Size(62, 52);
            this.eraseBtn.TabIndex = 2;
            this.eraseBtn.UseVisualStyleBackColor = false;
            // 
            // unGroupBtn
            // 
            this.unGroupBtn.BackColor = System.Drawing.Color.White;
            this.unGroupBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.ungroup;
            this.unGroupBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.unGroupBtn.Location = new System.Drawing.Point(117, 7);
            this.unGroupBtn.Name = "unGroupBtn";
            this.unGroupBtn.Size = new System.Drawing.Size(62, 52);
            this.unGroupBtn.TabIndex = 1;
            this.unGroupBtn.UseVisualStyleBackColor = false;
            // 
            // groupBtn
            // 
            this.groupBtn.BackColor = System.Drawing.Color.White;
            this.groupBtn.BackgroundImage = global::midtermProject_Paint.Properties.Resources.group;
            this.groupBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBtn.Location = new System.Drawing.Point(20, 7);
            this.groupBtn.Name = "groupBtn";
            this.groupBtn.Size = new System.Drawing.Size(62, 52);
            this.groupBtn.TabIndex = 0;
            this.groupBtn.UseVisualStyleBackColor = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(12, 173);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1308, 785);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            this.mainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 955);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWidth)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colordiaBtn)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel toolPanel;
        private Panel mainPanel;
        private Panel panel3;
        private Button selectBtn;
        private Button eraseBtn;
        private Button unGroupBtn;
        private Button groupBtn;
        private Panel panel4;
        private Button polygonBtn;
        private Button rectangleBtn;
        private Button ellipseBtn;
        private Button arcBtn;
        private Button lineBtn;
        private Label label1;
        private PictureBox colordiaBtn;
        private ColorDialog colorDialog1;
        private Panel panel6;
        private Button brushBtn;
        private Button penBtn;
        private Button dashBtn;
        private Label label2;
        private NumericUpDown btnWidth;
        private Button circleBtn;
        private Button currentColorBtn;
    }
}