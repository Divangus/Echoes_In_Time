using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<BallScript> _balls;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject ball in GameObject.FindGameObjectsWithTag("Cannon"))
        {
            _balls.Add(ball.transform.GetComponentInChildren<BallScript>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _balls.Count; i++)
        {
            if(_balls[i]._SelectedBall)
            {
                _balls[i].CalculatePos();
            }
        }
    }
}
