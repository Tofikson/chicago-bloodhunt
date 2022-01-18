using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField]private Vector3[] positions;
    private int i;
    bool isEnemyRight;


    void Update()
    {
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
        //if (transform.position == positions[i + 1])
        //{
        //    Flip();
        //}
    }
    //working flip but too late to think how tf this guy can rotate
    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isEnemyRight = !isEnemyRight;
    }
}
