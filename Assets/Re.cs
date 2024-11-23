using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Re : MonoBehaviour
{

    [Header("Ray settings")]
    public float rayDistance = 200.0f;
    public int numReflection = 5;
    private Vector3 startPostion;
    private Vector3 startDirection;

    private Vector3 endPostion;

    [Header("Gizmos Customization")]
    public Color miss = Color.red;
    public Color collision = Color.yellow;
    public Color rayHit = Color.green;
    public float collisionRadius = 0.05f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        //declaring to save for later
        RaycastHit hit;

        //setting initial conditions
        startPostion = transform.position;
        startDirection = transform.up;

        for (int i = 0; i < numReflection; i++)
        {
            //casting ray from our start position, ion the start direction, for a distance of rayDistance
            if (Physics.Raycast(startPostion, startDirection, out hit, rayDistance))
            {
                endPostion = hit.point;

                //draw line to hit
                Gizmos.color = rayHit;
                Gizmos.DrawLine(startPostion, endPostion);

                //draw line at collision point
                Gizmos.color = collision;
                Gizmos.DrawSphere(endPostion, collisionRadius);

                //set the results of the raycast as the new starting conditions
                startPostion = endPostion;
                //get reflection using vector.reflect by getting in the perpindicular of surface, and starting direction of ray
                startDirection = Vector3.Reflect(startDirection, hit.normal); 
            }
            else
            {
                //if no collision with object, show ray as red in maximum length
                Gizmos.color = miss;
                Gizmos.DrawLine(startPostion, startPostion + startDirection.normalized * rayDistance);
            }
        }
         
        /*
        if (Physics.Raycast(transform.position, transform.up, out hit, 200.0f))
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(transform.position, hit.point);

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(hit.point, 0.05f);
            Vector3 refectedhit = Vector3.Reflect(transform.up, hit.normal);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(hit.point, hit.point + refectedhit * 300.0f);
            
        }
        else
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + transform.up * 2.0f);
        }
        */
    }
}
