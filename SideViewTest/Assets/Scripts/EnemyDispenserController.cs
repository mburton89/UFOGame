using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispenserController : MonoBehaviour 
{
    public static EnemyDispenserController Instance;

    [SerializeField] private EnemyDispenser topLeftDispenser;
	[SerializeField] private EnemyDispenser topLeft2Dispenser;
	[SerializeField] private EnemyDispenser topRightDispenser;
	[SerializeField] private EnemyDispenser topRight2Dispenser;
	[SerializeField] private EnemyDispenser bottomLeftDispenser;
    [SerializeField] private EnemyDispenser bottomRightDispenser;

    public float speed;

    [HideInInspector] public List<Enemy> activeEnemies;

    void Awake () 
    {
        Instance = this;

		topLeftDispenser.Init(this);
		topLeft2Dispenser.Init(this);
		topRightDispenser.Init(this);
		topRight2Dispenser.Init(this);
        bottomLeftDispenser.Init(this);
        bottomRightDispenser.Init(this);
    }

    private void Start()
    {
        DetermineIfShouldFire();
    }

    void DetermineIfShouldFire()
    {
        if(activeEnemies.Count <= 0)
        {
            FireRandomSequence();
        }
    }

    void FireRandomSequence()
    {
		var randomInt = Random.Range (0, 4);

		if (randomInt == 0)
		{
			FireFour();
		}
		else if (randomInt == 1)
		{
			FireTwoLeft();
		}
		else if (randomInt == 2)
		{
			FireTwoRight();
		}
		else if (randomInt == 3)
		{
			FireMix1();
		}
		else if (randomInt == 4)
		{
			FireMix2();
		}
    }

    public void FireFour()
    {
        activeEnemies.Add(topLeftDispenser.FireEnemy());
        activeEnemies.Add(topRightDispenser.FireEnemy());
        activeEnemies.Add(bottomLeftDispenser.FireEnemy());
        activeEnemies.Add(bottomRightDispenser.FireEnemy());
    }

	public void FireTwoLeft()
	{
		activeEnemies.Add(topLeft2Dispenser.FireEnemy());
		activeEnemies.Add(bottomLeftDispenser.FireEnemy());
	}

	public void FireTwoRight()
	{
		activeEnemies.Add(topRight2Dispenser.FireEnemy());
		activeEnemies.Add(bottomLeftDispenser.FireEnemy());
	}

	public void FireMix1()
	{
		activeEnemies.Add(topLeft2Dispenser.FireEnemy());
		activeEnemies.Add(bottomRightDispenser.FireEnemy());
	}

	public void FireMix2()
	{
		activeEnemies.Add(topRight2Dispenser.FireEnemy());
		activeEnemies.Add(bottomLeftDispenser.FireEnemy());
	}

    public void HandleEnemyDestroyed(Enemy destroyedEnemy)
    {
        activeEnemies.Remove(destroyedEnemy);
        Destroy(destroyedEnemy.gameObject, 1); 
        DetermineIfShouldFire();
    }
}
