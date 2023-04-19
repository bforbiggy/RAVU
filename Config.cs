public class Config
{
	private string? left;
	public string LEFT
	{
		get
		{
			if (left is null)
			{
				Console.Write("Enter path to base video folder:");
				left = Console.ReadLine();
			}
			return left!;
		}
		set
		{
			left = value;
		}
	}

	private string? right;
	public string RIGHT
	{
		get
		{
			if (right is null)
			{
				Console.Write("Enter path to appended video folder:");
				right = Console.ReadLine();
			}
			return right!;
		}
		set
		{
			right = value;
		}
	}

	private string? api_key;
	public string? API_KEY
	{
		get
		{
			if (api_key is null)
			{
				Console.Write("Enter youtube API key:");
				api_key = Console.ReadLine();
			}
			return api_key!;
		}
		set
		{
			api_key = value;
		}
	}

	public Dictionary<String, HashSet<String>>? Premade { get; set; }
}
