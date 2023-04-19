using System.Text.Json;
using System.Text.Json.Nodes;

public class Util
{
	public static Random randy = new Random();

	public static Config loadConfig(string path)
	{
		string jsontext = File.ReadAllText(path);
		Config config = JsonSerializer.Deserialize<Config>(jsontext) ?? new Config();
		config.Premade = config.Premade ?? new Dictionary<string, HashSet<string>>();
		return config;
	}

	public static void saveConfig(string path, Config config)
	{
		string jsonString = JsonSerializer.Serialize(config);
		File.WriteAllText("config.json", jsonString);
	}

	/// <summary>
	/// Picks a random file from a specified folder
	/// </summary>
	/// <param name="folder"> Path to folder </param>
	/// <returns></returns>
	public static string RandomFile(string folder)
	{
		string[] files = Directory.GetFiles(folder);
		int index = randy.Next(files.Length);
		return files[index];
	}

	public static string CombineCommand(string a, string b, string output = "output.mp4")
	{
		string command = "/C ";
		string input = $"-i \"{a}\" -i \"{b}\"";
		string filter = "-filter_complex \"[0:v]scale=1280:720,setsar=1[v0];[1:v]scale=1280:720,setsar=1[v1];[v0][0:a][v1][1:a]concat=n=2:v=1:a=1[v][a]\"";
		string mapping = "-map \"[v]\" -map \"[a]\"";
		command += $"ffmpeg {input} {filter} {mapping} {output}";
		return command;
	}
}