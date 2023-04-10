using System.Text.Json.Nodes;

// Parse and load config
string API_KEY = null!;
Dictionary<String, HashSet<String>> premadeVideos = new Dictionary<String, HashSet<String>>();
try
{
	Util.loadConfig(@"config.json", ref API_KEY, ref premadeVideos);
}
catch (Exception) { }

// Randomly select video from A and B side