using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPostion = waypoints[waypointIndex].position;                              // this shows us where we are and where we are going
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;                               // this shows us how fast we are going, so this is the distance we move each frame.
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, delta);     // this is what actually what moves our enemy to our next waypoint.
            if (transform.position == targetPostion)
            {
                waypointIndex++; // gives us the next waypoint we have to follow.
            }
        }
        else
        {
            Destroy(gameObject);    // once we're done following the waypoints, we killourselves. Yippe!!!!
        }
    }
}
