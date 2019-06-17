using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    public float jumpForce = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Time.deltaTime, v.y); //Je déplace Mario
        if (Input.GetKeyDown(KeyCode.Space)) // Si on appuie sur le bouton haut
        {
                // Faire sauter
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce); // J'ajoute une force unique pour le faire sauter 1 fois

        }
    }
}
