using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == TryGetComponent<Player>(out Player player))
        {
            Destroy(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
