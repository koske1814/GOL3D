using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell{
    Transform cellPower;
    Material color;
    public GameObject cell;
    public Cell(float pow){
        GameObject obj = new GameObject();
        cellPower = obj.GetComponent<Transform>();
        cellPower.localScale = new Vector3(0, pow, 0);
        color = obj.GetComponent<Material>();
        color.color = new Color(pow, pow, pow);
    }
}

public class CellCloud : MonoBehaviour {
    public Cell[] cells;
    public void MakeCells(Texture2D texture, int width, int height){
        cells = new Cell[width * height];
        Color[] colors = texture.GetPixels();
        for (int i = 0; i < width * height;i++){
            cells[i] = new Cell(colors[i].r);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
