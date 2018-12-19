using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;
					
public class Program
{
	public static void Main()
	{
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        int workHours = 56;
        int dayHours = 8;

        string pattern = "???8???";

        List<string> result = findSchedules(workHours, dayHours, pattern);		
		
        Console.WriteLine(String.Join("\n", result));
    }
	
	 public static List<string> findSchedules(int workHours, int dayHours, string pattern)
    {		
		var arrayOutput = pattern.ToCharArray();
		var result = new List<string>();
				
		string regexPattern = "^";
		for (int i=0; i<pattern.Length;i++)
		{
			if (pattern[i] == '?')
			{
				regexPattern+="[0-"+dayHours+"]";
			} else {
				regexPattern+="["+pattern[i]+"-"+pattern[i]+"]";
			}			
		}
		regexPattern+="$";		
		
		Regex rx = new Regex(regexPattern);
		int control = 0;
		var output = new List<String>();
		while (control <= 1111111*dayHours)
		{
			control++;
			var stringify = control.ToString().PadLeft(7, '0');
			if (rx.IsMatch(stringify))
			{
				if (sumAllCharacters(stringify) == workHours)
				{
					output.Add(stringify);				
				}
			}
		}		
		
		 return output.OrderBy(p=>p).ToList();
	 }	

	
	private static int sumAllCharacters(string stringify)
	{
		var soma = 0;
		var charArray = stringify.ToCharArray();
		foreach (var item in charArray)
		{
			soma+=(int)Char.GetNumericValue(item);
		}
		
		return soma;
	}
}
