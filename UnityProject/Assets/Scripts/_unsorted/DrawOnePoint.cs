using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DrawOnePoint : MonoBehaviour {

	public Image newScene;

	public int nr = 0;
	public GameObject blackener;
	public bool haveBlackener = false;

	private int saveFrame = 10;
	private int currentFrame = 0;

	public bool safe = false;

	public Texture2D currentFrameIMG;

	// Use this for initialization
	void Awake () {

//		this.GetComponent<Camera>().backgroundColor = RenderSettings.fogColor;
		blackener = GameObject.Find("Blackener_min");

//		if(Helper.instance.capture){
//			StartCoroutine(Capture());
//		}
	}
	
	// Update is called once per frame
	void OnPostRender () {

		if(Input.GetKeyDown(KeyCode.P)){

			StartCoroutine(UploadPNG());
		}
	
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = 1 + Mathf.FloorToInt(Random.Range(0.0F,1.0F) * Screen.height);
		Debug.Log(height);
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, Screen.height*0.5F - height/2, width, height), 0, 0);
		tex.Apply();

		//Put the captured image into the scene Sprite
		//print (newScene);
		currentFrameIMG = tex;

		newScene.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));;
		newScene.sprite.texture.filterMode = FilterMode.Point;


		if(haveBlackener)
			blackener.GetComponent<Image>().color = tex.GetPixel(Screen.width/2,0);//RenderSettings.fogColor;

		StartCoroutine(Capture(tex));

	}	

	private IEnumerator Capture(Texture2D _tex){

//		currentFrame ++;
//
//		if((currentFrame % saveFrame) == 0){

		byte[] bytes = _tex.EncodeToPNG();
		//Object.Destroy(_tex);

		// For testing purposes, also write to a file in the project folder
		File.WriteAllBytes(Application.dataPath + "/../visuals/fltlnd" + System.DateTime.Now.ToBinary()+ (currentFrame/saveFrame)+".png", bytes);
//		}
		yield return new WaitForEndOfFrame();
	}

	//Save Screenshot
	private IEnumerator UploadPNG() {
		// We should only read the screen buffer after rendering is complete
		yield return new WaitForEndOfFrame();
		
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = 1;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, Screen.height*0.5F, width, height), 0, 0);
		tex.Apply();

		newScene.GetComponent<Material>().SetTexture("_Color", tex);
		                                          
		
		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Object.Destroy(tex);
		
		// For testing purposes, also write to a file in the project folder
		 File.WriteAllBytes(Application.dataPath + "/../SavedScreen_.png", bytes);
	}
}
