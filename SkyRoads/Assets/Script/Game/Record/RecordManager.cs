
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
	[SerializeField] private GameObject _content;

	[SerializeField] private List<Record> _records;

	[SerializeField] private ItemRecord _record;

	public static void SaveRecord(int record)
	{
		PlayerPrefs.SetInt("Record", record);
	}
	
	public static int GetRecord()
	{
		return PlayerPrefs.GetInt("Record");
	}

	private void Awake()
	{
		_records = new List<Record>();

		ControlListRecords.Isload += Load;
	}

	private void Load()
	{
		_records = ControlListRecords.GetActualValue();

		if (_content != null)
		{
			var records = gameObject.GetComponentsInChildren<ItemRecord>();

			foreach (var human in records)
				Destroy(human.gameObject);

			for (var i = 0; i < _records.Count; i++)
			{
				var newRecord = Instantiate(_record, gameObject.transform);

				newRecord.SetInfo(_records[i], i + 1);
			}
		}
	}
}