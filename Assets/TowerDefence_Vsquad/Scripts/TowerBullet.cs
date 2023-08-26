using UnityEngine;
using System.Collections;

public class TowerBullet : MonoBehaviour {

    public float Speed;              // Speed at which the bullet moves
    public Transform target;         // Target transform for the bullet to follow
    public GameObject impactParticle; // Particle effect for bullet impact
    public Vector3 impactNormal;     // Normal direction of impact
    Vector3 lastBulletPosition;      // Last known position of the target (if it disappears)
    public Tower twr;                // Reference to the tower that shot the bullet
    float i = 0.05f;                 // Delay time before bullet destruction

    void Update() {

        // Bullet movement towards the target
        if (target)
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed); 
            lastBulletPosition = target.transform.position; 
        }
        // Bullet movement when target disappears
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, lastBulletPosition, Time.deltaTime * Speed);

            if (transform.position == lastBulletPosition) 
            {
                Destroy(gameObject, i);

                // Bullet impact when the target disappeared
                if (impactParticle != null) 
                {
                    impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;  // Tower's hit
                    Destroy(impactParticle, 3);
                    return;
                }
            }           
        }     
    }

    // Bullet collision with other objects
    void OnTriggerEnter (Collider other) 
    {
        if(other.gameObject.transform == target)
        {
            // Damage the target's health and destroy the bullet
            target.GetComponent<EnemyHp>().Dmg(twr.dmg); 
            Destroy(gameObject, i); 
            
            // Create impact particle effect
            impactParticle = Instantiate(impactParticle, target.transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
            impactParticle.transform.parent = target.transform;
            Destroy(impactParticle, 3);
            return;  
        }
    }
}
