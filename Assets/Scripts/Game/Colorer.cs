using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorer : MonoBehaviour
{
    public void ColorObject(GameObject pouringObject, int startPixel, int intencity = 0)
    {
        SpriteRenderer spriteRenderer = pouringObject.GetComponent<SpriteRenderer>();
        Texture2D newTexture = new Texture2D(spriteRenderer.sprite.texture.width, spriteRenderer.sprite.texture.height, TextureFormat.ARGB32, false);
        for (int x = startPixel; x > 0; x--)
        {
            if (x < startPixel - intencity)
            {
                break;
            }
            for (int y = startPixel; y > 0; y--)
            {
                if(intencity != 0)
                {
                    if(y < startPixel - intencity)
                    {
                        break;
                    }
                    Color color = spriteRenderer.sprite.texture.GetPixel(x, y);
                    if(color.a != 0)
                    {
                        newTexture.SetPixel(x, y, SingletoneVars.CurrentColor);
                    }
                }

            }
        }
    }


}
