using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/PlayerStatsSO")]
public class PlayerStatsSO : ScriptableObject
{
    public float speed;
    public Vector3 aura;

    public void slowplayer()
    {
        speed /= 2;
    }

    public void fastplayer()
    {
        speed *= 2;
    }

    public void changeaura(Vector3 newaura)
    {
        this.aura = newaura;
    }

    
}
