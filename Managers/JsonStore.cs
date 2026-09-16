using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace TrackerTreningow
{
    public class JsonStore<T>
    {
        private readonly string _folder;
        private readonly string _file;

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public JsonStore(string fileName)
        {
            _folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TrackerTreningow");

            _file = Path.Combine(_folder, fileName);
        }

        public string Folder { get { return _folder; } }
        public string? LastLoadWarning { get; private set; }

        public List<T> Load()
        {
            LastLoadWarning = null;

            if (!File.Exists(_file)) return new List<T>();

            try
            {
                string json = File.ReadAllText(_file);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (JsonException)
            {
                string broken = _file + $".uszkodzony-{DateTime.Now:yyyyMMdd-HHmmss}";
                File.Move(_file, broken);

                LastLoadWarning = $"Plik {_file} był uszkodzony. Kopia: {broken}";
                return new List<T>();
            }
        }

        public void Save(List<T> items)
        {
            Directory.CreateDirectory(_folder);

            string json = JsonSerializer.Serialize(items, Options);
            string temp = _file + ".tmp";

            File.WriteAllText(temp, json);
            File.Move(temp, _file, true);
        }
    }
}