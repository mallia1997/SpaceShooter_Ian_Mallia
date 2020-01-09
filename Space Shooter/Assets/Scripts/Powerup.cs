using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType
{
    TripleShot,
    Speed,
    Shield
}

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private PowerupType _powerupType;

    // Update is called once per frame
    void Update()
    {
        // move down at 3m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // when we leave the screen, destroy us
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }

    // on trigger enter
    void OnTriggerEnter2D(Collider2D other)
    {
        // if I hit the player
        if (other.tag == "Player")
        {
            // tell the player to activate the triple shot
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                switch (_powerupType)
                {
                    case PowerupType.TripleShot:
                        player.ActivateTripleShot();
                        break;

                    case PowerupType.Speed:
                        player.ActivateSpeed();
                        break;

                    case PowerupType.Shield:
                        player.ActivateShield();
                        break;
                }
            }

            // destroy us
            Destroy(this.gameObject);
        }
    }
}
