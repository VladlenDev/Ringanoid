using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingFigure : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    private Vector2 currentDirection = new Vector3(0.0f, 1.0f, 0.0f);
    private Transform transformObject;

    void Start()
    {
        transformObject = this.transform;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = transformObject.position;

        Vector2 direction = mousePos - objectPos;
        direction.Normalize();

        currentDirection = Vector2.Lerp(currentDirection, direction, Time.deltaTime * speed);
        transformObject.up = currentDirection;
    }
}
