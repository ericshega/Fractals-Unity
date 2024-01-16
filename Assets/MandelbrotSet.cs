using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MandelbrotSet : MonoBehaviour
{
    public int textureWidth;
    public int textureHeight;

    public float zoom;
    public float offsetX;
    public float offsetY;

    public static float maxIterations;

    private Texture2D texture;

    void Start()
    {
        textureWidth = 800;
        textureHeight = 600;
        zoom = 5f;
        offsetX = -2.5f;
        offsetY = -2.5f;
        
        InitializeTexture();
        GenerateMandelbrotSet();
        UpdateTexture();
    }

    public void IncreseIterations()
    {
        maxIterations += 2.5f;
        SceneManager.LoadScene("Fractals");
    }

    public void DecreaseIterations()
    {
        maxIterations -= 2.5f;
        SceneManager.LoadScene("Fractals");
    }

    void InitializeTexture()
    {
        texture = new Texture2D(textureWidth, textureHeight);
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    void GenerateMandelbrotSet()
    {
        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                float a = offsetX + (float)x / textureWidth * zoom;
                float b = offsetY + (float)y / textureHeight * zoom;

                float ca = a;
                float cb = b;

                int iterations = 0;
                while (iterations < maxIterations)
                {
                    float aa = a * a - b * b;
                    float twoab = 2 * a * b;

                    a = aa + ca;
                    b = twoab + cb;

                    if (Mathf.Abs(a + b) > 16)
                        break;

                    iterations++;
                }

                Color color = Color.Lerp(Color.black, Color.white, (float)iterations / maxIterations);
                texture.SetPixel(x, y, color);
            }
        }
    }

    void UpdateTexture()
    {
        texture.Apply();
    }
}
