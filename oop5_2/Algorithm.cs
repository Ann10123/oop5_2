using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using VoronoiWinForms;

public class Algorithm
{
    private PictureBox pictureBox;
    private List<PointViewModel> points;
    private bool IsParallel;
    private int metricIndex;
    private Bitmap bmp;

    public Algorithm(PictureBox pictureBox, List<PointViewModel> points, bool isParallel, int metricIndex)
    {
        this.pictureBox = pictureBox;
        this.points = points;
        this.IsParallel = isParallel;
        this.metricIndex = metricIndex;
    }
    public void Run()
    {
        int width = pictureBox.Width;
        int height = pictureBox.Height;
        bmp = new Bitmap(width, height);

        Process proc = Process.GetCurrentProcess();
        TimeSpan cpuStart = proc.TotalProcessorTime;
        long memBefore = proc.PrivateMemorySize64;
        Stopwatch sw = Stopwatch.StartNew();

        if (IsParallel)
        {
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                    DrawPixel(x, y);
            });
        }
        else
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    DrawPixel(x, y);
        }

        sw.Stop();
        proc.Refresh(); 
        TimeSpan cpuEnd = proc.TotalProcessorTime;
        long memAfter = proc.PrivateMemorySize64;
        pictureBox.Image = bmp;

        double elapsedRealTime = sw.Elapsed.TotalSeconds;
        double elapsedCpuTime = (cpuEnd - cpuStart).TotalSeconds;
        double memoryUsedMB = (memAfter - memBefore) / (1024.0 * 1024.0);

        pictureBox.Image = bmp;

        MessageBox.Show(
            $"• Реальний час: {elapsedRealTime:F2} с\n" +
            $"• Процесорний час: {elapsedCpuTime:F2} с\n" +
            $"• Використано пам’яті: {memoryUsedMB:F2} МБ",
            "🖥 Статистика"
        );
    }
    private void DrawPixel(int x, int y)
    {
        double minDist = double.MaxValue;
        int closestIndex = -1;

        for (int i = 0; i < points.Count; i++)
        {
            if (points[i].isGone) continue;

            double dx = x - points[i].X;
            double dy = y - points[i].Y;

            double dist = metricIndex switch
            {
                0 => dx * dx + dy * dy,
                1 => Math.Abs(dx) + Math.Abs(dy),
                2 => Math.Max(Math.Abs(dx), Math.Abs(dy)),
                _ => dx * dx + dy * dy
            };
            if (dist < minDist)
            {
                minDist = dist;
                closestIndex = i;
            }
        }
        if (closestIndex >= 0)
        {
            var rnd = new Random(closestIndex * 1000);
            Color color = Color.FromArgb(rnd.Next(60, 256), rnd.Next(60, 256), rnd.Next(60, 256));
            lock (bmp) bmp.SetPixel(x, y, color);
        }
    }
    public Dictionary<PointViewModel, double> CalculateAreas()
    {
        Dictionary<PointViewModel, double> areaMap = new();
        Bitmap bmp = new Bitmap(1500, 800);
        int width = bmp.Width;
        int height = bmp.Height;

        int[,] regionMap = BuildVoronoiRegions();

        // Рахуємо кількість пікселів (площа) для кожної точки
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int index = regionMap[x, y];
                if (index >= 0 && index < points.Count)
                {
                    var point = points[index];
                    if (!areaMap.ContainsKey(point))
                        areaMap[point] = 0;

                    areaMap[point]++;
                }
            }
        }
        return areaMap;
    }
    private int[,] BuildVoronoiRegions()
    {
        Bitmap bmp = new Bitmap(1500, 800);
        int width = bmp.Width;
        int height = bmp.Height;
        int[,] regionMap = new int[width, height];

        // Заповнюємо всі пікселі індексом -1 (немає точки)
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                regionMap[x, y] = -1;

        // Для кожного пікселя знаходимо найближчу точку
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                double minDistSquared = double.MaxValue;
                int closestIndex = -1;

                for (int i = 0; i < points.Count; i++)
                {
                    var p = points[i];
                    double dx = p.X - x;
                    double dy = p.Y - y;
                    double distSquared = dx * dx + dy * dy;

                    if (distSquared < minDistSquared)
                    {
                        minDistSquared = distSquared;
                        closestIndex = i;
                    }
                }
                regionMap[x, y] = closestIndex;
            }
        }
        return regionMap;
    }
}
