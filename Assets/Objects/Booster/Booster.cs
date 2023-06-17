using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 boosterDir;
    void Start()
    {
        boosterDir = transform.up;
    }

    // Update is called once per frame
    void Update()
    {        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, boosterDir);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 direction = transform.up;
            rb.AddForce(direction * 5f, ForceMode2D.Impulse);
        }
    }
}
