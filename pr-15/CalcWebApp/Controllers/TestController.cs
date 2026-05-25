using Microsoft.AspNetCore.Mvc;

namespace CalcWebApp.Controllers
{
    public class TestController : Controller
    {
        public string Index()
        {
            return "this is test";
        }

        public string CheckDate()
        {
            return $"today is {DateTime.UtcNow}";
        }

        public string GetResult(int a, int b, string operation)
        {
            switch (operation)
            {
                case "Add":
                    return $"{a + b}";

                case "Sub":
                    return $"{a - b}";

                case "Mul":
                    return $"{a * b}";

                case "Div":
                    return $"{a / b}";

                default:
                    return "Неизвестная операция";
            }
        }

        public string GetInfo()
        {
            return $"Denisov Alexey Vladimirovich \n" +
                $"GitHub: https://github.com/l1nehalt";
        }
    }
}
