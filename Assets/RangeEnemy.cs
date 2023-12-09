using System.Collections;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] public int initialEnemyHP = 20;
    public int enemyHP;
    private bool isDead = false;
    private Animator animator;

    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    public float attackSpeed;

    [SerializeField] private Sprite corpseSprite;

    private Transform target;
    private float timeUntilFire;
    private AudioSource attackSFX;

    private void Start()
    {
        attackSFX = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        enemyHP = initialEnemyHP;
        attackSpeed = initialAttackSpeed;
    }

    private void Update()
    {
        if (isDead)
            return;

        if (target == null)
        {
            FindTarget();
            return;
        }
        float distanceToTarget = Vector2.Distance(target.position, transform.position);
        animator.SetBool("inRange", distanceToTarget <= targetingRange);

        if (!inRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
        }
        if (timeUntilFire >= 1f / attackSpeed)
        {
            animator.SetTrigger("isAttack");
            timeUntilFire = 0f;
        }
    }

    public void Attack()
    {
        if (target == null)
        {
            return;
        }
        GameObject projectilesObj = Instantiate(projectilesPrefab, firingPoint.position, Quaternion.identity);

        Vector2 directionToPlayer = target.transform.position - firingPoint.position;

        enemyProjectiles projectilesScript = projectilesObj.GetComponent<enemyProjectiles>();
        projectilesScript.SetInitialDirection(directionToPlayer);
        attackSFX.Play();
    }

    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, playerMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }



   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}