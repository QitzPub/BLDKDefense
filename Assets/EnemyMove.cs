using UnityEngine;

public enum EnemyMoveState
{
    Grounding,
    Flying,
    Climbing,
}

public class EnemyMove
{
    public delegate bool HasReachedCheckpoint(Vector3 position);
    public HasReachedCheckpoint hasReachedCheckpoint = (position) => false;

    public int checkpointIndex = -1;
    public Vector3 currentAngle = Vector3.zero;

    public Vector3 forwardAngle = new Vector3(0, 0, 0);
    public Vector3 rightAngle = new Vector3(0, 90, 0);
    public Vector3 backAngle = new Vector3(0, 180, 0);
    public Vector3 leftAngle = new Vector3(0, 270, 0);

    public float ForwardVelocity { get; private set; }
    public float VerticalVelocity { get; private set; }

    public EnemyMoveState state;

    public Vector3 GetAngles()
    {
        return Vector3.zero;
    }

    public void UpdateDestination(bool forceUpdate, Vector3 enemyPosition, Vector3 nextCheckpoint)
    {
        if (forceUpdate || hasReachedCheckpoint(enemyPosition))
        {
            checkpointIndex++;
            Vector3 destination = nextCheckpoint;
            float x = destination.x - enemyPosition.x;
            float z = destination.z - enemyPosition.z;

            if (Mathf.Abs(z) < Mathf.Abs(x))
            {
                if (0 < x)
                {
                    currentAngle = rightAngle;
                    hasReachedCheckpoint = (position) => destination.x <= position.x;
                }
                else
                {
                    currentAngle = leftAngle;
                    hasReachedCheckpoint = (position) => position.x <= destination.x;
                }
            }
            else
            {
                if (0 < z)
                {
                    currentAngle = forwardAngle;
                    hasReachedCheckpoint = (position) => destination.z <= position.z;
                }
                else
                {
                    currentAngle = backAngle;
                    hasReachedCheckpoint = (position) => position.z <= destination.z;
                }
            }
        }
    }

    public void UpdateMoveState(int groundingTriggerCount, int climbingTriggerCount)
    {
        if (0 < climbingTriggerCount)
        {
            state = EnemyMoveState.Climbing;
        }
        else if (0 < groundingTriggerCount)
        {
            state = EnemyMoveState.Grounding;
        }
        else
        {
            state = EnemyMoveState.Flying;
        }
    }

    public void UpdateVelocity(Vector3 groundingVector, Vector3 flyingVector, Vector3 climbingVector)
    {
        switch (state)
        {
            case EnemyMoveState.Grounding:
                ForwardVelocity = groundingVector.x;
                VerticalVelocity = groundingVector.y;
                break;
            case EnemyMoveState.Flying:
                ForwardVelocity = flyingVector.x;
                VerticalVelocity = flyingVector.y;
                break;
            case EnemyMoveState.Climbing:
                ForwardVelocity = climbingVector.x;
                VerticalVelocity = climbingVector.y;
                break;
        }
    }

}
