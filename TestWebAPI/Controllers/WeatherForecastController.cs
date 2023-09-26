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
            // ��������� �������
            double[] signal = sinusoid.GenerateSinusoid(parameters.A, parameters.Fd, parameters.Fs, parameters.N);
            // �������� ������������ ����� � ��������
            var image = sinusoid.Signal(signal);
            // ���������� ����������� �� ��������� ����
            string filePath = Path.GetTempFileName() + ".png";
            image.Save(filePath);

            // �������� HTTP-������ � ������
            return File(
            new FileStream(filePath, FileMode.Open, FileAccess.Read),
            "application/octet-stream",
            Path.GetFileName(filePath)
            );

        }      
    }
}
