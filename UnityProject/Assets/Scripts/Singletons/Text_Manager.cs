using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Text_Manager : MonoBehaviour {

	public static Text_Manager instance {get; private set;}	

	private Text word;
	private Text sentence;

	public List<string> new_Words;
	private float wait_Time_Per = 0.4F;
	private float decelaration = 0.1F;

	public bool Sentence_Enabled = false;

	private void Awake(){
		instance = this;
	}

	private void Start(){

		word = GameObject.Find ("Word").GetComponent<Text>();
		sentence = GameObject.Find ("Sentence").GetComponent<Text>();

//		AddText(true, "What are we looking for ? \n");
	}

	public void AddText(bool _delete, string _new_Text){

		Debug.Log("New Text");

		if(_delete){
		
			sentence.text = "";
		}

		string[] _split_Text = _new_Text.Split(' ');

		foreach(string _word in _split_Text)
			new_Words.Add (_word);

		StartCoroutine(PlayText());
	}

	private IEnumerator PlayText(){

		while(new_Words.Count > 0){

			word.text = new_Words[0];

			if(Sentence_Enabled)
				sentence.text += " " + new_Words[0];

			new_Words.RemoveAt(0);

//			float waitTime = wait_Time_Per;
//
//			for(int i = 0; i < word.text.Length; i++){
//				waitTime += wait_Time_Per * decelaration*i;
//
//			}

//			print (waitTime);

			yield return new WaitForSeconds(wait_Time_Per);
//			yield return new WaitForSeconds(Mathf.Clamp(wait_Time_Per*word.text.Length, 0.2F, 3.0F));
		}

		word.text = "";

		new_Words.Clear();
	}
}
