using System.Text.Json;
using System.Text.Json.Nodes;

public class Util
{
	public static Random randy = new Random();

	/// <summary>
	///  Read config data from config file and 
	/// </summary>
	/// <param name="path"> Path to target file </param>
	/// <param name="API_KEY"> Youtube API Key</param>
	/// <param name="premadeVideos"> Dictionary containing videos already made</param>
	/// <exception cref="Exception"></exception>
	public static void LoadConfig(string path, ref string API_KEY, ref Dictionary<String, HashSet<String>> premadeVideos)
	{
		// Find and read file as json
		if (!File.Exists(path))
			throw new Exception("No config.json file found.");
		string text = File.ReadAllText(path);
		JsonNode root = JsonObject.Parse(text) ?? throw new Exception("Invalid config file format.");

		// Parse API key
		if (root["api_key"] != null)
			API_KEY = (string)root["api_key"]!;

		// Parse videos already made
		JsonObject premade = (JsonObject?)root["premade_videos"] ?? throw new Exception("No premade videos in config.");
		foreach (var entry in premade)
		{
			premadeVideos[entry.Key] = new HashSet<string>();
			foreach (var match in entry.Value!.AsArray())
			{
				premadeVideos[entry.Key].Add((string)match!);
			}
		}
	}

	/// <summary>
	/// Picks a random file from a specified folder
	/// </summary>
	/// <param name="folderPath"> Path to folder </param>
	/// <returns></returns>
	public static string RandomFile(string folderPath)
	{
		string[] files = Directory.GetFiles(folderPath);
		int index = randy.Next(files.Length);
		return files[index];
	}
}