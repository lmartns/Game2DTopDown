using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab; // prefab of wood
    [SerializeField] private int totalWood; // total wood in the tree

    public void OnHit()
    {
        treeHealth --;

        anim.SetTrigger ("IsHit");

        if (treeHealth <= 0)
        {
            for(int i = 0; i < totalWood; i++)
            {
                //cria o prefab de madeira
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, -1f), 0f), transform.rotation);
            }
            anim.SetTrigger ("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
