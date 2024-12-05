using Aquality.Selenium.Elements.Interfaces;

namespace TestProject1.Utils
{
    public static class ElementExtensions
    {
        public static IEnumerable<string> GetClasses(this IElement element)
        {
            return element.GetAttribute("class")?.Split(' ') ?? Array.Empty<string>();
        }

        public static bool HasClass(this IElement element, string className)
        {
            return element.GetClasses().Contains(className);
        }
    }
}
