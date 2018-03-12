using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenItemBar : MonoBehaviour {
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    GameObject img;
    public void OnClick()
    {
        //GameObject obj = (GameObject)Instantiate(img);
        GameObject obj = new GameObject();
        obj.transform.SetParent(canvas.transform, false);
        Image image = obj.GetComponent<Image>();
        Texture2D texture = GetTexture.GetGrayTexture(Application.dataPath + "/Image/img.png");
        //image.material.mainTexture = texture;
        GetComponent<CellCloud>().MakeCell(texture);
        //        Debug.Log("width: " + texture.width + ", height: " + texture.height);
        GetComponent<LookCell>().LookCells(texture);

    }

}
