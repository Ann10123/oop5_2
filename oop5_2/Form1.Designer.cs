using VoronoiWinForms;

namespace VoronoiWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxVoronoi;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteSmallest;
        private System.Windows.Forms.Button btnDrawVoronoi;
        private System.Windows.Forms.ComboBox comboThreads;
        private System.Windows.Forms.ComboBox comboMetrics;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxVoronoi = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDeleteSmallest = new System.Windows.Forms.Button();
            this.btnDrawVoronoi = new System.Windows.Forms.Button();
            this.comboThreads = new System.Windows.Forms.ComboBox();
            this.comboMetrics = new System.Windows.Forms.ComboBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVoronoi)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Controls.Add(this.btnGenerate);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnDeleteSmallest);
            this.panelTop.Controls.Add(this.btnDrawVoronoi);
            this.panelTop.Controls.Add(this.comboThreads);
            this.panelTop.Controls.Add(this.comboMetrics);
            this.panelTop.BackColor = Color.LightBlue;
            // 
            // pictureBoxVoronoi
            // 
            this.pictureBoxVoronoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxVoronoi.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxVoronoi.Location = new System.Drawing.Point(0, 50);
            this.pictureBoxVoronoi.Name = "pictureBoxVoronoi";
            this.pictureBoxVoronoi.Size = new System.Drawing.Size(800, 400);
            this.pictureBoxVoronoi.TabIndex = 0;
            this.pictureBoxVoronoi.TabStop = false;
            this.pictureBoxVoronoi.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(10, 10);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(220, 30);
            this.btnGenerate.Text = "Згенерувати 100 точок";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.GeneratePoints_Click);
            this.btnGenerate.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(250, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 30);
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.DeletePoints_Click);
            this.btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            // 
            // btnDeleteSmallest
            // 
            this.btnDeleteSmallest.Location = new System.Drawing.Point(380, 10);
            this.btnDeleteSmallest.Name = "btnDeleteSmallest";
            this.btnDeleteSmallest.Size = new System.Drawing.Size(210, 30);
            this.btnDeleteSmallest.Text = "Видалити найменші (5)";
            this.btnDeleteSmallest.UseVisualStyleBackColor = true;
            this.btnDeleteSmallest.Click += new System.EventHandler(this.DeleteSmallestAreas_Click);
            this.btnDeleteSmallest.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            // 
            // btnDrawVoronoi
            // 
            this.btnDrawVoronoi.Location = new System.Drawing.Point(610, 10);
            this.btnDrawVoronoi.Name = "btnDrawVoronoi";
            this.btnDrawVoronoi.Size = new System.Drawing.Size(110, 30);
            this.btnDrawVoronoi.Text = "Діаграма Вороного";
            this.btnDrawVoronoi.UseVisualStyleBackColor = true;
            this.btnDrawVoronoi.Click += new System.EventHandler(this.DrawVoronoi_Click);
            this.btnDrawVoronoi.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            // 
            // comboThreads
            // 
            this.comboThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboThreads.Items.AddRange(new object[] {"1 поток", "Багатопоточність"});
            this.comboThreads.Location = new System.Drawing.Point(740, 10);
            this.comboThreads.Name = "comboThreads";
            this.comboThreads.Size = new System.Drawing.Size(190, 24);
            this.comboThreads.SelectedIndex = 0;
            this.comboThreads.BackColor = Color.LightYellow;
            this.comboThreads.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            // 
            // comboMetrics
            // 
            this.comboMetrics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMetrics.Items.AddRange(new object[] {"Евклідова", "Манхетенська", "Чебишова"});
            this.comboMetrics.Location = new System.Drawing.Point(950, 10);
            this.comboMetrics.Name = "comboMetrics";
            this.comboMetrics.Size = new System.Drawing.Size(150, 24);
            this.comboMetrics.SelectedIndex = 0;
            this.comboMetrics.BackColor = Color.LightYellow;       
            this.comboMetrics.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1500, 800);
            this.Controls.Add(this.pictureBoxVoronoi);
            this.Controls.Add(this.panelTop);
            this.Name = "Form1";
            this.Text = "Діаграма Вороного";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVoronoi)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
