using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private Player _player;

    private Animator _animator;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("There is no Animator on the Enemy.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy down at 4 units per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        // if the position on Y is at the bottom of the screen
        // move to the top
        if (transform.position.y < -6.5f)
        {
            // generate a random number between -8.5 and 8.5
            float x = Random.Range(-8.5f, 8.5f);
            transform.position = new Vector3(x, 6.5f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if the "other" object's tag is Player
        // Damage the player
        // Destroy this gameobject
        if (other.tag == "Player")
        {
            // Create a reference to the player script
            // Accesses the player script through the "other" variable
            Player player = other.GetComponent<Player>();

            // Check that the script exists before using it.
            if (player != null)
            {
                player.Damage();
            }

            EnemyDeath();
        }

        // if the "other" object's tag is Laser
        // Destroy the laser
        // Destroy this gameobject
        if (other.tag == "Laser")
        {
            _player.AddScore();

            Destroy(other.gameObject);
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        _animator.SetTrigger("OnEnemyDeath");
        _speed = 0;
        
        Destroy(this.gameObject, 2.633f);
    }
}
