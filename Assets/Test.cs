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
        
        Vector3 LeftOver = (Thing2.transform.position - Thing1.transform.position);//Find out what's leftOver after subtraction

        Thing2.transform.forward = LeftOver; //Using what's left over from that

        

        if (LeftOver.sqrMagnitude < 5)
        {            
            //Debug.Log("In range");
            Gizmos.color = Color.green;

        }

        else 
        {
            //Debug.Log("Out of range");
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(Thing2.transform.position, (Thing1.transform.position));
        //Draws a line at Thing2 position to whatever this script is attached to, but I made it an object instead 
    }
}
