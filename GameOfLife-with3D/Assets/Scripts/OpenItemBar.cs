using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenItemBar : MonoBehaviour {
    public GameObject canvas;
    public GameObject img;
    public CellCloud cellCloud;
    public Camera mainCamera;
    public void OnClick()
    {
        //GameObject obj = (GameObject)Instantiate(img);
        GameObject obj = new GameObject();
        obj.transform.SetParent(canvas.transform, false);
        Image image = obj.GetComponent<Image>();
        Texture2D texture = GetTexture.GetGrayTexture(Application.dataPath + "/Image/img.png");
        //image.material.mainTexture = texture;
        cellCloud.MakeCell(texture);
        //        Debug.Log("width: " + texture.width + ", height: " + texture.height);
        mainCamera.GetComponent<LookCell>().LookCells(texture);

    }

    public delegate void TransHandler();
    public event TransHandler transHandler;

    public void TransStart(){
        transHandler += () => GetComponent<CellCloud>().Transition();
    }

	private void Update()
	{
        if(transHandler != null)
            transHandler();
	}
}
