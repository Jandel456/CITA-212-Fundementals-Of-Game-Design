using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFMiniManager : MonoBehaviour
{
    public Fighter playerFighter;
    public Fighter enemyFighter;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click to attack
        {
            if (IsClickedOn(playerFighter))
            {
                playerFighter.Block();
            }
            else if (IsClickedOn(enemyFighter))
            {
                playerFighter.Attack(enemyFighter);
            }
        }
    }

    private bool IsClickedOn(Fighter fighter)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.collider.gameObject == fighter.gameObject;
        }
        return false;
    }
}