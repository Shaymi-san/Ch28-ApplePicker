using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    void Update()
    {
        Vector3 pos = transform.position; //Basic Movement
        pos.x += speed * Time.deltaTime;
        transform.position = pos; //Changing Direction
        if(pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); //Moves right
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Moves left
        }

    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //Change direction
        }
    }
    }
