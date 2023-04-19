using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

// Load config
Config config = Util.loadConfig("config.json");
Console.WriteLine("Config loaded.");

// Randomly select video from A and B folder
string a = Util.RandomFile(config.LEFT);
string b = Util.RandomFile(config.RIGHT);
Console.WriteLine("Videos randomly selected.");

// Combine videos to output
string command = Util.CombineCommand(a, b);
Process p = Process.Start("cmd.exe", command);
p.WaitForExit();
p.Close();
Console.WriteLine("Videos combined.");

// Set video details
var youtubeService = Util.connectYoutube(config.CLIENTID, config.CLIENTSECRET);
Video video = new Video()
{
	Snippet = new VideoSnippet
	{
		Title = "Test video",
		Description = "This is a test video.",
		Tags = new string[] { "test", "video" },
	},
	Status = new VideoStatus { PrivacyStatus = "private" }
};

// Upload video to youtube
var req = youtubeService.Videos.Insert(video, "snippet,status", new FileStream("output.mp4", FileMode.Open), "video/*");
var upload = req.Upload();
Console.WriteLine($"Upload Result: {upload.Status}");
if (upload.Status == Google.Apis.Upload.UploadStatus.Completed)
	Console.WriteLine($"Youtube URL: https://www.youtube.com/watch?v={req.ResponseBody.Id}");

// Save config
Util.saveConfig("config.json", config);