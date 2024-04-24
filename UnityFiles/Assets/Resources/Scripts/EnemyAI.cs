using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;

public class EnemyAI : MonoBehaviour
{

    //FMOD Vars
    public FMODUnity.StudioEventEmitter emitter1;
    public FMODUnity.StudioEventEmitter emitter2;


    //EnemyFOV vars
    public float radius;
    [Range(0, 360)]
    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol vars
    public Vector3 walkPoint;
    public Vector3 distanceToWalkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float patrolTimer;
    private RaycastHit hit;
    private float range;

    //Attack vars
    public float timeBetweenAttacks;
    public float playerSightTimer;
    bool alreadyAttacked;
    private bool hasAttacked;
    private bool chased = false;
    private bool hasScared = false;
    [SerializeField] private AttributeManager atm;
    bool canMove;

    //Animation vars
    private float animSpeed;
    private Animator animator;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        
        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.updateRotation = false;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(Pickup.bearCount != 3)
        {

            if (chased) SearchWalkPoint();

            if(!canSeePlayer && playerSightTimer < 6) Patrol(); 
            if(canSeePlayer && !playerInAttackRange)
            {
                playerSightTimer += 2 * Time.deltaTime;
                Chase();
            }

            if(!canSeePlayer && playerSightTimer > 6 && !playerInAttackRange) Chase();

            if(!canSeePlayer && playerSightTimer > 0)
            {
                playerSightTimer -= 2 * Time.deltaTime;
            }

            if(canSeePlayer && playerInAttackRange) Attack();


            if(gameObject.transform.position == Vector3.zero)
            {
                animator.SetFloat("Speed", 0);
            }
            else
            {
                animator.SetFloat("Speed", 0.01f);
            }

            if(agent.velocity != Vector3.zero)
            {
                agent.transform.eulerAngles = new Vector3(0, Quaternion.LookRotation(agent.velocity).eulerAngles.y, 0);
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            animator.SetFloat("Speed", 0);
            animator.SetBool("IsDead", true);
        }
    }

    private void Patrol()
    {

        chased = false;
        hasScared = false;

        patrolTimer += Time.deltaTime;
        if (!walkPointSet && patrolTimer > 8f)
        {
            walkPoint = player.position;
            walkPointSet = true;
            patrolTimer = 0f;
            emitter1.Play();
        }

        print("Patrolling.");
        if (!walkPointSet && patrolTimer < 10)
        {
            SearchWalkPoint();
        }

        distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached || magnitude < 1.2f needed otherwise walkpoint is never set to false
        if (distanceToWalkPoint.magnitude < 1.2f)
        {
            walkPointSet = false;
        }

        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
            
    }


    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            Debug.Log("searched walkpoint set");
            walkPointSet = true;
        }
    }

    private void Chase()
    {
        if(hasAttacked)
        {
            canMove = true;
            chased = true;
            animator.SetBool("InAttackRange", false);
            agent.SetDestination(player.position);
        }
        

        if(!hasScared)
        {
            hasScared = true;
            emitter2.Play();
        }
    }

    private void Attack()
    {
        
        print("Attacking.");
        agent.SetDestination(transform.position);

        agent.transform.rotation = Quaternion.Euler(0, player.rotation.y, 0);
        agent.velocity = Vector3.zero;
        
        Vector3 newPos = new Vector3(player.position.x, gameObject.transform.position.y, player.position.z);
        transform.LookAt(newPos);
        
        //USE bool canMove
        
        if (!alreadyAttacked)
        {
            canMove = false;

            //atm.DealDamage(player.gameObject);

            //Animation
            animator.SetBool("InAttackRange", true);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void damageEffect()
    {
        atm.DealDamage(player.gameObject);
    }


    //FUNCTION NOT USED YET.
    private void enemyAttacking()
    {
        hasAttacked = true;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
