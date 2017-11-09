using System.Linq;

namespace MethodsInDetails
{
    public class Task5
    {
        public int[] LuckyFilter(int[] input) => input.Where(i => i.ToString().Contains("7")).ToArray();
    }
}