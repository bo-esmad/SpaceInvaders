using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInvaders : MonoBehaviour
{

    [SerializeField]
    float velocity = 0.1f;

    Vector3 direction = Vector3.right;

    [SerializeField]
    float minX = -0.7f;
    [SerializeField]
    float maxX = 0.7f;

    [SerializeField]
    float timeToMove = 1f;

    float passedTime = 0f;

    bool shouldGoDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        if(shouldGoDown)
        {
            transform.position += velocity * Vector3.down;
            shouldGoDown = false;
        }

        if(passedTime >= timeToMove)
        {
            transform.position += direction * velocity;
            passedTime = 0;
            if(transform.position.x <= minX || transform.position.x >= maxX)
            {
                direction *= -1f;
                shouldGoDown = true;
            }
        }
    }
}
