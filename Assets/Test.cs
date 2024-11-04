using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    public GameObject Thing1;
    public GameObject Thing2;
    
    

    public void OnDrawGizmos()
    {
        
        Vector3 Direction = (Thing2.transform.position - Thing1.transform.position);//Find out what's direction after subtraction

        Thing2.transform.forward = Direction;// making my thing2 giving direction to look at
        float Distance = Direction.magnitude; 

        if (Distance > 6)
        {
            Gizmos.color = Color.green;
        }
        else 
        {
            Gizmos.color = Color.red;
            
        }
        Gizmos.DrawLine(Thing2.transform.position, (Thing1.transform.position));
        //Draws a line at Thing2 position to whatever this script is attached to, but I made it an object instead 
    }
}
