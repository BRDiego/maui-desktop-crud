namespace DesktopMauiCrud.MauiCrud.Screens.GraphicDrawing.Charts
{
    public class MultiLineChartDraw : IDrawable, ICustomChart<IEnumerable<MultiLineChartItem>>
    {
        private IEnumerable<MultiLineChartItem> _series;


        public MultiLineChartDraw()
            => _series = new List<MultiLineChartItem>();

        public void UpdateData(
            IEnumerable<MultiLineChartItem> series) 
            => _series = series;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_series.Count() == 0) return;

            float width = dirtyRect.Width;
            float height = dirtyRect.Height;

            foreach (var item in _series)
            {
                var data = item.ValueArray;
                var color = item.LineColor;

                if (data.Length < 2) continue;

                float stepX = width / (data.Length - 1);
                double maxY = data.Max();

                canvas.StrokeColor = color;
                canvas.StrokeSize = 3;

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
            }
        }
    }

    public class MultiLineChartItem
    {
        public required double[] ValueArray { get; set; }
        public required Color LineColor{ get; set; }
    }
}
