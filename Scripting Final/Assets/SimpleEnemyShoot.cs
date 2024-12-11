using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SimpleEnemyShoot : MonoBehaviour {

    public Transform target;
    public GameObject ProjectilePrefab;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    public void FireAtTarget()
    {
        Vector3 targetposition = target.position;
        float angle = AngleBetweenPoints(transform.position, targetposition);
        angle += 180;
        GameObject newProjectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        newProjectile.transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
    }

   
    float AngleBetweenPoints(Vector2 a, Vector2 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
	
}