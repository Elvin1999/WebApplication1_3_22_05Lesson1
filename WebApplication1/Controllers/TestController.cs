using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private readonly ICalculator _calculator1;
        private readonly ICalculator _calculator2;

        public TestController(ICalculator calculator1, ICalculator calculator2)
        {
            _calculator1 = calculator1;
            _calculator2 = calculator2;
        }

        public string Index()
        {
            _calculator1.Calculate(1);
            _calculator2.Calculate(1);
            return $"";
        }
    }
}
