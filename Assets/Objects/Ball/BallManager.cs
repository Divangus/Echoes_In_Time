using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallManager : MonoBehaviour
{

    public bool onHovered;
    Vector2 GetBallPos;
    Vector2 GetMousePos;
    float _angle;

    // Start is called before the first frame update
    void Start()
    {

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * 3;
        }
    }

    void CalculatePos()
    {
        Vector2 FinalDir = GetMousePos - GetBallPos;

        _angle = Mathf.Atan2(FinalDir.x, FinalDir.y) * 180 / Mathf.PI;


        int resolvedAngle = ((int)_angle) / (int)22.5;
        Debug.Log(resolvedAngle * 22.5f + 11.25f);

        transform.rotation = Quaternion.AngleAxis(resolvedAngle * 22.5f + 11.25f, Vector3.back);
    }
}
