using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodbyeWorld : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerHealth = 100;
    float gameTime = 0.5f;
    string welcomeMessage = "Welcome to... Roll-A-Ball!!";
    bool playerDead = false;

    void Start()
    {
        if (playerHealth > 0)
        {
            print(welcomeMessage);
            playerDead = false;
        }
        else if (playerHealth == 0)
        {
            print("Ya dead");
        }
        else
        {
            print("Ya basic");
            playerDead = true;
        }

   
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void Objection()
    {
    
    }


}
