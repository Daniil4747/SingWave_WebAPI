namespace TestWebAPI.Models
{
    public class ParametersSinusoid
    {
        public double A { get; set; } // Амплитуда в условных единицах

        public double Fd { get; set; } // Частота дискретизации сигнала в точках за секунду

        public double Fs { get; set; } // Частота сигнала в герцах

        public int N { get; set; } // Количество периодов
    }
}