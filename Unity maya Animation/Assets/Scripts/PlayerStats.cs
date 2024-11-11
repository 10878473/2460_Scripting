using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public int hp = 20;
    public float speed = 5f;
    public float jumpHeight = 10;

    
    public int maxJumps = 2;
    public float flightpower = 4f;
    public int maxFlight = 200;
    public int flightleft;
    public bool isflying = true;

    public void IncreaseFlight()
    {
        maxFlight += 20;
    }

    public void DamageTaken()
    {
        hp -= 1;
    }
}
