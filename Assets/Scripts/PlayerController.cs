using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public WaypointMenu waypointMenu;
    public PathDrawer pathDrawer;
    public HoldButton holdButton;
    public GameObject arrivalPanel;

    private bool isMoving = false;
    private Transform targetWaypoint;

    void Update()
    {
        if (holdButton.isPressed)
        {
            if (!isMoving)
            {
                targetWaypoint = waypointMenu.GetSelectedWaypoint();
                if (targetWaypoint != null)
                {
                    agent.isStopped = false;  
                    agent.SetDestination(targetWaypoint.position);
                    pathDrawer.UpdatePath(targetWaypoint);
                    isMoving = true;
                }
            }
        }
        else if (isMoving)
        {
            agent.isStopped = true; 
            isMoving = false;
        }

        if (isMoving && targetWaypoint != null)
        {
            pathDrawer.UpdatePath(targetWaypoint); 
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath)
            {
                isMoving = false;
                agent.isStopped = true;

                arrivalPanel.SetActive(true);
            }
        }
    }

    public void OnWaypointChanged(Transform newWaypoint)
    {
        targetWaypoint = newWaypoint;
        agent.SetDestination(targetWaypoint.position);
        pathDrawer.UpdatePath(targetWaypoint); 
        agent.isStopped = false; 
        isMoving = true;
        arrivalPanel.SetActive(false);
    }
}
