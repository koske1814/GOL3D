using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ping画像のグレイスケールTextureを作成する。
/// 
/// </summary>
public class GetTexture : MonoBehaviour {
    private static byte[] GetBinaryImage(string path)
    {
        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            BinaryReader bin = new BinaryReader(fileStream);
            byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);
            bin.Close();
            return values;
        }
    }

    public static Texture2D GetGrayTexture(string path)
    {
        byte[] readBinary = GetBinaryImage(path);
        int pos = 16;
        int width = 0;
        for(int i = 0; i < 4; i++)
        {
            width = width * 256 + readBinary[pos++];
        }
        int height = 0;
        for(int i = 0; i < 4; i++)
        {
            height = height * 256 + readBinary[pos++];
        }
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);
        Color[] iColors = texture.GetPixels();
        Color[] oColors = new Color[width * height];
        for (int y = 0; y < texture.height;y++){
            for (int x = 0;x < texture.width;x++){
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
