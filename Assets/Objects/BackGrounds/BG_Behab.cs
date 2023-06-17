using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Behab : MonoBehaviour
{
    public Vector2[] path;
    private Rigidbody2D trail;
    private int currentStep = 1;
    private Vector2 reachPos;
    private bool changePos = true;

    private SpriteRenderer llum;

    private float angle = 0.0f;
    private int vel = 35;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        llum = transform.Find("light").gameObject.GetComponent<SpriteRenderer>();
        trail = transform.Find("trail").GetComponent<Rigidbody2D>();
        trail.position = path[0];
    }

    // Update is called once per frame
    void Update()
    {
        llum.color = new Color(255, 255, 255, 0.4f - Mathf.Sin(angle * Mathf.PI / 180.0f) * 0.35f);
        angle += Time.deltaTime * vel;

        if (angle > 180.0f)
        {
            angle -= 180.0f;
            vel = Random.Range(20, 35);
        }

        //Next Point
        CheckPathChange();

        //Change Velocity
        CheckVelocityChange();      
    }

    void CheckPathChange()
    {
        float distance = (reachPos - trail.position).magnitude;
        //Debug.Log("ReachPos: " + reachPos + "\nDistance: " + distance + "\nPos: " + trail.position);
        if (distance < 0.2)
        {
            changePos = true;
            if (currentStep != (path.Length - 1))
            {
                trail.position = path[currentStep];
                currentStep++;
            }
            else
            {
                currentStep = 1;
                trail.position = path[0];
            }
        }
    }

    void CheckVelocityChange()
    {
        if (changePos)
        {
            reachPos = path[currentStep];
            trail.velocity = (reachPos - trail.position).normalized * Random.Range(3.0f, 6.0f);

            changePos = false;
        }
    }
}