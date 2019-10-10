// Namespaces - libraries of pre-exisiting code
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour is a Unity class that allows us
// to attach scripts to gameObjects
// the colon symbol means that player inherits monobehaviour's code
public class Player : MonoBehaviour
{
    // Vabriable - a box with information that can be changed.
    // step 1 - public player can change it or private player can t see or change it and must always have a _ infront the name
    // step 2 - data type (int :whole number, float :number with a point, bool :true and false, string : text)
    // step 3 - every vatiable needs a name
    // step 4 - optional value 

    // Attribute - exposes the variable inside Unity
    [SerializeField]

    private float _speed = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {

        // local varriable - horizontalInput
        // read the keyboard input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Vector3.right =new Vector (1,0,0)
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        
        // all the input can  be in one like below
        //Vector3 direction = new Vector3 (
            //Input.GetAxis ("Horizontal"),
            //Input.GetAxis ("Vertical"),
            //0
        //);
        //transform.Translate(direction * _speed * Time.deltaTime)

        // if the player position on the Y axis is > 0
        // y position = 0
        //else if the Y position <-4.5
        // y position = -4.5

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y <-4.5f)
        {
            transform.position = new Vector3(transform.position.x,-4.5f, 0);
        
        }
    
    // if x position is > 11
    // x position = -11.5
    // else if X position < -11.5
    // X position = 11.5
    }
}
