using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SnapshotSaveLoad : MonoBehaviour
{
    public RenderTexture rt;
    public GameObject wallParent;
    public Camera snapshotCam;
    public bool save;
    public bool load;
    public int textureScale;

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.S))
            save = true;
        if (Input.GetKeyDown(KeyCode.L))
            load = true;
        
        if(save){
            string[] dir = Directory.GetDirectories(Application.dataPath);
            bool makeNewDirectory = true;
            foreach(string s in dir){
                if (s.Contains("WallTextures"))
                    makeNewDirectory = false;
            }
            if(makeNewDirectory){
                Directory.CreateDirectory(Application.dataPath + "/WallTextures");
            }
            dir = Directory.GetDirectories(Application.dataPath + "/WallTextures");

            Directory.CreateDirectory(Application.dataPath + "/WallTextures/" + (dir.Length+1).ToString() );

            SaveWallTextures(Application.dataPath + "/WallTextures/" + (dir.Length + 1).ToString() + "/");
            print(Application.dataPath + "/WallTextures/" + (dir.Length + 1).ToString() + "/");
            save = false;
        }
        if(load){
            string[] dir = Directory.GetDirectories(Application.dataPath + "/WallTextures");
            LoadWallTextures(Application.dataPath + "/WallTextures/" + (dir.Length).ToString() + "/");
            load = false;
        }
	}

    void SaveWallTextures(string location){
        for (int i = 0; i < wallParent.transform.childCount; i++)
        {
            Transform wall = wallParent.transform.GetChild(i);
            Vector3 initPosition = wall.position;
            Quaternion initRotation = wall.rotation;
            Vector3 initScale = wall.localScale;

            wall.position = Vector3.zero;
            wall.rotation = Quaternion.identity;
            Vector3 scale = new Vector3(1 / wallParent.transform.localScale.x, 1 / wallParent.transform.localScale.y, 1 / wallParent.transform.localScale.z);
            wall.localScale = scale;

            snapshotCam.Render();
            SaveTexture(i, location);

            wall.position = initPosition;
            wall.rotation = initRotation;
            wall.localScale = initScale;

        }
    }

    void LoadWallTextures(string location)
    {
        for (int i = 0; i < wallParent.transform.childCount; i++)
        {
            Transform wall = wallParent.transform.GetChild(i);
            Texture2D texture = LoadPNG(location + "wall" + i.ToString("0000") + ".png");
            wall.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
        }
    }

    public void SaveTexture(int frame, string location)
    {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        System.IO.File.WriteAllBytes(location+"wall"+frame.ToString("0000")+".png", bytes);
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(textureScale, textureScale, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }
        return tex;
    }
}
