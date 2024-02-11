using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Level_Controller : MonoBehaviour
{
    public SpriteShapeController SpriteShapecontroller;
    [Range(1f, 100f)] public int LevelLength = 50;
    [Range(1f, 50f)] public float XMultiplier = 2f;
    [Range(1f, 50f)] public float YMultiplier = 2f;
    [Range(0f, 1f)] public float curveSmoothness = 0.5f;
    public float noiseStep;
    public float bottom;

    public Vector3 lastPos;


    private void OnValidate()
    {
        SpriteShapecontroller.spline.Clear();

        for (int i = 0; i < LevelLength; i++)
        {
            lastPos = transform.position + new Vector3(i * XMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * YMultiplier);
            SpriteShapecontroller.spline.InsertPointAt(i, lastPos);

            if (i != 0 && i != LevelLength - 1)
            {
                SpriteShapecontroller.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                SpriteShapecontroller.spline.SetLeftTangent(i, Vector3.left * XMultiplier * curveSmoothness);
                SpriteShapecontroller.spline.SetRightTangent(i, Vector3.right * YMultiplier * curveSmoothness);
            }
        }
        SpriteShapecontroller.spline.InsertPointAt(LevelLength, new Vector3(lastPos.x, transform.position.y - bottom));
        SpriteShapecontroller.spline.InsertPointAt(LevelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));
       
    }
}
