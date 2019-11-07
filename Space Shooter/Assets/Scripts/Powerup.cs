using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float _speed = 3f;
    // Update is called once per frame
    void Update()
   
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // move down at 3m/s
        //when we leave the screen, destroy us

         if (transform.position.y <-8f)
         {
             Destroy(this.gameObject);
         }
    }

    //on trigger enter
    //if I hit the player
    //Destroy us
    // tell the player to activate the triple shot
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.ActivateTripleShot();
            }
             Destroy(this.gameObject);
        }
    }

}
