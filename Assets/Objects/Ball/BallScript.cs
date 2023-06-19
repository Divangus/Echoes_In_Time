using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ball;
    public float _ballSpeed;
    Vector2 GetBallPos;
    Vector2 GetMousePos;
    float _angle;
    bool _ShootedBall;
    public bool _SelectedBall;
    public GameObject _BallManager;
    public Slider _timer;

    // Start is called before the first frame update
    void Start()
    {
        _ShootedBall = false;
        _SelectedBall = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider == gameObject.GetComponentInParent<Collider2D>())
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetBallPos = gameObject.transform.position;
                _SelectedBall = true;
                FindObjectOfType<BallManager>()._SelectedBall = this.gameObject;
            }
        }

        if (Input.GetMouseButton(0))
        {
            GetMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_ShootedBall)
        {
            _timer.GetComponent<Slider_Animation>().playSlider = true;
            
        }

        if (_timer.GetComponent<Slider_Animation>().playSlider == false && _timer.GetComponent<Slider_Animation>()._TimerOut == true && !_ShootedBall)
        {
            Rigidbody2D clone_ball = Instantiate(ball, transform.position, transform.rotation) as Rigidbody2D;

            _ShootedBall = true;

            clone_ball.velocity = transform.up * _ballSpeed;  
        }
    }

    public void CalculatePos()
    {
        Vector2 FinalDir = GetMousePos - GetBallPos;

        _angle = Mathf.Atan2(FinalDir.x, FinalDir.y) * 180 / Mathf.PI;


        int resolvedAngle = ((int)_angle) / (int)22.5;


        transform.rotation = Quaternion.AngleAxis(resolvedAngle * 22.5f, Vector3.back);

        //Debug.Log(transform.rotation);
    }
}
