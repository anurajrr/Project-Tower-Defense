using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform shootElement;  // The point where bullets are spawned
    public GameObject bullet;       // The bullet prefab
    public GameObject Enemybug;     // Reference to the enemy bug object
    public int Creature_Damage = 10; // Damage dealt by the enemy creature
    public float Speed;             // Movement speed of the enemy
    public Transform[] waypoints;   // Waypoints the enemy follows
    int curWaypointIndex = 0;       // Index of the current waypoint
    public float previous_Speed;    // Store the previous speed for reference
    public Animator anim;           // Reference to the animator component
    public EnemyHp Enemy_Hp;        // Reference to the enemy's health component
    public Transform target;        // Target transform for attacking
    public GameObject EnemyTarget;  // The current target for the enemy

    void Start()
    {            
        anim = GetComponent<Animator>();                 // Get the animator component
        Enemy_Hp = Enemybug.GetComponent<EnemyHp>();     // Get the enemy's health component
        previous_Speed = Speed;                          // Store the initial speed
    }

    // Called when something enters the enemy's collider
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Castle")  // Check if the collider's tag is "Castle"
        {
            Speed = 0;  // Stop the enemy's movement
            EnemyTarget = other.gameObject;    // Set the current target to the castle
            target = other.gameObject.transform; // Set the target transform
            Vector3 targetPosition = new Vector3(EnemyTarget.transform.position.x, transform.position.y, EnemyTarget.transform.position.z);            
            transform.LookAt(targetPosition);     // Rotate to face the target
            anim.SetBool("RUN", false);           // Set the "RUN" animation to false
            anim.SetBool("Attack", true);         // Set the "Attack" animation to true
        }
    }

    // Called from animation event to shoot a bullet
    void Shooting ()
    {
        GameObject newBullet = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
        // Instantiate a new bullet at the shootElement position
        newBullet.GetComponent<EnemyBullet>().target = target; // Set the bullet's target
        newBullet.GetComponent<EnemyBullet>().twr = this;      // Set the bullet's tower reference
    }

    // Called when the enemy takes damage
    void GetDamage ()
    {        
        EnemyTarget.GetComponent<TowerHP>().Dmg_2(Creature_Damage);       
    }

    void Update () 
    {
        if (curWaypointIndex < waypoints.Length)
        {
            // Move the enemy towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[curWaypointIndex].position, Time.deltaTime * Speed);

            if (!EnemyTarget)
            {
                // If no target, rotate to face the waypoint
                transform.LookAt(waypoints[curWaypointIndex].position);
            }

            // Check if the enemy has reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.5f)
            {
                curWaypointIndex++; // Move to the next waypoint
            }    
        }
        else
        {
            anim.SetBool("Victory", true); // Set victory animation
        }

        if (Enemy_Hp.EnemyHP <= 0)
        {
            Speed = 0;                      // Stop movement
            Destroy(gameObject, 5f);        // Destroy the enemy after 5 seconds
            anim.SetBool("Death", true);     // Set death animation
        }

        if (EnemyTarget)
        {
            if (EnemyTarget.CompareTag("Castle_Destroyed"))
            {
                anim.SetBool("Attack", false); // Set attack animation to false
                anim.SetBool("RUN", true);     // Set run animation to true
                Speed = previous_Speed;        // Restore previous speed
                EnemyTarget = null;            // Clear the target
            }
        }
    }  
}