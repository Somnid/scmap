using System.Dynamic;
using System.IO;
using Newtonsoft.Json;

namespace scmap.Helpers
{
    public static class ConfigHelper
    {
        public static bool CheckOrCreate(string path)
        {
            try
            {
                using (var fileStream = File.OpenWrite(path)) {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ExpandoObject Read()
        {
            return Read(Constants.ConfigPath);
        }

        public static void Write(dynamic config)
        {
            Write(config, Constants.ConfigPath);
        }

        private static ExpandoObject Read(string path)
        {
            var text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ExpandoObject>(text) ?? new ExpandoObject();
        }

        public static void Write(dynamic config, string path)
        {
            var text = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(path, text);
        }
    }
}
