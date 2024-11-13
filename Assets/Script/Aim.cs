using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera Cam;
    Vector2 mousePosition;
    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
        mousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 pointingDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg; //- 90f; comente esto ya que si no el mouse no enfoca bien donde estoy.
        rb.rotation = angle;
    }
}
