using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackenerAdjuster : MonoBehaviour {

	public RectTransform[] blackeners;
	private float visibleSize = 0.0F;
	public float targetSize;

	private void Start(){

//		visibleSize =  0.;
		//Color
		blackeners[0].GetComponent<Image>().color = RenderSettings.fogColor;
		blackeners[1].GetComponent<Image>().color = RenderSettings.fogColor;

		Camera.main.backgroundColor = RenderSettings.fogColor;
	}

	// Use this for initialization
	void Update () {

//		visibleSize += 0.08F * Time.deltaTime * 0.5F;
//
//		if(visibleSize < targetSize){
//
////			visibleSize = targetSize;
//
//			blackeners[0].anchorMin = new Vector2(0.0F,0.0F);
//			blackeners[0].anchorMax = new Vector2(1.0F, 0.5F-visibleSize);
//
//			blackeners[1].anchorMin = new Vector2(0.0F, 0.5F+visibleSize);
//			blackeners[1].anchorMax = new Vector2(1.0F, 1.0F);
//		}
	}
}
