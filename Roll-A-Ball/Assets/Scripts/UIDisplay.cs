using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text displayText;
    private int count;
    private bool reverse;
    public Color upColor;

    void Start()
    {
        displayText.text = "Moshi moshi!";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reverse == false)
        {
            count = count + 1;
            displayText.text = "Count = " + count;
        }
        else
        {
            count = count - 1;
            //count -= 1;
            //count--;
            //these lines do the same thing
            displayText.text = "Count = " + count;
        }


        if(count >= 1000)
        {
            reverse = true;
            displayText.color = Color.blue;
        }
        else if (count <= 0)
        {
            reverse = false;
            displayText.color = upColor;

          
        }
    }
}
