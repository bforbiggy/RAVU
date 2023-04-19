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

	private string? clientID;
	public string CLIENTID
	{
		get
		{
			if (clientID is null)
			{
				Console.Write("Enter youtube client id key:");
				clientID = Console.ReadLine();
			}
			return clientID!;
		}
		set
		{
			clientID = value;
		}
	}

	private string? clientSecret;
	public string CLIENTSECRET
	{
		get
		{
			if (clientSecret is null)
			{
				Console.Write("Enter youtube client secret key:");
				clientSecret = Console.ReadLine();
			}
			return clientSecret!;
		}
		set
		{
			clientSecret = value;
		}
	}

	public Dictionary<String, HashSet<String>>? Premade { get; set; }
}
