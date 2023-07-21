using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    [SerializeField] GameObject CartHolder;
    [SerializeField] Transform[] Positions;
    [SerializeField] [Range(1f, 10f)] float CartSpeed ;

    int NextPosIndex;
    Transform NextPos;

    void Start()
    {
        NextPos = Positions[0]; 
    }

   
    void Update()
    {
        MoveCart();

    }

    void MoveCart()
    {
        if(transform.position == NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];    
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, CartSpeed * Time.deltaTime);
            if (transform.position == NextPos.position)
            {
                Destroy(CartHolder);
            }
        }
    }
}
