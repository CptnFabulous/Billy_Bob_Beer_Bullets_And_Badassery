using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))]

public class EnemyMelee : MonoBehaviour
{
    NavMeshAgent na;

    public GameObject head; // Used to determine where the enemy attacks from

    public GameObject targetedCharacter; // The thing it wants to attack, in this case the player

    //public float movementSpeed = 5;

    [Header("Melee Attack")]
    public int meleeDamage = 10;
    public float meleeExecuteRange = 2; // Range at which the enemy decides to attack the player
    public float meleeAttackRange = 3; // Actual range the attack can reach
    public float meleeAttackDelay = 0.5f; // How long the attack takes
    public float meleeCooldown = 1; // Time before executing next attack
    float meleeDelayTimer; // Counts up appropriate delay for enemy melee attacks
    float meleeCooldownTimer = 9999999;
    bool isMeleeAttacking;
    Vector3 enemyAttackDirection;
    RaycastHit meleeHitDetection;


    //int ct;


    // Start is called before the first frame update
    void Start()
    {
        na = GetComponent<NavMeshAgent>();
        //na.speed = movementSpeed;

        if (targetedCharacter == null) // If no target is assigned, look for one
        {
            FindTarget();
        }
    }

    void FindTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); // Finds all objects tagged Player
        int ct = 0;
        for(int i = 0; i < players.Length - 1; i++) // Checks each object
        {
            float gd = Vector3.Distance(transform.position, players[i].transform.position); // Distance between transform and currently processed target
            float cd = Vector3.Distance(transform.position, players[ct].transform.position); // Distance between transform and current closest target
            if (gd < cd || (gd == cd && Mathf.RoundToInt(Random.value) == 1)) // If currently processed target is closer, OR the two distances are the same, in which case it is randomly decided whether to declare a new closest target or not
            {
                ct = i; // New closest target
            }
        }
        targetedCharacter = players[ct]; // Index ct is used to determine closest target and assign to GameObject t;
    }

    // Update is called once per frame
    void Update()
    {
        meleeCooldownTimer += Time.deltaTime; // Counts up until enemy can perform another attack

        SeekEnemy(); // Seeks out target

        MeleeAttack(); // Runs code for executing melee attacks

        /*
        if (isMeleeAttacking == true)
        {
            meleeDelayTimer += Time.deltaTime;
            print(meleeDelayTimer);
            if (meleeDelayTimer >= meleeAttackDelay)
            {
                ExecuteMeleeAttack();
                print("Melee attack executed");
                isMeleeAttacking = false;
                meleeCooldownTimer = 0;
            }
        }
        */
    }

    void SeekEnemy() // Enemy will seek out a character it is hostile towards and considers an targetedCharacter
    {
        na.destination = targetedCharacter.transform.position;
        /*
        if (Vector3.Distance(transform.position, targetedCharacter.transform.position) <= meleeExecuteRange && isMeleeAttacking == false && meleeCooldownTimer >= meleeCooldown)
        {
            InitiateMeleeAttack();
        }
        */
    }

    void MeleeAttack()
    {
        if (Vector3.Distance(transform.position, targetedCharacter.transform.position) <= meleeExecuteRange && isMeleeAttacking == false && meleeCooldownTimer >= meleeCooldown) // If enemy is within melee range, is not already attacking and cooldown has finished
        {
            //na.destination = transform.position;
            // Stops enemy for a second
            na.isStopped = true;
            na.enabled = false;
            // Rotates enemy towards target
            enemyAttackDirection = new Vector3(targetedCharacter.transform.position.x, transform.position.y, targetedCharacter.transform.position.z);
            transform.LookAt(enemyAttackDirection);
            // Reuses enemyAttackDirection Vector3 to determine direction enemy attacks in
            enemyAttackDirection = targetedCharacter.transform.position - head.transform.position;
            isMeleeAttacking = true; // Enables bool so the enemy does not execute an attack before finishing the previous one
            meleeDelayTimer = 0; // Resets delay timer
        }

        if (isMeleeAttacking == true) // If enemy is in the process of attacking
        {
            meleeDelayTimer += Time.deltaTime; // Counts up delay timer
            print(meleeDelayTimer);
            if (meleeDelayTimer >= meleeAttackDelay) // If timer reaches appropriate delay
            {
                print("Raycast launched");

                if (Physics.Raycast(head.transform.position, enemyAttackDirection, out meleeHitDetection, meleeAttackRange)) // Shoot raycast to detect enemy
                {
                    print("Raycast hit");
                    Health targetHealth = meleeHitDetection.collider.GetComponent<Health>(); // Check for health on object hit
                    if (targetHealth != null) // If health script is present
                    {
                        print("Enemy struck");
                        targetHealth.Damage(meleeDamage); // Deal damage
                    }
                }

                print("Melee attack executed");
                isMeleeAttacking = false; // Enemy is no longer attacking
                meleeCooldownTimer = 0; // Reset cooldown timer
                // Reenable movement
                na.enabled = true;
                na.isStopped = false;

            }
        }
    }


    /*
    void InitiateMeleeAttack()
    {
        na.destination = transform.position;
        enemyAttackDirection = new Vector3(targetedCharacter.transform.position.x, transform.position.y, targetedCharacter.transform.position.z);
        transform.LookAt(enemyAttackDirection);
        enemyAttackDirection = targetedCharacter.transform.position - transform.position;
        isMeleeAttacking = true;
        meleeDelayTimer = 0;
    }

    void ExecuteMeleeAttack()
    {
        print("Raycast launched");
        if (Physics.Raycast(transform.position, enemyAttackDirection, out meleeHitDetection, meleeAttackRange))
        {
            print("Raycast hit");
            DamageHitbox enemyHitbox = meleeHitDetection.collider.GetComponent<DamageHitbox>();
            print("Enemy struck");
            if (enemyHitbox != null)
            {
                enemyHitbox.Damage(meleeDamage, DamageType.KnockedOut);
            }
        }
    }
    */
}
