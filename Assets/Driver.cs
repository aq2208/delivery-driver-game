using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turningSpeed = 300f;
    [SerializeField] float movingSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    // Start is called before the first frame update
    // Start() will be called when we click the "Play" button in Unity
    void Start()
    {
        Debug.Log("delaTime: " + Time.deltaTime);
    }

    // Update is called once per frame
    // Update() is called in every frame in our running game (we have a lot of frames in a single second)
    void Update()
    {
        //Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
        //Debug.Log("Vertical: " + Input.GetAxis("Vertical"));

        float turningAmount = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        float movingAmount = Input.GetAxis("Vertical") * movingSpeed * Time.deltaTime;

        //transform class (move the GameObject)
        transform.Rotate(0, 0, -turningAmount);
        transform.Translate(0, movingAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("SpeedUp"))
        {
            Debug.Log("Moving Up!");
            movingSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("SlowDown"))
        {
            Debug.Log("Moving Up!");
            movingSpeed = slowSpeed;
        }
    }
}
