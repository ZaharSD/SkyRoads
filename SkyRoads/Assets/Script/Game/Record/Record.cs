
using System;

[Serializable]
public class Record
{
	public DateTime Date { get; }

	public int Score { get; }

	public int Second { get; }

	public int Minute { get; }

	public Record()
	{
		Date = DateTime.Now;
		Score = 0;
		Second = 0;
		Minute = 0;
	}

	public Record(DateTime date, int score, int second, int minute)
	{
		Date = date;
		Score = score;
		Second = second;
		Minute = minute;
	}
}