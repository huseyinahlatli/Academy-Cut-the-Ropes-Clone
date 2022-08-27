using System;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hook;
    [SerializeField] private GameObject linkPrefab;
    [SerializeField] private int links = 7;

    public Weight weight; 
    
    private void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody2D previousRigidbody = hook;
        
        for (int i = 1; i <= links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D hingeJoint = link.GetComponent<HingeJoint2D>();
            hingeJoint.connectedBody = previousRigidbody;

            if (i < links)
            {
                previousRigidbody = link.GetComponent<Rigidbody2D>();
                previousRigidbody.name = "Link " + i;
            }
            else
            {
                link.gameObject.name = "Link " + i;
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }
}
