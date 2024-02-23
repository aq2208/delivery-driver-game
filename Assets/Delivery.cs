using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    [SerializeField] float destroyDelay = 0.5f;

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    //variable to store the Sprite Renderer component of the GameObject
    SpriteRenderer spriteRenderer;

    void Start()
    {
        //get the Sprite Renderer of the GameObject at the Start()
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    // Define the behaviour of an object when it bump into another object (collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Car accident!!!");
    }

    //Define the package picked up and package delivered process
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (the thing we trigger is the package) -> print "Package picked up!"
        if (collision.gameObject.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;

            //change color of the car when it picked up the package
            spriteRenderer.color = hasPackageColor;

            //destroy the package after picked it up
            Destroy(collision.gameObject, destroyDelay);
        }

        // if (the thing we trigger is the customer) -> print "Delivered package!"
        if (collision.gameObject.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package!");
            hasPackage = false;

            //change color of the car when it delivered the package
            spriteRenderer.color = noPackageColor;
        }

    }
}
