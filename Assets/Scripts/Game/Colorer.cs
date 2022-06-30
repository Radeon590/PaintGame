using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorer : MonoBehaviour
{
    public void ColorObject(GameObject pouringObject, int startPixel_x, int startPixel_y, int intencity = 0)
    {
        SpriteRenderer spriteRenderer = pouringObject.GetComponent<SpriteRenderer>();
        Texture2D newTexture = new Texture2D(spriteRenderer.sprite.texture.width, spriteRenderer.sprite.texture.height, TextureFormat.ARGB32, false);
        Color startPixelColor = spriteRenderer.sprite.texture.GetPixel(startPixel_x, startPixel_y);
        if (startPixelColor == new Color(0, 0, 0, 0))
            return;
        for (int x = startPixel_x; x > 0; x--)
        {
            if (x < startPixel_x - intencity)
            {
                break;
            }
            for (int y = startPixel_y; y > 0; y--)
            {
                if(intencity != 0)
                {
                    if(y < startPixel_y - intencity)
                    {
                        break;
                    }
                }
                Color color = spriteRenderer.sprite.texture.GetPixel(x, y);
                if (color.a != 0)
                    newTexture.SetPixel(x, y, SingletoneVars.CurrentColor);
                else
                    newTexture.SetPixel(x, y, new Color(0, 0, 0, 0));
            }
        }
    }


}
