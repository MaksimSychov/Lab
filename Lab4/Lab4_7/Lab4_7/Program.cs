using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
class Program
{
	static void Main(string[] args)
	{
		string[] trackList = new string[10];
		trackList[0] = "Gentle Giant – Free Hand [06:15]";
		trackList[1] = "Supertramp – Child Of Vision [07:27]";
		trackList[2] = "Camel – Lawrence [10:46]";
		trackList[3] = "Yes – Don’t Kill The Whale [03:55]";
		trackList[4] = "10CC – Notell Hotel [04:58]";
		trackList[5] = "Nektar – King Of Twilight [04:16]";
		trackList[6] = "The Flower Kings – Monsters & Men [21:19]";
		trackList[7] = "Focus – Le Clochard [01:59]";
		trackList[8] = "Pendragon – Fallen Dream And Angel [05:23]";
		trackList[9] = "Kaipa – Remains Of The Day [08:02]";
		int digitMin = 0;
		int digitSec = 0;
		int count = 1;
		decimal sum = 0;
		string shortestSong = string.Empty;
		string longestSong = string.Empty;
		int minDuration = int.MaxValue, maxDuration = 0;
		int[] durations = new int[trackList.Length];
		int minDifference = int.MaxValue, firstTrackIndex = 0, secondTrackIndex = 0;
		for (int i = 0; i < trackList.Length; i++)
		{
			Console.WriteLine($"{count}) " + trackList[i]);
			count++;
			Regex minutes = new Regex(@"(\d{2})(?=:)");
			Regex seconds = new Regex(@"(?<=:)(\d{2})");
			MatchCollection min = minutes.Matches(trackList[i]);
			MatchCollection sec = seconds.Matches(trackList[i]);
			foreach (Match m in min)
			{
				digitMin = int.Parse(m.Value);
				Console.WriteLine("Минуты: " + digitMin);
				sum += digitMin * 60;
			}
			foreach (Match s in sec)
			{
				digitSec = int.Parse(s.Value);
				Console.WriteLine("Секунды: " + digitSec);
				sum += digitSec;
			}
			Console.WriteLine();
			if (digitMin > maxDuration)
			{
				maxDuration = digitMin;
				longestSong = trackList[i];
			}
			if (digitMin < minDuration)
			{
				minDuration = digitMin;
				shortestSong = trackList[i];
			}
			durations[i] = digitMin * 60 + digitSec;
		}
		for (int q = 0; q < durations.Length; q++)
		{
			for (int w = 0; w < durations.Length; w++)
			{
				if (q == w)
				{
					continue;
				}
				if (Math.Abs(durations[q] - durations[w]) < minDifference)
				{
					firstTrackIndex = q;
					secondTrackIndex = w;
					minDifference = Math.Abs(durations[q] - durations[w]);
				}
			}
		}
		Console.WriteLine("Общее время: " + TotalTime(trackList).ToString() + " или " + sum + " секунд");
		Console.WriteLine("Самая длинная песня: " + longestSong);
		Console.WriteLine("Самая короткая песня: " + shortestSong);
		Console.WriteLine("Песни с минимальной разницей во времени звучания: \"{0}\" и \"{1}\"", trackList[firstTrackIndex], trackList[secondTrackIndex]);
		Console.ReadKey();
	}
	static int[] FindTime(string[] trackList)
	{
		int[] track_time = new int[trackList.Length];
		Regex regular = new Regex(@"(\[)([0-6]{0,1}[0-9]{1})(:)([0-6]{1}[0-9]{1})(\])");
		for (int i = 0; i < trackList.Length; i++)
		{
			Match match = regular.Match(trackList[i]);
			string temp_str = match.Value;
			temp_str = temp_str.Replace("[", "");
			temp_str = temp_str.Replace("]", "");
			temp_str = temp_str.Replace(":", " ");
			string[] temp_array = temp_str.Split();
			track_time[i] = int.Parse(temp_array[0]) * 60 + int.Parse(temp_array[1]);
		}
		return track_time;
	}
	static TimeSpan TotalTime(string[] trackList)
	{
		TimeSpan TimeSpan = new TimeSpan(0, 0, FindTime(trackList).Sum());
		return TimeSpan;
	}
}