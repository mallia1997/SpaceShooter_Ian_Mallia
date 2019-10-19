using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    private float _enemySpeed = 4.0f;
 

    // Update is called once per frame
    void Update()
    {
      // move  the enemy down at 4 units per second
      //if the position on Y is at the bottom of the screen
      //move to the top
        transform.Translate(Vector3.down * _enemySpeed *Time.deltaTime);

        if(transform.position.y < -6.5f)
        {
            // generate a random number between -8.5 and 8.5
            float x = Random.Range(-8.5f,8.5f);
            transform.position = new Vector3(x,6.5f,0);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if the "other" object's tag is player
        //Damage the player 
        //Destroy this game object
    
        if (other.gameObject.CompareTag("Player"))
        
            Destroy(other.gameObject);

        //if the "other" object's tag is laser
        //Destroy the laser
        //Destroy this gameobject
        
            if (other.gameObject.CompareTag("Laser"))
        
            Destroy(other.gameObject);
    

    }
}
