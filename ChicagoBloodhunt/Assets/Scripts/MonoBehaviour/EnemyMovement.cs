using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.5f;
    //public float speedAmp;
    //bool charge;
    [SerializeField] private Vector3[] positions;
    private int i;
    [SerializeField] bool isEnemyRight;


    void Update()
    {
        Flip();
        //Enemy walks towards set position
        transform.position = Vector2.MoveTowards(transform.position, positions[i], Time.deltaTime * speed);
        if (transform.position == positions[i])
        {
            if (i == positions.Length - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
        //Enemy charges towards the player if player is in sight range

    }
    void Flip()
    {
        if (i == positions.Length - 1)
        {
            if (!isEnemyRight)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isEnemyRight = true;
            }
        }
        else
        {
            if (isEnemyRight)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isEnemyRight = false;
            }
        }
    }
}
