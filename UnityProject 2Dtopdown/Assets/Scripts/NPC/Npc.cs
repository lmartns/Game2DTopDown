using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    //variáveis 
    public float speed;

    private int index;

    public List<Transform> paths = new List<Transform>();
    
    void Update()
    {
        //movendo o npc em direção ao path 
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f) 
        {
            if(index < paths.Count - 1) 
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index]. position - transform.position;

        if(direction.x > 0) 
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x < 0) 
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
