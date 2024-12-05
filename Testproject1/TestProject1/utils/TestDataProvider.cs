using Newtonsoft.Json;
using TestProject1.Models;

namespace TestProject1.Utils
{
    public static class TestDataProvider
    {
        public static TestData Load()
        {
            var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "resources", "testdata.json");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Test data file not found at path: {filePath}");
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<TestData>(json)
                   ?? throw new InvalidOperationException("Failed to deserialize test data.");
        }
    }
}
