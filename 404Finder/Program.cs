﻿

internal static partial class Program
{
	internal static int Main(string[] args)
	{

		var fstArg = args[0];

		if (isUrl(fstArg))
        {
			urlWalker(fstArg);
        } else if (File.Exists(fstArg))
        {
			var urls = File.ReadAllLines(fstArg).Where(line => isUrl(line)).ToList().ConvertAll(a => (dynamic)a);
			if (urls.Count() == 0)
            {
				Console.WriteLine(" file you gave has no valid url inside. ");
				Console.WriteLine(" show urls.txt to get infomation. ");
				helper();
				Environment.Exit(1);
			}
			looper(urls, (url, _) => urlWalker(url));
        }
		else
        {
			Console.WriteLine(" you sent invalid param(s). ");
			Console.WriteLine(" show parameters explanation below. ");
			helper();
			Environment.Exit(1);
        }

		return 0;
	}

}

