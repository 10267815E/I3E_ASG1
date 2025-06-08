using UnityEngine;

public class test : MonoBehaviour
{
    

string numberString = "";
int smallInt = 3;
int bigInt = 9;

int count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int a = 1; a <= 10; a++)
        {
            numberString += a + " ";

        }
        Debug.Log(numberString);

        while (smallInt <= bigInt)
        {
            smallInt ++;
            count++;
            Debug.Log(smallInt);

            
        }
        Debug.Log("Number of increments: " + count);

          
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
