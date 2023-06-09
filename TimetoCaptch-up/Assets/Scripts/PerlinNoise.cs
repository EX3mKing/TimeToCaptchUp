using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PerlinNoise : MonoBehaviour
{
    public int width;
    public int height;
    public float scale = 20f;
    public float offsetY = 0f;
    public float offsetX = 0f;
    public float randomOffsetY = 300f;
    public float randomOffsetX = 300f;
    
    public Image image;

    private void Start()
    {
        TextureUpdate();
    }
    
    /*private void Update()
    {
        TextureUpdate();
    }*/
    public void TextureUpdate()
    {
        image.material.mainTexture = GenerateTexture();
        image.enabled = false;
        image.enabled = true;
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Color color = CalculateColor(i, j);
                texture.SetPixel(i,j,color);
            }
        }
        
        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    public void RandomizeOffset()
    {
        offsetX = Random.Range(-randomOffsetX, randomOffsetX);
        offsetY = Random.Range(-randomOffsetY, randomOffsetY);
    }
}