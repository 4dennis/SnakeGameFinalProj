namespace SnakeGameFinalProj
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pbPlane = new System.Windows.Forms.PictureBox();
            this.SnakeTimer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.rbTwoPlayer = new System.Windows.Forms.RadioButton();
            this.rbOnePlayer = new System.Windows.Forms.RadioButton();
            this.cdS1 = new System.Windows.Forms.ColorDialog();
            this.cdS2 = new System.Windows.Forms.ColorDialog();
            this.btnColS2 = new System.Windows.Forms.Button();
            this.btnColS1 = new System.Windows.Forms.Button();
            this.btnColorFood = new System.Windows.Forms.Button();
            this.cdFood = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAdaptable = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlane)).BeginInit();
            this.gbMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPlane
            // 
            this.pbPlane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pbPlane.Location = new System.Drawing.Point(5, 5);
            this.pbPlane.Name = "pbPlane";
            this.pbPlane.Size = new System.Drawing.Size(600, 600);
            this.pbPlane.TabIndex = 0;
            this.pbPlane.TabStop = false;
            this.pbPlane.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPlane_Paint);
            // 
            // SnakeTimer
            // 
            this.SnakeTimer.Tick += new System.EventHandler(this.SnakeTimer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(666, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 49);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(666, 174);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(104, 49);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(666, 99);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(104, 49);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // gbMode
            // 
            this.gbMode.Controls.Add(this.rbTwoPlayer);
            this.gbMode.Controls.Add(this.rbOnePlayer);
            this.gbMode.Location = new System.Drawing.Point(641, 245);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(159, 103);
            this.gbMode.TabIndex = 6;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Player Mode";
            // 
            // rbTwoPlayer
            // 
            this.rbTwoPlayer.AutoSize = true;
            this.rbTwoPlayer.Checked = true;
            this.rbTwoPlayer.Location = new System.Drawing.Point(32, 72);
            this.rbTwoPlayer.Name = "rbTwoPlayer";
            this.rbTwoPlayer.Size = new System.Drawing.Size(96, 20);
            this.rbTwoPlayer.TabIndex = 1;
            this.rbTwoPlayer.TabStop = true;
            this.rbTwoPlayer.Text = "Two Player";
            this.rbTwoPlayer.UseVisualStyleBackColor = true;
            // 
            // rbOnePlayer
            // 
            this.rbOnePlayer.AutoSize = true;
            this.rbOnePlayer.Location = new System.Drawing.Point(32, 36);
            this.rbOnePlayer.Name = "rbOnePlayer";
            this.rbOnePlayer.Size = new System.Drawing.Size(95, 20);
            this.rbOnePlayer.TabIndex = 0;
            this.rbOnePlayer.Text = "One Player";
            this.rbOnePlayer.UseVisualStyleBackColor = true;
            this.rbOnePlayer.CheckedChanged += new System.EventHandler(this.rbOnePlayer_CheckedChanged);
            // 
            // btnColS2
            // 
            this.btnColS2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnColS2.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColS2.Location = new System.Drawing.Point(653, 436);
            this.btnColS2.Name = "btnColS2";
            this.btnColS2.Size = new System.Drawing.Size(117, 64);
            this.btnColS2.TabIndex = 22;
            this.btnColS2.Text = "Change GreenTheSecond Colour";
            this.btnColS2.UseVisualStyleBackColor = false;
            this.btnColS2.Click += new System.EventHandler(this.btnColS2_Click);
            // 
            // btnColS1
            // 
            this.btnColS1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnColS1.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColS1.Location = new System.Drawing.Point(613, 366);
            this.btnColS1.Name = "btnColS1";
            this.btnColS1.Size = new System.Drawing.Size(96, 64);
            this.btnColS1.TabIndex = 21;
            this.btnColS1.Text = "Change BigGreen Colour";
            this.btnColS1.UseVisualStyleBackColor = false;
            this.btnColS1.Click += new System.EventHandler(this.btnColS1_Click);
            // 
            // btnColorFood
            // 
            this.btnColorFood.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnColorFood.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorFood.Location = new System.Drawing.Point(715, 366);
            this.btnColorFood.Name = "btnColorFood";
            this.btnColorFood.Size = new System.Drawing.Size(96, 64);
            this.btnColorFood.TabIndex = 23;
            this.btnColorFood.Text = "Change Food Colour";
            this.btnColorFood.UseVisualStyleBackColor = false;
            this.btnColorFood.Click += new System.EventHandler(this.btnColorFood_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAdaptable);
            this.groupBox1.Controls.Add(this.rbHard);
            this.groupBox1.Controls.Add(this.rbNormal);
            this.groupBox1.Controls.Add(this.rbEasy);
            this.groupBox1.Location = new System.Drawing.Point(632, 506);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 111);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speed Mode";
            // 
            // rbAdaptable
            // 
            this.rbAdaptable.AutoSize = true;
            this.rbAdaptable.Location = new System.Drawing.Point(121, 72);
            this.rbAdaptable.Name = "rbAdaptable";
            this.rbAdaptable.Size = new System.Drawing.Size(91, 20);
            this.rbAdaptable.TabIndex = 3;
            this.rbAdaptable.Text = "Adaptable";
            this.rbAdaptable.UseVisualStyleBackColor = true;
            this.rbAdaptable.CheckedChanged += new System.EventHandler(this.rbAdaptable_CheckedChanged);
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(121, 36);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(58, 20);
            this.rbHard.TabIndex = 2;
            this.rbHard.Text = "Hard";
            this.rbHard.UseVisualStyleBackColor = true;
            this.rbHard.CheckedChanged += new System.EventHandler(this.rbHard_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(32, 72);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(72, 20);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Location = new System.Drawing.Point(32, 38);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(59, 20);
            this.rbEasy.TabIndex = 0;
            this.rbEasy.Text = "Easy";
            this.rbEasy.UseVisualStyleBackColor = true;
            this.rbEasy.CheckedChanged += new System.EventHandler(this.rbEasy_CheckedChanged);
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(811, 478);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.ReadOnly = true;
            this.txtSpeed.Size = new System.Drawing.Size(33, 22);
            this.txtSpeed.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(862, 646);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnColorFood);
            this.Controls.Add(this.btnColS2);
            this.Controls.Add(this.btnColS1);
            this.Controls.Add(this.gbMode);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbPlane);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlane)).EndInit();
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlane;
        private System.Windows.Forms.Timer SnakeTimer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.RadioButton rbTwoPlayer;
        private System.Windows.Forms.RadioButton rbOnePlayer;
        private System.Windows.Forms.ColorDialog cdS1;
        private System.Windows.Forms.ColorDialog cdS2;
        private System.Windows.Forms.Button btnColS2;
        private System.Windows.Forms.Button btnColS1;
        private System.Windows.Forms.Button btnColorFood;
        private System.Windows.Forms.ColorDialog cdFood;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAdaptable;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.TextBox txtSpeed;
    }
}

