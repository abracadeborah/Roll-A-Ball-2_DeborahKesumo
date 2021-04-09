using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text displayText;
    public Color welcomeColor;
    public Color scoreColor;
    public Color winColor;
     
    public Rigidbody rb;
    public float jumpForce;
    public float moveSpeed;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        displayText.color = welcomeColor;

    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        rb.AddForce(x, 0, z);

        if (score >= 15)
        {
            
            displayText.text = "YOU ARE.. VICTORIOUS!";
            displayText.color = winColor;
        }

   
    }
     private void OnTriggerEnter(Collider otherObject)
    {
        
        if(otherObject.tag == "PickUp")
        {
            Destroy(otherObject.gameObject);
            score = score + 1;
            print("Score = " + score);
            // score += 1;
            // score++;
            // All three lines can be used to add 1 point to the score
            displayText.text = "SCORE: " + score;
            displayText.color = scoreColor;
        }
    }
}
