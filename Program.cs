using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

// Load config
Config config = Util.loadConfig("config.json");

// Randomly select video from A and B folder
string a = Util.RandomFile(config.LEFT);
string b = Util.RandomFile(config.RIGHT);

// Combine videos to output
string command = Util.CombineCommand(a, b);
Process p = System.Diagnostics.Process.Start("cmd.exe", command);
p.WaitForExit();
p.Close();

// Upload video

// Save config
Util.saveConfig("config.json", config);