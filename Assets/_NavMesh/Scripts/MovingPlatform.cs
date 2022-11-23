using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] protected Vector3 _startPosition;
    [SerializeField] protected Vector3 _endPosition;

    [Range(0f,1f)]
    [SerializeField] protected float _t;
    [SerializeField] protected float _speed = 0.5f;
    protected bool _forward = true;

    [SerializeField] protected float _pauseDuration = 0.5f;
    protected float _pauseTime = float.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < _pauseTime + _pauseDuration)
        {
            return;
        }

        if (_forward)
        {
            _t += _speed * Time.deltaTime;
            _t = Mathf.Min(1, _t);
            if (_t >= 1)
            {
                _pauseTime = Time.time;
                _forward = false;
               
            }
        }
        else 
        {
            _t -= _speed * Time.deltaTime;
            _t = Mathf.Max(0, _t);
            if (_t <= 0)
                {
                _pauseTime = Time.time;
                _forward = true;
            }
        }
        transform.position = NextMove(_t);
    }

    protected virtual Vector3 NextMove(float t)
    {
        //5 = Mathf.Lerp(5, 10, 0);
        //6 = Mathf.Lerp(5, 10, 0.2);
        //7.5 = Mathf.Lerp(5, 10, 0.5);
        //10 = Mathf.Lerp(5, 10, 1);
        return Vector3.Lerp(_startPosition, _endPosition, t);
    }
}
