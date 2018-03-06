using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellCloud : MonoBehaviour {
    public Cell[] cells { get; set; }
    public Transform[] pos { get; set; }
    public Texture2D texture { get; set; }
    [SerializeField]
    GameObject cellObj;
    [SerializeField]
    Transform cloud;
    public void MakeCell(Texture2D texture)
    {
        this.texture = texture;
        cells = new Cell[texture.width * texture.height];
        pos = new Transform[texture.width * texture.height];
        Color[] colors = texture.GetPixels();
        for(int i = 0; i< texture.width * texture.height; i++)
        {
            GameObject obj = (GameObject)Instantiate(cellObj);
            obj.transform.SetParent(cloud);
            pos[i] = obj.GetComponent<Transform>();
            pos[i].position = new Vector3(Mathf.Ceil(i / texture.width), 0, i % texture.width);
        }
    }
}
