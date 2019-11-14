﻿// Namespaces - libraries of pre-exisiting code.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour is a Unity class that allows us
// to attach scripts to GameObjects.
// The colon symbol means that Player inherits MonoBehaviour's code.
public class Player : MonoBehaviour
{
    // Variable - a box with information that can be changed.
    // step 1 - public or private
    // step 2 - data type (int, float, bool, string)
    // step 3 - every variable needs a name
    // step 4 - optional value

    // Attribute - exposes the variable inside Unity
    [Header("Player Option")]
    [SerializeField]
    private float _speed = 3.5f;

 
    [SerializeField]
    private float _fireRate = 0.5f;

    private float _nextFire = -1.0f;

    [SerializeField]

    private int _lives = 3;

    private SpawnManager _spawnManager;

    [Header("Laser")]
    [SerializeField]
    private GameObject _laserPrefab;

    [Header("Triple Shot")]
    [SerializeField]

    private GameObject _tripleShotPrefab;

     
    private bool _isTripleShotActive = false;

    [Header("Speed")]
    [SerializeField]
   
    private float _speedModifier = 2f;

    private bool _isSpeedActive = false;

    [Header("Shield")]
    [SerializeField]
    private GameObject _shieldVisualizer;

    private bool _isShieldActive = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
        Debug.LogError("the Spawn Manager script could not be found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        // if I hit the space key and the game time is greater than nextFire
        // reset next fire = current time + fire rate
        // spawn laser
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        // local variable - horizontalInput
        // read the keyboard input from the user
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");

        // Vector3.right = new Vector3(1, 0, 0)
        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        // more optimized version for the above
        Vector3 direction = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0
        );

        if(_isSpeedActive == true)
        {
            direction *= _speedModifier;
        }

        transform.Translate(direction * _speed * Time.deltaTime);

        // if the player position on the Y axis is > 0
        // y position = 0
        // else if the Y position < -4.5
        // y position = -4.5
        if (transform.position.y > 0)
        {
            transform.position
                = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.5f)
        {
            transform.position
                = new Vector3(transform.position.x, -4.5f, 0);
        }

        // if X position is > 11.5
        // X position = -11.5
        // else if X position < -11.5
        // X position = 11.5
        if (transform.position.x > 11.5f)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.5f)
        {
            transform.position = new Vector3(11.5f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _nextFire = Time.time + _fireRate;

        // if triple shot is active
        // instantiate the triple shot prefb
        // else fire 1 laser

        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }

        else
        {

        // Calculate 0.8 units vertically from the player
        Vector3 laserPos = transform.position + new Vector3(0, 0.8f, 0);

        // Quaternion.identity = default rotation (0, 0, 0).
        Instantiate(_laserPrefab, laserPos, Quaternion.identity);
        }
    }

    public void Damage()
    {
        // if the shield power up is active
        //turn off the shield visualizer
        //shield power up  = false
        //stop the function from continuing

        if (_isShieldActive == true)
        {
            _shieldVisualizer.SetActive(false);
            _isShieldActive = false;
            return;
        }
        //reduce players lives by 1
        _lives -= 1;
        //check if dead
        //destroy us
        if (_lives < 1)
        {
           //Communicate with the spawn manager
           _spawnManager.OnPlayerDeath();

            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotDownRoutine());
    }

    public void ActivateShield()
    {
        _isShieldActive = true;
        _shieldVisualizer.SetActive(true);
    }
    public void ActivateSpeed()
    {
        _isSpeedActive = true;
        StartCoroutine(SpeedPowerDownRoutine());

    }

    IEnumerator TripleShotDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _isTripleShotActive = false;
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _isSpeedActive = false;
    }
}
