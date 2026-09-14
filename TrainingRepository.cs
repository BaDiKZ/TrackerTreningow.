using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using TrackerTreningow;
namespace TrackerTreningow_
{
    internal class TrainingRepository
    {
        private readonly string _folder;
        private readonly string _file;

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public TrainingRepository()
        {
            _folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"TrackerTreningow");
            _file = Path.Combine(_folder, "trainings.json");
        }

        public string DataFolder { get { return _folder; } }

        public string? LastLoadWarning { get; private set; }

        public List<Training> Load()
        {
            LastLoadWarning = null;

            if (!File.Exists(_file))
            {
                return new List<Training>();
            }

            try
            {
                string json = File.ReadAllText(_file);
                return JsonSerializer.Deserialize<List<Training>>(json)
                       ?? new List<Training>();
            }
            catch (JsonException)
            {
                string broken = Path.Combine(_folder,
                    $"trainings-uszkodzony-{DateTime.Now:yyyyMMdd-HHmmss}.json");

                File.Move(_file, broken);

                LastLoadWarning = $"Plik z danymi był uszkodzony. Kopia: {broken}";
                return new List<Training>();
            }
        }
        public void Save(List<Training> trainings)
        {
            Directory.CreateDirectory(_folder);

            string json = JsonSerializer.Serialize(trainings, Options);
            string temp = _file + ".tmp";

            File.WriteAllText(temp, json);   // najpierw do pliku tymczasowego
            File.Move(temp, _file, true);  // dopiero teraz podmiana
        }
    }
}
