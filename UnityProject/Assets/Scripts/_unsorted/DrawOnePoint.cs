using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DrawOnePoint : MonoBehaviour {

	public Image newScene;

	// Use this for initialization
	void Start () {

//		this.GetComponent<Camera>().backgroundColor = RenderSettings.fogColor;
	
	}
	
	// Update is called once per frame
	void OnPostRender () {

//		if(Input.GetKeyDown(KeyCode.P)){
//
//			StartCoroutine(UploadPNG());
//		}
	

		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = 1;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, Screen.height*0.5F, width, height), 0, 0);
		tex.Apply();

		newScene.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

//		newScene.GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
	}

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
		 File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
	}
}
