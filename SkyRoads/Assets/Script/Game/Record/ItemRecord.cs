
using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemRecord : MonoBehaviour
{
	[SerializeField] private Text _index;
	[SerializeField] private Text _date;
	[SerializeField] private Text _score;
	[SerializeField] private Text _minute;
	[SerializeField] private Text _second;

	[SerializeField] private Record _record;

	public void SetInfo(Record record, int index)
	{
		_record = record;
		_date.text = record.Date.ToString();
		_score.text = record.Score.ToString();
		_minute.text = record.Minute.ToString("00");
		_second.text = record.Second.ToString("00");

		_index.text = Convert.ToString(index);
	}
}