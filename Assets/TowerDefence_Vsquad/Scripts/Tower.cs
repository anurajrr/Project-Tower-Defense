using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    public bool Catcher = false;    // Determines if the tower is a "Catcher" tower
    public Transform shootElement;  // The point where bullets are spawned
    public GameObject Towerbug;     // Reference to the tower bug object
    public Transform LookAtObj;     // Object the tower looks at to rotate
    public GameObject bullet;       // Bullet prefab
    public GameObject DestroyParticle; // Particle effect for tower destruction
    public Vector3 impactNormal_2;  // Normal direction of impact
    public Transform target;        // Current target for the tower
    public int dmg = 10;            // Damage dealt by tower bullets
    public float shootDelay;        // Delay between shots
    bool isShoot;                   // Flag to prevent rapid shooting
    public Animator anim_2;         // Animator component
    public TowerHP TowerHp;         // Reference to tower's health component
    private float homeY;            // Initial rotation of the LookAtObj

    void Start()
    {
        anim_2 = GetComponent<Animator>();       // Get the animator component
        homeY = LookAtObj.transform.localRotation.eulerAngles.y; // Store the initial Y rotation
        TowerHp = Towerbug.GetComponent<TowerHP>();  // Get the tower's health component
    }

    // Function for the Catcher tower's attack animation
    void GetDamage()
    {
        if (target)
        {
            target.GetComponent<EnemyHp>().Dmg(dmg); // Damage the target's health
        }
    }

    void Update () {

        // Rotate the tower to look at the target
        if (target)
        {
            Vector3 dir = target.transform.position - LookAtObj.transform.position;
            dir.y = 0; // Ignore Y axis rotation
            Quaternion rot = Quaternion.LookRotation(dir);
            LookAtObj.transform.rotation = Quaternion.Slerp(LookAtObj.transform.rotation, rot, 5 * Time.deltaTime);
        }
        else
        {
            // Return to home rotation when no target
            Quaternion home = Quaternion.Euler(0, homeY, 0);
            LookAtObj.transform.rotation = Quaternion.Slerp(LookAtObj.transform.rotation, home, Time.deltaTime);
        }

        // Shooting logic
        if (!isShoot)
        {
            StartCoroutine(shoot());
        }

        // If the tower is a Catcher tower
        if (Catcher == true)
        {
            // Check if the target is missing or defeated
            if (!target || target.CompareTag("Dead"))
            {
                StopCatcherAttack(); // Stop the Catcher tower's attack
            }
        }

        // Tower destruction logic
        if (TowerHp.CastleHp <= 0)
        {
            // Destroy the tower and create a destruction particle effect
            Destroy(gameObject);
            DestroyParticle = Instantiate(DestroyParticle, Towerbug.transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal_2)) as GameObject;
            Destroy(DestroyParticle, 3);
        }
    }

    IEnumerator shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(shootDelay);

        if (target && Catcher == false)
        {
            // Instantiate a bullet and set its target
            GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
            b.GetComponent<TowerBullet>().target = target;
            b.GetComponent<TowerBullet>().twr = this;
        }

        if (target && Catcher == true)
        {
            // Start the attack animation for the Catcher tower
            anim_2.SetBool("Attack", true);
            anim_2.SetBool("T_pose", false);
        }

        isShoot = false;
    }

    // Function to stop the Catcher tower's attack
    void StopCatcherAttack()
    {
        target = null;
        anim_2.SetBool("Attack", false);
        anim_2.SetBool("T_pose", true);
    }
}
