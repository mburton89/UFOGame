using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispenserController : MonoBehaviour 
{
    public static EnemyDispenserController Instance;

    [SerializeField] private EnemyDispenser topLeftDispenser;
    [SerializeField] private EnemyDispenser topRightDispenser;
    [SerializeField] private EnemyDispenser bottomLeftDispenser;
    [SerializeField] private EnemyDispenser bottomRightDispenser;

    public float speed;

    [HideInInspector] public List<Enemy> activeEnemies;

    void Awake () 
    {
        Instance = this;

        topLeftDispenser.Init(this);
        topRightDispenser.Init(this);
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
        FireFour();
    }

    public void FireFour()
    {
        activeEnemies.Add(topLeftDispenser.FireEnemy());
        activeEnemies.Add(topRightDispenser.FireEnemy());
        activeEnemies.Add(bottomLeftDispenser.FireEnemy());
        activeEnemies.Add(bottomRightDispenser.FireEnemy());
    }

    public void HandleEnemyDestroyed(Enemy destroyedEnemy)
    {
        activeEnemies.Remove(destroyedEnemy);
        Destroy(destroyedEnemy.gameObject, 1); 
        DetermineIfShouldFire();
    }
}
