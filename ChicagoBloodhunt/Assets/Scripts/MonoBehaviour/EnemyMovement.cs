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
    [SerializeField]public bool isEnemyRight;


    void Update()
    {
        Flip();
        if (gameObject.GetComponent<EnemyActions>().isAgro)
        {
            FollowPlayer();
        }
        else
        {
            Roam();
        }
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
    void Roam()
    {
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
    }
    void FollowPlayer()
    {
        if(transform.position.x >= positions[1].x && transform.position.x <= positions[0].x)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(GameObject.Find("Player").transform.position.x, transform.position.y), Time.deltaTime * speed * 2);
        }
    }
}
