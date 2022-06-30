using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
    [SerializeField] private GameObject brushPointPref;
    [SerializeField] private GameObject eraserPointPref;
    //
    private Colorer _colorer;

    private void Start()
    {
        _colorer = GetComponent<Colorer>();
    }

    private void Update()
    {
        switch (SingletoneVars.CurrentColoringType)
        {
            case ColoringType.Pouring:
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject pouringObject = CheckRaycastObject(Input.mousePosition);
                    if(pouringObject != null)
                    {
                        //_colorer.ColorObject
                    }
                }
                break;
        }
        if (Input.GetMouseButton(0))
        {
            if (SingletoneVars.CurrentColoringType == ColoringType.Pouring)
            {
                RaycastPouring(Input.mousePosition);
            }
            else if(SingletoneVars.CurrentColoringType == ColoringType.Brush)
            {
                if (Input.GetMouseButton(0))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
                    if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
                    {
                        GameObject newBrushPoint = Instantiate(brushPointPref);
                        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        newBrushPoint.transform.position = new Vector3(tapPoint.x, tapPoint.y, -1);
                        //newBrushPoint.transform.SetParent(transform, true);
                        newBrushPoint.GetComponent<SpriteRenderer>().color = SingletoneVars.CurrentColor;
                    }
                }
            }
            else if(!SingletoneVars.EraserSpawned)
            {
                if (Input.GetMouseButton(0))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
                    if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
                    {
                        GameObject newBrushPoint = Instantiate(eraserPointPref);
                        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        newBrushPoint.transform.position = new Vector3(tapPoint.x, tapPoint.y, 0);
                        SingletoneVars.EraserSpawned = true;
                    }
                }
            }
        }
    }

    private GameObject CheckRaycastObject(Vector2 tapPoint)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(tapPoint);
        Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
        if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    private void RaycastPouring(Vector2 tapPoint)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(tapPoint);
        Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
        if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
        {
            //hit.collider.gameObject.GetComponent<SpriteRenderer>().color = SingletoneVars.CurrentColor;
            SpriteRenderer spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            Texture2D texture = spriteRenderer.sprite.texture;
            Texture2D newTexture = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);
            Debug.Log("textureModernising");
            for (int x = 1; x <= texture.width; x++)
            {
                for(int y = 1; y <= texture.height; y++)
                {
                    Color color = texture.GetPixel(x, y);
                    if (color.a != 0)
                    {
                        if (color != Color.black)
                            newTexture.SetPixel(x, y, SingletoneVars.CurrentColor);
                        else
                            newTexture.SetPixel(x, y, Color.black);
                    }
                    else
                        newTexture.SetPixel(x, y, new Color(0, 0, 0, 0));
                }
            }
            newTexture.Apply(false);
            spriteRenderer.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f), 100);
            //spriteRenderer.material.SetTexture("newTexture", newTexture);
            /*Debug.Log("spriteCreating");
            spriteRenderer.material.SetTexture("newTexture", texture);
            spriteRenderer.sprite = Sprite.Create(texture, spriteRenderer.sprite.rect, spriteRenderer.sprite.pivot);
            Debug.Log("spriteCreated");*/
        }
    }
}
