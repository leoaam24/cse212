using System.Net.Mail;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

        // Group words by their canonical form (sorted unique characters)
        foreach (string word in words)
        {
            char[] chars = word.Distinct().OrderBy(c => c).ToArray();
            string key = new string(chars);

            if (!groups.TryGetValue(key, out var group))
            {
                group = new List<string>();
                groups[key] = group;
            }
            group.Add(word);
        }

        List<string> result = new List<string>();

        // Generate pairs from each group
        foreach (var group in groups.Values)
        {
            // Pair consecutive elements only if they are distinct
            for (int i = 0; i < group.Count; i += 2)
            {
                if (i + 1 < group.Count)
                {
                    string word1 = group[i];
                    string word2 = group[i + 1];
                    if (word1 != word2)
                    {
                        result.Add($"{word1}&{word2}");
                    }
                }
            }
        }

        return result.ToArray();
        // List<string> result = [];
        // List<string> currentList = new List<string>(words);
        // HashSet<char> hashWord = new HashSet<char>(currentList[0]);
        // HashSet<char> tempHashWord = new HashSet<char>();
        //     int i = 1;
        //     while (i != 0) {
        //         if (i > currentList.Count - 1) {
        //             currentList.Remove(currentList[0]);
        //             if (currentList.Count != 0) {
        //                 hashWord = new HashSet<char>(currentList[0]);
        //                 i = 1;
        //             } else {
        //                 i = 0;
        //             }
        //         } else {
        //             if (i < currentList.Count){
        //                 tempHashWord = new HashSet<char>(currentList[i]);
        //                 if (hashWord.SetEquals(tempHashWord)){
        //                     string hWord1 = string.Join("", hashWord);
        //                     string hWord2 = string.Join("", tempHashWord);
        //                     string resultString = $"{hWord1}&{hWord2}";
        //                     result.Add(resultString);
        //                     currentList.Remove(currentList[i]);
        //                     currentList.Remove(currentList[0]);
        //                     if (currentList.Count != 0) {
        //                      hashWord = new HashSet<char>(currentList[0]);
        //                         i = 1;
        //                     } else {
        //                         i = 0;
        //                     }
        //                 } else {
        //                     i++;
        //                 }
        //             }
        //         }     
        //     }
            

        

        // string[] Finalresult = result.ToArray();
        // return Finalresult;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degreeTitle = fields[3];

            if (!degrees.ContainsKey(degreeTitle)){
                degrees.Add(degreeTitle, 1);
            } else {
                degrees[degreeTitle] = degrees[degreeTitle]+1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string noWhiteSpaceWord1 = Regex.Replace(word1, @"\s+", "");
        string noWhiteSpaceWord2 = Regex.Replace(word2, @"\s+", "");
        char[] toArrayWord1 = noWhiteSpaceWord1.ToCharArray();
        string arrayedWord1 = string.Join(",", noWhiteSpaceWord1.ToLower());
        char[] toArrayWord2 = noWhiteSpaceWord2.ToCharArray();
        string arrayedWord2 = string.Join(",", noWhiteSpaceWord2.ToLower());
        HashSet<char> hashedWord1 = new HashSet<char>(arrayedWord1.ToLower());
        HashSet<char> hashedWord2 = new HashSet<char>(arrayedWord2.ToLower());

       if (toArrayWord1.Length == toArrayWord2.Length && hashedWord1.SetEquals(hashedWord2)) {

            if (arrayedWord1.OrderBy(x => x).SequenceEqual(arrayedWord2.OrderBy(x => x))){
            return true;
            } else {
                return false;
            }
       }else {
        return false;
       }
        
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        List<string> toReturn = new();
        
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        List<string> result = new();

       foreach (var item in featureCollection.Features) {
            string place = item.Place;
            double magnitude = item.Mag;

            string toString = $"{place} - Mag {magnitude}";
            result.Add(toString);
       };

       string[] finalResult = result.ToArray();
       return finalResult;
        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

    }
}