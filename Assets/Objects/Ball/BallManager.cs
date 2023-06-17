using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<GameObject> _balls;
    public GameObject _SelectedBall;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _balls.Count; i++)
        {
            if(_balls[i] == _SelectedBall)
            {
                _balls[i].GetComponent<BallScript>().CalculatePos();
            }
        }
    }
}
