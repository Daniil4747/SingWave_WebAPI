using System.Drawing;

namespace TestWebAPI.Serveis
{
    public class Sinusoid
    {
        internal double[] GenerateSinusoid(double A, double Fd, double Fs, int N)
        {
            int Samples = (int)(Fs * N);
            double[] signal = new double[Samples];

            double t = 0.0;
            double dt = 1 / Fd;

            for (int i = 0; i < Samples; i++)
            {
                signal[i] = A * Math.Sin(2 * Math.PI * Fs * t);
                t += dt;
            }
            return signal;
        }

        internal Bitmap Signal(double[] signal)
        {
            int ArtWidth = 1200;
            int ArtHeight = 600;

            Bitmap bitmap = new Bitmap(ArtWidth, ArtHeight);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Green, 2);
                int points = signal.Length;

                for (int i = 0; i < points - 1; i++)
                {
                    int x1 = (int)(i * ArtWidth / points);
                    int y1 = (int)((signal[i] + 1) * ArtHeight / 2);

                    int x2 = (int)((i + 1) * ArtWidth / points);
                    int y2 = (int)((signal[i + 1] + 1) * ArtHeight / 2);

                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }
            return bitmap;
        }
    } 
}
