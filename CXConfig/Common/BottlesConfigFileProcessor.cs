using System.Text.RegularExpressions;
using System.Linq;
namespace CXConfig.Common;

public class BottlesConfigFileProcessor
{
    public static Dictionary<string, string> PhaseFile(string fullFilePath){
        
        var results = new Dictionary<string,string>();
        
        if( string.IsNullOrEmpty(fullFilePath))
            return results;
        if( File.Exists(fullFilePath))
            return results;

        try
        {
            var lines = File.ReadAllLines(fullFilePath);

            var regex = new Regex(Names.CXPatcherBottleFolderName);

            foreach (var line in lines)
            {
                // Match the line against the regular expression
                var matches = regex.Matches(line);
                
                foreach (var match in matches.Where(match => match.Groups.Count == 3))
                {
                    string name = match.Groups[1].Value;
                    string value = match.Groups[2].Value;
                    // Add the pair to the dictionary
                    results[name] = value;
                }
            }

            // Output the detected pairs
            // Console.WriteLine("Detected Pairs:");
            foreach (var pair in results)
            {
                Console.WriteLine($"Name: {pair.Key}, Value: {pair.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        

        return results;
    }

}
