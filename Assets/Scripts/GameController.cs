using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<GameObject> Drones;
    private int _score = 0;

    void Start()
    {
        Drones = new List<GameObject>(GameObject.FindGameObjectsWithTag("Drone"));
    }

    public void TargetHit(GameObject go)
    {
        if (Drones.Contains(go))
        {
            _score += 10;
            Drones.Remove(go);
            Debug.Log("Score: " + _score);
        }
        Debug.Log("Score: " + _score);
    }
}
