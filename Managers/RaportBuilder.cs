using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TrackerTreningow;

namespace TrackerTreningow_
{
    public class RaportBuilder
    {
        public static string BuildTextReport(List<Training> list,DateTime time)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"RAPORT TRENINGÓW — ${time:yyyy-MM}");
            sb.AppendLine(new string('=', 52));
            sb.AppendLine();

            foreach (var t in list.OrderBy(x => x.Date))
            {
                string star = t.IsImportant ? "*" : " ";

                sb.AppendLine($"{star} {t.Date:yyyy-MM-dd}  {t.Type,-10}  {t.Minutes,4} min");

                if (t.Note.Length > 0)
                {
                    sb.AppendLine($"                {t.Note}");
                }
            }

            int total = list.Sum(t => t.Minutes);

            sb.AppendLine();
            sb.AppendLine(new string('=', 52));
            sb.AppendLine($"Liczba treningów: {list.Count}");
            sb.AppendLine($"Suma minut:       {total} ({FormatMinutes(total)})");
            int average = list.Count == 0 ? 0 : total / list.Count;
            sb.AppendLine($"Średnia:          {average} min");
            sb.AppendLine();
            sb.AppendLine($"Wygenerowano: {DateTime.Now:yyyy-MM-dd HH:mm}");

            return sb.ToString();
        }

        public static string BuildCsv(List<Training> list)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Data;Rodzaj;Minuty;Wazny;Notatka");

            foreach (var t in list.OrderBy(x => x.Date))
            {
                sb.AppendLine(string.Join(';',
                    t.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EscapeCsv(t.Type),
                    t.Minutes.ToString(CultureInfo.InvariantCulture),
                    t.IsImportant ? "tak" : "nie",
                    EscapeCsv(t.Note)));
            }

            return sb.ToString();
        }

        private static string FormatMinutes(int minutes)
        {
            int hours = minutes / 60;
            int rest = minutes % 60;

            return hours > 0 ? $"{hours} h {rest} min" : $"{rest} min";
        }
        private static string EscapeCsv(string value)
        {
            if (value.Contains(';') || value.Contains('"') || value.Contains('\n'))
            {
                return '"' + value.Replace("\"", "\"\"") + '"';
            }

            return value;
        }
    }
}
