using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveManager {

	public static SafeState savedState = new SafeState();
	
	/// <summary>
	/// Save the current Safe to a xlm file.
	/// </summary>
	public static void Save() {
		savedState = SafeState.current;
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/flatsave.gd");
		Debug.Log(savedState.player.posX);
		bf.Serialize(file, SaveManager.savedState);
		file.Close();
	}
	/// <summary>
	/// Load from a xlm file to enable sessions.
	/// </summary>
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/flatsave.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/flatsave.gd", FileMode.Open);
			SaveManager.savedState = (SafeState)bf.Deserialize(file);
			file.Close();
		}
	}
}
