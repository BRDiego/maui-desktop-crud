using DesktopMauiCrud.MauiCrud.Screens.GraphicDrawing.Enums;

namespace DesktopMauiCrud.MauiCrud.Screens.GraphicDrawing.Charts
{
    public class MultiLineChartDraw : IDrawable
    {
        private ICollection<MultiLineChartItem> _series;
        private readonly Color[] _palette = new[]
        {
            Colors.Blue,
            Colors.Yellow,
            Colors.Red,
            Colors.Purple,
            Colors.Gray
        };

        private readonly List<float[]?> lineStrokes = new List<float[]?>()
        {
            null,
            new float[] { 6, 4 },
            new float[] { 2, 4 },
            new float[] { 6, 4, 2, 4 },
            new float[] { 8, 2, 2, 2, 2, 6 }
        };

        public MultiLineChartDraw()
            => _series = new List<MultiLineChartItem>();

        public void AddData(
            double[] dataArray, LineDrawStyles lineStyle) 
            => _series.Add(
                new MultiLineChartItem() { ValueArray = dataArray, LineStyle = lineStyle}
            );

        public void Reset()
            => _series = new List<MultiLineChartItem>();

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_series.Count() == 0) return;

            float width = dirtyRect.Width;
            float height = dirtyRect.Height;
            ushort lineIndex = 0;

            foreach (var item in _series)
            {
                var data = item.ValueArray;

                if (data.Length < 2) continue;

                float stepX = width / (data.Length - 1);
                double maxY = data.Max();

                canvas.StrokeColor = _palette[lineIndex % _palette.Length];
                canvas.StrokeSize = 3;
                canvas.StrokeDashPattern = GetDashPattern(item.LineStyle, lineIndex);

                var path = new PathF();
                for (int i = 0; i < data.Length; i++)
                {
                    float x = i * stepX;
                    float y = height - (float)(data[i] / maxY * height);

                    if (i == 0)
                        path.MoveTo(x, y);
                    else
                        path.LineTo(x, y);
                }

                canvas.DrawPath(path);
                lineIndex++;
            }
        }

        public float[]? GetDashPattern(LineDrawStyles style, ushort lineIndex)
        {
            return style switch
            {
                LineDrawStyles.Solid => null,
                LineDrawStyles.Dashed => lineStrokes[1],
                LineDrawStyles.Dotted => lineStrokes[2],
                LineDrawStyles.DashDot => lineStrokes[3],
                LineDrawStyles.Mixed => lineStrokes[lineIndex],
                _ => null
            };
        }
    }

    public class MultiLineChartItem
    {
        public required double[] ValueArray { get; set; }
        public required LineDrawStyles LineStyle{ get; set; }
    }
}
