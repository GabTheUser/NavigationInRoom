using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class WaypointMenu : MonoBehaviour
{
    public TMP_Dropdown waypointDropdown;
    public List<Transform> waypoints;
    public PathDrawer pathDrawer; 
    public PlayerController playerController; 

    private Transform selectedWaypoint;

    void Start()
    {
        PopulateMenu();
        waypointDropdown.onValueChanged.AddListener(OnWaypointSelected); 
    }

    void PopulateMenu()
    {
        List<string> options = new List<string>();
        foreach (var waypoint in waypoints)
        {
            options.Add(waypoint.name);
        }
        waypointDropdown.AddOptions(options);
    }

    public void OnWaypointSelected(int index)
    {
        if (index >= 0 && index < waypoints.Count)
        {
            selectedWaypoint = waypoints[index];
            pathDrawer.UpdatePath(selectedWaypoint); 

            playerController.OnWaypointChanged(selectedWaypoint);
        }
        else
        {
            Debug.Log("Invalid Waypoint index: " + index);
        }
    }

    public Transform GetSelectedWaypoint()
    {
        return selectedWaypoint;
    }
}
