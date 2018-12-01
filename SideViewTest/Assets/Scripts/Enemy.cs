using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public void Init(Vector2 direction, float speed)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision2D");
        EnemyDispenserController.Instance.HandleEnemyDestroyed(this);
    }
}
