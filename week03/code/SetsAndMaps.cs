using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> set = new(words);
        List<string> result = new();

        foreach (string word in words)
        {
            if (word[0] == word[1])
                continue;

            string reverse = "" + word[1] + word[0];

            if (set.Contains(reverse) && word.CompareTo(reverse) < 0)
            {
                result.Add($"{reverse} & {word}");
            }
        }

        return result.ToArray();
    }


    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> result = new();

        foreach (string line in File.ReadLines(filename))
        {
            string[] parts = line.Split(',');

            if (parts.Length > 3)
            {
                string degree = parts[3].Trim();

                if (degree.StartsWith("\""))
                    degree = degree.Replace("\"", "");

                if (result.ContainsKey(degree))
                    result[degree]++;
                else
                    result[degree] = 1;
            }
        }

        return result;
    }


    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new();

        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] == 0)
                counts.Remove(c);
        }

        return counts.Count == 0;
    }


    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using HttpClient client = new();

        string json = client.GetStringAsync(uri).GetAwaiter().GetResult();

        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        FeatureCollection? data =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> result = new();

        if (data == null)
            return result.ToArray();

        foreach (var feature in data.Features)
        {
            if (feature.Properties.Mag.HasValue)
            {
                result.Add(
                    $"{feature.Properties.Place} - Mag {feature.Properties.Mag}"
                );
            }
        }

        return result.ToArray();
    }
}