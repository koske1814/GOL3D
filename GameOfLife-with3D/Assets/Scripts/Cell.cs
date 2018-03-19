using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    //セルが持つ大きさ(高さ)
    public float Value { get { return transform.localScale.y; }}

    public float Transition(Cell[,] cells,int y,int x){
        float size = this.Value;
        Vector2 count = 
            IsCompareBackNeighbor(cells, y - 1, x - 1)  +
            IsCompareBackNeighbor(cells, y - 1, x)      +
            IsCompareBackNeighbor(cells, y - 1, x + 1)  +
            IsCompareBackNeighbor(cells, y, x - 1)      +
            IsCompareBackNeighbor(cells, y, x + 1)      +
            IsCompareBackNeighbor(cells, y + 1, x - 1)  +
            IsCompareBackNeighbor(cells, y + 1, x)      +
            IsCompareBackNeighbor(cells, y + 1, x + 1);
        if ( Mathf.FloorToInt(count.x) == 3) size++;
        else if (Mathf.FloorToInt(count.x) != 2) size--;
        if (Mathf.FloorToInt(count.y) == 3) size--;
        else if (Mathf.FloorToInt(count.y) != 2) size++;
        return size;
    }
    //セルの初期化
    public void SetCell(Cell[,] cells,float size){
        if (size < 0 || size > 255f) return;
        SetScale(Mathf.Floor(size));
    }

    private void SetColor(Color color){
        GetComponent<Renderer>().material.color = color;
    }
    //セルの高さ(テクスチャのカラーの値)とそれによるpositionのy軸の位置調整
    private void SetScale(float size){
        this.transform.localScale = new Vector3(1, size, 1);
        this.transform.position = new Vector3(this.transform.position.x, size * 2, this.transform.position.z);
    }

    //周囲のセルと自分のセルのそれぞれの高さを比較し、自分が大きければ1,小さければ0を返す
    private Vector2 IsCompareBackNeighbor(Cell[,] cells,int y,int x){
        bool isOutRange = x < 0 || x >= cells.GetLength(1) | y < 0 || y >= cells.GetLength(0);
        if(!isOutRange){
            if (Mathf.FloorToInt(Value) < Mathf.FloorToInt(cells[y, x].Value)) return new Vector2(1, 0);
            if (Mathf.FloorToInt(Value) > Mathf.FloorToInt(cells[y, x].Value)) return new Vector2(0, 1);
        }

        return new Vector2();
    }
}
