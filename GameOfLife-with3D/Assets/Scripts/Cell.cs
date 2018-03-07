using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    Transform cellPower;
    public Cell(float pow)
    {
        GameObject obj = new GameObject();
        cellPower = obj.GetComponent<Transform>();
        cellPower.localScale = new Vector3(1, pow, 1);
    }
}
