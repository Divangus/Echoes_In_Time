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
    bool _ShootedBall;
    public bool _SelectedBall;
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
        //On click, select cannon
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == gameObject.GetComponentInParent<Collider2D>())
            {
                _SelectedBall = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _SelectedBall = false;
        }

        //Play Button
        if (Input.GetKeyDown(KeyCode.Space) && !_ShootedBall)
        {
            _timer.GetComponent<Slider_Animation>().playSlider = true;
        }

        //Shoot
        if (_timer.GetComponent<Slider_Animation>().playSlider == false && _timer.GetComponent<Slider_Animation>()._TimerOut == true && !_ShootedBall)
        {
            Instantiate(ball, transform.position, transform.rotation).velocity = transform.up * _ballSpeed;
            _ShootedBall = true;
        }
    }

    public void CalculatePos()
    {
        //Get mouse direction
        Vector2 FinalDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;

        //Get angle
        float _angle = Mathf.Atan2(FinalDir.x, FinalDir.y) * 180 / Mathf.PI;
        int resolvedAngle = ((int)_angle) / (int)22.5;

        //Rotate arrow
        transform.rotation = Quaternion.AngleAxis(resolvedAngle * 22.5f, Vector3.back);
    }
}
