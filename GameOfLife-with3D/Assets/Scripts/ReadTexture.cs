using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadTexture : MonoBehaviour {


    byte[] ReadImgFile(string path){
        FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(file);
        byte[] values =  bin.ReadBytes((int)bin.BaseStream.Length);
        bin.Close();
        return values;
    }

    Texture2D TransGrayscale(string path,int width,int height){
        byte[] img = ReadImgFile(path);
        Texture2D iTexture = new Texture2D(width, height);
        iTexture.LoadImage(img);
        Color[] iColors = iTexture.GetPixels();
        Color[] oColors = new Color[width * height];
        for (int y = 0; y < iTexture.height;y++){
            for (int x = 0;x < iTexture.width;x++){
                var color = iColors[y * width + x];
                float average = (color.r + color.g + color.b) / 3;
                oColors[y * width + x] = new Color(average, average, average);
            }
        }
        Texture2D oTexture = new Texture2D(width,height);
        oTexture.SetPixels(oColors);
        oTexture.Apply();
        return oTexture;
    }

}
