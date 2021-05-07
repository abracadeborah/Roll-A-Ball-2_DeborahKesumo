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
    private int pickupCount;
    public GameObject gameOverScreen;
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        displayText.color = welcomeColor;
        pickupCount = GameObject.FindGameObjectsWithTag("PickUp").Length;
        gameOverScreen.SetActive(false);

        resetPoint = GameObject.Find("Reset Point");
        originalColour = GetComponent<Renderer>().material.color;

    }

    
    void Update()
    {
        if (resetting)
            return;

        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        rb.AddForce(x, 0, z);

        if (score >= pickupCount)
        {
            gameOverScreen.SetActive(true);
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

    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPost = transform.position;
        float resetSpeed = 2f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPost, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColour;
        resetting = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag ("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }
    }

   
       
}
