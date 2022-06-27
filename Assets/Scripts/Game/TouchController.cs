using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
    [SerializeField] private GameObject brushPointPref;
    [SerializeField] private GameObject eraserPointPref;
    //
    public delegate void OnTouch(Vector2 touchPos);
    public static event OnTouch onTouch;

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            if (SingletoneVars.CurrentColoringType == ColoringType.Pouring)
            {
                foreach (var touch in Input.touches)
                {
                    RaycastPouring(touch.position);
                }
                if (Input.GetMouseButtonDown(0))//TODO: убрать, эта чать для тестов на пк
                {
                    RaycastPouring(Input.mousePosition);
                }
            }
            else if(SingletoneVars.CurrentColoringType == ColoringType.Brush)
            {
                foreach (var touch in Input.touches)
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
                    if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
                    {
                        GameObject newBrushPoint = Instantiate(brushPointPref);
                        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        newBrushPoint.transform.position = new Vector3(tapPoint.x, tapPoint.y, 0);
                        //newBrushPoint.transform.SetParent(transform, true);
                        newBrushPoint.GetComponent<SpriteRenderer>().color = SingletoneVars.CurrentColor;
                    }
                }
                
                //TODO: убрать, эта часть для теста на пк
                if (Input.GetMouseButton(0))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
                    if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
                    {
                        GameObject newBrushPoint = Instantiate(brushPointPref);
                        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        newBrushPoint.transform.position = new Vector3(tapPoint.x, tapPoint.y, 0);
                        //newBrushPoint.transform.SetParent(transform, true);
                        newBrushPoint.GetComponent<SpriteRenderer>().color = SingletoneVars.CurrentColor;
                    }
                }
            }
            else
            {
                foreach (var touch in Input.touches)
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
                    if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
                    {
                        GameObject newBrushPoint = Instantiate(eraserPointPref);
                        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        newBrushPoint.transform.position = new Vector3(tapPoint.x, tapPoint.y, 0);
                    }
                }
            }
        }
    }

    private void RaycastPouring(Vector2 tapPoint)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(tapPoint);
        Vector3 targerPos = new Vector3(mousePosition.x, mousePosition.y, 1000);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, targerPos);
        if (hit.collider != null && !hit.collider.gameObject.name.Contains("BlockingCanvas"))
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = SingletoneVars.CurrentColor;
        }
    }
}
