
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	private static readonly string _filePath = Application.persistentDataPath + "/saveR.gamesave";

	public static void SaveDate()
	{
		var binaryFormatter = new BinaryFormatter();
		var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);

		binaryFormatter.Serialize(fileStream, ControlListRecords.Records);

		fileStream.Close();
	}

	public static void LoadDate()
	{
		if (!File.Exists(_filePath))
			return;

		var binaryFormatter = new BinaryFormatter();
		var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);

		ControlListRecords.Records = (List<Record>) binaryFormatter.Deserialize(fileStream);

		fileStream.Close();
	}
}