using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

namespace fltlnd
{
    [ExecuteInEditMode]
    public class Flatland_Camera : MonoBehaviour
    {

        public Image newScene;
        private Camera cam;

        public bool updateEditor = false;

        // public int nr = 0;
        // public GameObject blackener;
        // public bool haveBlackener = false;

        // private int saveFrame = 10;
        // private int currentFrame = 0;

        // public bool safe = false;

        public Texture2D currentFrameIMG;

        private Vector2Int imgDimensions;

        // Use this for initialization
        void Awake()
        {
            cam = this.GetComponent<Camera>();
            //Initialize all values
            imgDimensions = new Vector2Int(cam.scaledPixelWidth, 1);// Screen.height);
            // int height = //1 + Mathf.FloorToInt(Random.Range(0.0F, 1.0F) * Screen.height);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {

                StartCoroutine(UploadPNG());
            }
        }


        // Update is called once per frame
        void OnPostRender()
        {

            RenderAsLine();
        }

        private void RenderAsLine()
        {
            // Create a texture the size of the screen, RGB24 format
            // int width = Screen.width;
            // int height = 1 + Mathf.FloorToInt(Random.Range(0.0F, 1.0F) * Screen.height);
            Texture2D tex = new Texture2D(imgDimensions.x, imgDimensions.y, TextureFormat.RGB24, false);

            // Read screen contents into the texture
            // tex.ReadPixels(new Rect(0, Screen.height * 0.5F - imgDimensions.y / 2, imgDimensions.x, imgDimensions.y), 0, 0);

            tex.ReadPixels(new Rect(0, Screen.height * 0.5F - imgDimensions.y / 2, imgDimensions.x, imgDimensions.y), 0, 0);
            tex.Apply();

            //Put the captured image into the scene Sprite
            currentFrameIMG = tex;

            newScene.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f)); ;
            newScene.sprite.texture.filterMode = FilterMode.Point;

            // StartCoroutine(Capture(tex));

        }

        private IEnumerator Capture(Texture2D _tex)
        {

            byte[] bytes = _tex.EncodeToPNG();

            // For testing purposes, also write to a file in the project folder
            // File.WriteAllBytes(Application.dataPath + "/../visuals/fltlnd" + System.DateTime.Now.ToBinary() + (currentFrame / saveFrame) + ".png", bytes);
            //		}
            yield return new WaitForEndOfFrame();
        }

        //Save Screenshot
        private IEnumerator UploadPNG()
        {
            // We should only read the screen buffer after rendering is complete
            yield return new WaitForEndOfFrame();

            // Create a texture the size of the screen, RGB24 format
            int width = Screen.width;
            int height = 1;
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, Screen.height * 0.5F, width, height), 0, 0);
            tex.Apply();

            newScene.GetComponent<Material>().SetTexture("_Color", tex);


            // Encode texture into PNG
            byte[] bytes = tex.EncodeToPNG();
            Object.Destroy(tex);

            // For testing purposes, also write to a file in the project folder
            File.WriteAllBytes(Application.dataPath + "/../SavedScreen_.png", bytes);
        }
    }
}