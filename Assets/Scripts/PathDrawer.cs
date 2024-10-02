using UnityEngine;
using UnityEngine.AI;

public class PathDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public NavMeshAgent agent;

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) return; 

        lineRenderer.positionCount = path.corners.Length;
        lineRenderer.SetPositions(path.corners);
    }

    // Обновление пути к новой цели
    public void UpdatePath(Transform target)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target.position, path);
        DrawPath(path);
    }

    void Update()
    {
        if (agent.hasPath)
        {
            DrawPath(agent.path);  
        }
    }
}
