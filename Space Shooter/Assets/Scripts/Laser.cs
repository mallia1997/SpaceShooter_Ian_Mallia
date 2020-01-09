using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed variable of 8
    [SerializeField]
    private float _speed = 8f;

    // Update is called once per frame
    void Update()
    {
        // translate laser upwards
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // if the laser position on Y is greater than 7
        // Destory the object
        if (transform.position.y > 7f)
        {
            // destroy the parent object if there is one
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
