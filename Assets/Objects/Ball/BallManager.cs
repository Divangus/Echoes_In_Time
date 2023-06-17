using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallManager : MonoBehaviour
{
    public Rigidbody2D ball;
    public float _ballSpeed;
    Vector2 GetBallPos;
    Vector2 GetMousePos;
    float _angle;
    bool _ShootedBall;

    // Start is called before the first frame update
    void Start()
    {
        _ShootedBall = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider == gameObject.GetComponent<Collider2D>())
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetBallPos = gameObject.transform.position;
            }
        }

        if (Input.GetMouseButton(0))
        {
            GetMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculatePos();
        }

        if (Input.GetKeyDown(KeyCode.Space) && _ShootedBall == false)
        {
            Rigidbody2D clone_ball = Instantiate(ball, transform.position, transform.rotation) as Rigidbody2D;

            clone_ball.velocity = transform.up * _ballSpeed * Time.deltaTime;
            _ShootedBall = true;
        }
    }

    void CalculatePos()
    {
        Vector2 FinalDir = GetMousePos - GetBallPos;

        _angle = Mathf.Atan2(FinalDir.x, FinalDir.y) * 180 / Mathf.PI;


        int resolvedAngle = ((int)_angle) / (int)22.5;

        

        transform.rotation = Quaternion.AngleAxis(resolvedAngle * 22.5f, Vector3.back);
    }
}
