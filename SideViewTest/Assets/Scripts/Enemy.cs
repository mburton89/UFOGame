using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public void Init(Vector2 direction, float speed)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyDispenserController.Instance.HandleEnemyDestroyed(this);
    }

	private void OnDestroy(){
		if (EnemyDispenserController.Instance != null) 
		{
			EnemyDispenserController.Instance.HandleEnemyDestroyed(this);
		}
	}
}
