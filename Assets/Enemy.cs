using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector2 groundingVector;
    [SerializeField] Vector2 flyingVector;
    [SerializeField] Vector2 climbingVector;

    [SerializeField] ColliderManager groundingTrigger;
    [SerializeField] ColliderManager climbingTrigger;

    [SerializeField] Slider healthBar;

    EnemyType type;
    int health;

    EnemyParam enemyParam;
    EnemyMove enemyMove = new EnemyMove();

    public void Initialize(EnemyParam enemyParam)
    {
        this.type = enemyParam.EnemyType;
        this.health = enemyParam.Health;
        healthBar.maxValue = health;
        healthBar.value = health;

        groundingTrigger.collidersEvent = () =>
        {
            enemyMove.UpdateMoveState(groundingTrigger.colliders.Count, climbingTrigger.colliders.Count);
            enemyMove.UpdateVelocity(groundingVector, flyingVector, climbingVector);
        };
        climbingTrigger.collidersEvent = () =>
        {
            enemyMove.UpdateMoveState(groundingTrigger.colliders.Count, climbingTrigger.colliders.Count);
            enemyMove.UpdateVelocity(groundingVector, flyingVector, climbingVector);
        };

        enemyMove.UpdateDestination(true, transform.position, ObjectManager.Instance.WaveManager.checkpoints[enemyMove.checkpointIndex + 1]);

        enemyMove.UpdateMoveState(groundingTrigger.colliders.Count, climbingTrigger.colliders.Count);
        enemyMove.UpdateVelocity(groundingVector, flyingVector, climbingVector);
        UpdateAngles();
    }

    public void UpdateFrame()
    {
        UpdatePosition();
        UpdateHealthBar();
    }

    void UpdatePosition()
    {
        transform.position += transform.forward * enemyMove.ForwardVelocity + Vector3.up * enemyMove.VerticalVelocity;

        if (enemyMove.hasReachedCheckpoint(transform.position))
        {
            Vector3 position = transform.position;
            Vector3 currentDestination = ObjectManager.Instance.WaveManager.checkpoints[enemyMove.checkpointIndex];
            position.x = currentDestination.x;
            position.z = currentDestination.z;

            bool hasReachedGoal = ObjectManager.Instance.WaveManager.checkpoints.Count <= enemyMove.checkpointIndex + 1 && enemyMove.hasReachedCheckpoint(transform.position);
            if (hasReachedGoal)
            {
                ReachGoal();
                return;
            }

            bool hasValidCheckpointIndex = enemyMove.checkpointIndex + 1 < ObjectManager.Instance.WaveManager.checkpoints.Count;
            if (hasValidCheckpointIndex)
            {
                transform.position = position;
                enemyMove.UpdateDestination(false, transform.position, ObjectManager.Instance.WaveManager.checkpoints[enemyMove.checkpointIndex + 1]);
                UpdateAngles();
            }

        }
    }

    void UpdateAngles()
    {
        transform.eulerAngles = enemyMove.currentAngle;
    }

    void UpdateHealthBar()
    {
        healthBar.value = health;
        healthBar.transform.LookAt(Camera.main.transform);
        healthBar.transform.RotateAround(transform.position, Vector3.up, 180);
    }

    void DestroyThis(bool goal)
    {
        ObjectManager.Instance.WaveManager.DeregisterEnemy(this);
        if (goal)
        {
            Destroy(gameObject);
        }
        else
        {
            GameDataManager.Instance.AddMoney(GameMasterData.GetRoot(type));
            GameDataManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }

    public void ReachGoal()
    {
        ObjectManager.Instance.Goal.GiveDamage();
        ObjectManager.Instance.WaveManager.DeregisterEnemy(this);
        DestroyThis(true);
    }

    public void Damaged(int damage) {
        health -= damage;
        bool isDied = health <= 0;
        if(isDied) {
            DestroyThis(false);
        }
    }
}

