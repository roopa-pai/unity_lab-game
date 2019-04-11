using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BotScript : MonoBehaviour {

    public GameObject patrolpath;
    private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private string nameText;
    private Vector3 screenPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        points = patrolpath.GetComponentsInChildren<Transform>();
        nameText = this.gameObject.transform.name;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        GotoNextPoint();
    }
    void OnGUI()
    {
        GUI.contentColor = Color.black;
        screenPosition = Camera.main.WorldToScreenPoint((transform.position += new Vector3(0, 2f, 0)));
        screenPosition.y = Screen.height - screenPosition.y;
        if (screenPosition.z>=0 && screenPosition.z<40 )
            GUI.Box(new Rect(screenPosition.x, screenPosition.y, 80, 20), nameText);
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        //Returns if no points have been set up
        if (points.Length == 0)
            return;

        //Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        //Choose the next point in the array as the destination,
        //cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

}