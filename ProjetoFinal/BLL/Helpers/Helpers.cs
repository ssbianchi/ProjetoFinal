using System.Linq;

namespace ProjetoFinal.BLL.Helpers
{
    public class Helpers
    {
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
