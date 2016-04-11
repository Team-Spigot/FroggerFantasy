using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerMovement))]
public class CollisionDetector : MonoBehaviour
{
    public LayerMask CollisionLayers;
    public LayerMask EnemyLayers;
    Vector3 StartPoint;
    Vector3 Origin;
    Vector3 DebugOrigin;
    public int NoOfRays = 10;
    int i;
    RaycastHit HitInfo;
    float LengthOfRay, DistanceBetweenRays;
    Vector2 DirectionFactor;
    float margin = 0.0f;
    Ray ray;

    void Start()
    {
        LengthOfRay = GetComponent<Collider2D>().bounds.size.y;
    }

    void Update()
    {
        StartPoint = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z);
        if (IsColliding())
        {
            Debug.Log("Collided With \"" + HitInfo.collider.gameObject.name + "\"!");
        }
    }

    public bool IsColliding()
    {
        Origin = StartPoint;
        DistanceBetweenRays = (GetComponent<Collider2D>().bounds.size.x - 2 * margin) / (NoOfRays - 1);
        for (i = 0; i < NoOfRays; i++)
        {
            ray = new Ray(Origin, GetComponent<PlayerMovement>().TargetPosition);

            if (Physics.Raycast(ray, out HitInfo, LengthOfRay, CollisionLayers.value))
            {
                return true;
            }

            Origin += new Vector3(DistanceBetweenRays, 0, 0);
        }

        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        DistanceBetweenRays = (GetComponent<Collider2D>().bounds.size.x - 2 * margin) / (NoOfRays - 1);
        if (GetComponent<PlayerMovement>().TargetPosition.x != 0)
        {
            DebugOrigin = new Vector3(transform.position.x + 0.5f, transform.position.y - 1);
        }
        else if (GetComponent<PlayerMovement>().TargetPosition.y != 0)
        {
            DebugOrigin = new Vector3(transform.position.x, transform.position.y - 0.5f);
        }

        for (i = 0; i < NoOfRays; i++)
        {
            if (GetComponent<PlayerMovement>().TargetPosition.x != 0)
            {

                Gizmos.DrawRay(DebugOrigin, GetComponent<PlayerMovement>().TargetPosition * 10);

                DebugOrigin += new Vector3(0, DistanceBetweenRays, 0);
                }
                else if (GetComponent<PlayerMovement>().TargetPosition.y != 0)
                {

                Gizmos.DrawRay(DebugOrigin, GetComponent<PlayerMovement>().TargetPosition * 10);

                DebugOrigin += new Vector3(DistanceBetweenRays, 0, 0);
            }
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, 0), new Vector3(transform.position.x + 0.5f + GetComponent<PlayerMovement>().TargetPosition.x * 15, transform.position.y - 0.5f + GetComponent<PlayerMovement>().TargetPosition.y * 15, 0));
    }
}

