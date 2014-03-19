using UnityEngine;
using System.Collections;

public class GUI2
{
    static public Rect GUI3D(Camera camera, Vector3 pos, float width = 100, float height = 25)
    {
        Vector2 point = camera.WorldToScreenPoint(pos);

        Rect rect = new Rect(point.x, (Screen.height - point.y), width, height);

        return rect;
    }
}
