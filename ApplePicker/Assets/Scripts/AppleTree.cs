using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2);
    }

    void DropApple() { 
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveRandomly();
    }

    void MoveRandomly()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        if (pos.x < -leftAndRightEdge || pos.x > leftAndRightEdge)
        {
            ChangeDirection();
        }
        else
        {
            transform.position = pos;
        }

        if (Random.value < chanceToChangeDirections)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        speed *= -1;
    }
}
