using System.Linq;

namespace EnergonSoftware.Netrunner.Core.Util
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(string value)
        {
            return null == value || value.All(char.IsWhiteSpace);
        }
    }
}
