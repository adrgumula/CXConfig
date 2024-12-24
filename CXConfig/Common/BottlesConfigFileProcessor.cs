using System.Text.RegularExpressions;
using System.Linq;
namespace CXConfig.Common;

public class BottlesConfigFileProcessor
{
    public static Dictionary<string, string> PhaseFile(string fullFilePath){
        
        var results = new Dictionary<string,string>();
        
        if( string.IsNullOrEmpty(fullFilePath))
            return results;
        
        if( !File.Exists(fullFilePath) )
            return results;

        try
        {
            var lines = File.ReadAllLines(fullFilePath).Reverse();

            var regex = new Regex(Names.BottleConfigFileEntryRegEx);

            foreach (var line in lines)
            {
                if(line.StartsWith(Names.BottleConfigFileCommentedLine))
                    continue;
                // Match the line against the regular expression
                var matches = regex.Matches(line);

                foreach (var match in matches.Where(match => match.Groups.Count == 3))
                {
                    string name = match.Groups[1].Value;
                    string value = match.Groups[2].Value;

                    results[name] = value;
                }
            }

            foreach (var pair in results)
            {
                System.Diagnostics.Debug.WriteLine($"Name: {pair.Key}, Value: {pair.Value}");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");
        }
        

        return results;
    }

}
