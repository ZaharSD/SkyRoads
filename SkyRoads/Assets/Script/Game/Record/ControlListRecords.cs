
using System;
using System.Collections.Generic;

[Serializable]
public static class ControlListRecords
{
	public static event Action Isload;

	public static List<Record> Records = new List<Record>();

	public static List<Record> GetActualValue()
	{
		return Records;
	}

	public static void Add(Record record)
	{
		Records.Add(record);

		SaveManager.SaveDate();
	}

	public static void Load()
	{
		Isload?.Invoke();
	}
}