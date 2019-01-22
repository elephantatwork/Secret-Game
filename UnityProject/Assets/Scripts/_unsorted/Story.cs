using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Story : MonoBehaviour {

	public string[] storyBits;

	private List<string> storyList;

	private void Awake(){

		storyList = new List<string>();

		for(int i = 0; i < storyBits.Length; i++){
			storyList.Add(storyBits[i]);

			print(storyList[i]);
		}
	}

	public string GetStory(){

		if(storyList.Count > 0){

			int _randomPlotID = Random.Range(0, storyList.Count);

			string _plot = storyList[_randomPlotID];

			storyList.RemoveAt(_randomPlotID);

			return _plot;

		}else{

			return Narrator.instance.RandomQuote();;
		}

	}
	
}
