using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoronoiWinForms;

namespace VoronoiWinForms
{
    public partial class Form1 : Form
    {
        private List<PointViewModel> Points = new();
        private PointViewModel selectedPoint = null;

        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(1500, 800);
            pictureBoxVoronoi.Dock = DockStyle.Fill;

            pictureBoxVoronoi.MouseClick += PictureBoxVoronoi_MouseClick;
            KeyDown += Form1_KeyDown;
            pictureBoxVoronoi.Paint += PictureBoxVoronoi_Paint;
        }
        private void GeneratePoints_Click(object sender, EventArgs e)
        {
            Random rand = new();
            int generated = 0;
            int attempts = 0;
            int width = pictureBoxVoronoi.Width;
            int height = pictureBoxVoronoi.Height;

            while (generated < 100 && attempts < 10000)
            {
                double x = rand.Next(0, width - 3);
                double y = rand.Next(0, height - 3);

                bool tooClose = Points.Any(p => Math.Pow(p.X - x, 2) + Math.Pow(p.Y - y, 2) < 100);
                if (!tooClose)
                {
                    Points.Add(new PointViewModel { X = x, Y = y });
                    generated++;
                }
                attempts++;
            }

            pictureBoxVoronoi.Invalidate();
        }
        private void DeletePoints_Click(object sender, EventArgs e)
        {
            Points.Clear();
            pictureBoxVoronoi.Invalidate();
        }
        private void DeleteSmallestAreas_Click(object sender, EventArgs e)
        {
            int metricIndex = comboMetrics.SelectedIndex;
            bool useParallel = false;

            var visualizer = new Algorithm(pictureBoxVoronoi, Points, useParallel, metricIndex);
            var pointAreas = visualizer.CalculateAreas();

            // Сортуємо точки за площею
            var smallestPoints = pointAreas
                .OrderBy(kv => kv.Value) 
                .Take(10)            
                .Select(kv => kv.Key)
                .ToList();

            foreach (var p in smallestPoints)
                Points.Remove(p);

            pictureBoxVoronoi.Invalidate();
        }
        private void PictureBoxVoronoi_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var point in Points)
            {
                double dx = point.X - e.X;
                double dy = point.Y - e.Y;
                if (dx * dx + dy * dy < 9)
                {
                    point.isSelected = true;
                    selectedPoint = point;
                    pictureBoxVoronoi.Invalidate();
                    return;
                }
            }
            Points.Add(new PointViewModel { X = e.X, Y = e.Y });
            pictureBoxVoronoi.Invalidate();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && selectedPoint != null)
            {
                Points.Remove(selectedPoint);
                selectedPoint = null;
                pictureBoxVoronoi.Invalidate();
            }
        }
        private void DrawVoronoi_Click(object sender, EventArgs e)
        {
            int metricIndex = comboMetrics.SelectedIndex;
            bool useParallel = false; 

            var visualizer = new Algorithm(pictureBoxVoronoi, Points, useParallel, metricIndex);
            visualizer.Run();
        }
        private void PictureBoxVoronoi_Paint(object sender, PaintEventArgs e)
        {
            foreach (var point in Points)
            {
                var brush = point.isSelected ? Brushes.Lime : Brushes.Red;
                e.Graphics.FillEllipse(brush, (float)point.X - 3, (float)point.Y - 3, 6, 6);
            }
        }
    }
}
