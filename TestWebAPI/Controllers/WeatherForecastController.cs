using TestWebAPI.Models;
using TestWebAPI.Serveis;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Reflection;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingWaveController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> GenerateSignal(ParametersSinusoid parameters)
        {
            Sinusoid sinusoid = new Sinusoid();
            // Генерация сигнала
            double[] signal = sinusoid.GenerateSinusoid(parameters.A, parameters.Fd, parameters.Fs, parameters.N);
            // Создание графического файла с сигналом
            var image = sinusoid.Signal(signal);
            // Сохранение изображения во временный файл
            string filePath = Path.GetTempFileName() + ".png";
            image.Save(filePath);

            // Создание HTTP-ответа с файлом
            return File(
            new FileStream(filePath, FileMode.Open, FileAccess.Read),
            "application/octet-stream",
            Path.GetFileName(filePath)
            );

        }      
    }
}
