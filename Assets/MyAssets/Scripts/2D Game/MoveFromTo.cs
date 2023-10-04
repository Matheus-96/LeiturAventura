using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromTo : MonoBehaviour
{
    public Transform targetPosition;
    public float totalTime = 2.0f;
    public AnimationCurve easingCurve;

    private Vector3 startPosition;
    private float currentTime = 0f;
    private bool isGoingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float direction = isGoingForward ? 1f : -1f;

        currentTime += Time.deltaTime * direction;

        if (currentTime >= totalTime)
        {
            currentTime = totalTime;
            isGoingForward = false;
        }
        else if (currentTime <= 0)
        {
            currentTime = 0;
            isGoingForward = true;
        }

        float t = easingCurve.Evaluate(currentTime / totalTime);
        transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);
    }
}
