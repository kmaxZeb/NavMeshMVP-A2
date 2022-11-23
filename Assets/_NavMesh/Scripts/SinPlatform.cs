using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinPlatform : MovingPlatform
{
    float currentX = 0;
    
    protected override Vector3 NextMove(float t)
    {
        //TBA
        //Vector3 newPosition = Vector3.Lerp(_startPosition, _endPosition, t);
        //currentX += Mathf.Sin(Time.time)

        return Vector3.Slerp(_startPosition, _endPosition, t);
    }
}