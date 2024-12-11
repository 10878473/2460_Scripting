using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public int maxhp = 20;
    public int hp = 20;
    public float speed = 5f;
    public float jumpHeight = 10;

    public int maxJumps = 2;
    public float flightpower = 4f;
    public int maxFlight = 200;
    public int flightleft;
    public bool isflying = true;

    // Getter and Setter for hp
    public int GetHP()
    {
        return hp;
    }

    public void SetHP(int value)
    {
        hp = value;
    }

    public void ChangeHP(int delta)
    {
        hp += delta;
    }

    // Getter and Setter for jumpHeight
    public float GetJumpHeight()
    {
        return jumpHeight;
    }

    public void SetJumpHeight(float value)
    {
        jumpHeight = value;
    }

    public void ChangeJumpHeight(float delta)
    {
        jumpHeight += delta;
    }

    // Getter and Setter for flightpower
    public float GetFlightPower()
    {
        return flightpower;
    }

    public void SetFlightPower(float value)
    {
        flightpower = value;
    }

    public void ChangeFlightPower(float delta)
    {
        flightpower += delta;
    }

    // Getter and Setter for maxFlight
    public int GetMaxFlight()
    {
        return maxFlight;
    }

    public void SetMaxFlight(int value)
    {
        maxFlight = value;
    }

    public void ChangeMaxFlight(int delta)
    {
        maxFlight += delta;
    }

    public void IncreaseFlight()
    {
        maxFlight += 20;
    }

    public void DamageTaken()
    {
        hp -= 1;
    }

    // Setter and modifiers for speed
    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void IncreaseSpeed(float delta)
    {
        speed += delta;
    }

    public void DecreaseSpeed(float delta)
    {
        speed -= delta;
    }
}