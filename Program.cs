using System.Text.Json.Nodes;

// Parse and load config
string API_KEY = null!;
Dictionary<String, HashSet<String>> premadeVideos = new Dictionary<String, HashSet<String>>();
try
{
	Util.LoadConfig(@"config.json", ref API_KEY, ref premadeVideos);
}
catch (Exception) { }

// Randomly select video from A and B folder
// string left = Util.RandomFile("left");
// string right = Util.RandomFile("right");

// Combine videos to output
string command = "/C ";
command += $"ffmpeg -i \"concat:family.mp4|creature.mp4\" -c:a copy -c:v copy output.mkv";
Console.WriteLine(command);
System.Diagnostics.Process.Start("cmd.exe", command);

// Upload video