namespace DesktopMauiCrud.MauiCrud.Screens.GraphicDrawing
{
    public class LineChartDraw : IDrawable
    {
        private double[] _dataArray;

        public LineChartDraw(double[] data) 
            => _dataArray = data;

        public void UpdateData(double[] data) => _dataArray = data;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_dataArray.Length < 2) return;

            float width = dirtyRect.Width;
            float height = dirtyRect.Height;
            float stepX = width / (_dataArray.Length - 1);
            double maxY = _dataArray.Max();

            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 3;

            var path = new PathF();
            for (int i = 0; i < _dataArray.Length; i++)
            {
                float x = i * stepX;
                float y = height - (float)(_dataArray[i] / maxY * height);

                if (i == 0)
                    path.MoveTo(x, y);
                else
                    path.LineTo(x, y);
            }

            canvas.DrawPath(path);
        }
    }
}
