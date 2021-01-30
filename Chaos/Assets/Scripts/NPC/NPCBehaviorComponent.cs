using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviorComponent : MonoBehaviour
{
    private CharacterRPGComponent rpg;

    [Header("References")]
    public NPCSo npcBase; 
    public Animator animator; 
    public Player player = null; 

    [Header("Visuals")]
    public SpriteRenderer spriteRenderer; 

    [Header("Detection")]
    public CircleCollider2D detectionCollider; 

    [Header("Physics")]
    public BoxCollider2D NPCBoxCollider; 
    public LayerMask groundLayer; 

    [Header("Behavior")]
    public float groundDetectionDist; 
    public float timeBeforeDespawn; 
    private float timerDetectionToCombatState; 
    private float timerBeforeNextAttack; 
    private float timerBeforeNextBlock; 
    private float currentMoveSpeed; //We give a random move speed set up in NPCBase 

    //public SpellComponent spells; 

    private void Start()
    {
        animator = GetComponent<Animator>();

        rpg = GetComponent<CharacterRPGComponent>();
        rpg.InitRPGComponent();
        rpg.GetStat("Life").statBaseValue = npcBase.npcBase.baseLife;
        rpg.GetStat("Life").statCurrentValue = npcBase.npcBase.baseLife;

        spriteRenderer.sprite = npcBase.npcBase.NPCSprite;

        detectionCollider.radius = npcBase.npcBase.npcDetectionRadius;

        currentMoveSpeed = Random.Range(npcBase.npcBase.minMaxMovementSpeed.x, npcBase.npcBase.minMaxMovementSpeed.y);
    }

    private void Update() 
    {
        UpdateFakeNPCPhysics();
        UpdateMovementBehavior();

        if(player == null)
        {
            animator.SetBool("Bool_MoveToTarget", false);
            timerDetectionToCombatState = 0.0f;
            timerBeforeNextAttack = 0.0f;
            timerBeforeNextBlock = 0.0f;
            return;   
        } 

        //If we do have a player in range 
        if(timerDetectionToCombatState >= npcBase.npcBase.timeBeforeEnteringCombat)
        {
            animator.SetBool("Bool_MoveToTarget", true);
            timerDetectionToCombatState = npcBase.npcBase.timeBeforeEnteringCombat;
        }
        timerDetectionToCombatState += Time.deltaTime; 

        //If we can attack 
        if(timerBeforeNextAttack >= npcBase.npcBase.npcAttackRate)
        {
            animator.SetTrigger("Trigger_LaunchAttack");
            timerBeforeNextAttack = 0.0f;
            AttackPlayer();
        }
        timerBeforeNextAttack += Time.deltaTime;

        //If we can block 
        if(timerBeforeNextBlock >= npcBase.npcBase.npcBlockRate)
        {
            animator.SetTrigger("Trigger_Block");
            timerBeforeNextBlock = 0.0f;
        }
        timerBeforeNextBlock += Time.deltaTime;

        //à enlever après balancing 
        detectionCollider.radius = npcBase.npcBase.npcDetectionRadius;
    }

    private void UpdateMovementBehavior ()
    {
        if(animator.GetBool("Bool_MoveToTarget") == false || animator.GetCurrentAnimatorStateInfo(0).IsName("MoveToTarget") == false || player == null) return; 

        float movementDirection = 0.0f; 
        
        //detect direction to go to
        if(this.transform.position.x < player.transform.position.x)
        {
            spriteRenderer.flipX = false; 
            movementDirection = 1.0f;
        }
        else
        {
            spriteRenderer.flipX = true; 
            movementDirection = -1.0f; 
        }

        //If we are out of attack range, move & keep our timers reset. 
        if(Vector2.Distance(this.transform.position, player.transform.position) >= npcBase.npcBase.npcAttackRange)
        {
            timerBeforeNextAttack = 0.0f;
            timerBeforeNextBlock = 0.0f;

            //if our player is on a platform, do not move 
            if(player.transform.position.y > npcBase.npcBase.verticalLoseDistance) return; 

            this.transform.position += new Vector3(movementDirection * currentMoveSpeed * Time.deltaTime, 0.0f);
        }
    }

    //Since we cannot use rigidbody because of layers conflict and colliders being triggers, we fake gravity 
    private void UpdateFakeNPCPhysics ()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, -transform.up, groundDetectionDist, groundLayer);
        if(hit)
        {
            Debug.DrawLine(this.transform.position, hit.point, Color.green);
        }
        else
        {
            this.transform.position += new Vector3(0.0f, -9.81f * Time.deltaTime, 0.0f);
        }
    }

    private void AttackPlayer ()
    {
        //spells.Launch(); 
        player.ReceiveHit();
    }

    public void KillNPC ()
    {
        animator.SetTrigger("Trigger_Die");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(DespawnNPCASync(timeBeforeDespawn));
    }

    private IEnumerator DespawnNPCASync (float _waitFor)
    {
        yield return new WaitForSeconds(_waitFor);
        Destroy(this.gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() 
    {
        Gizmos.DrawRay(this.transform.position, - transform.up * groundDetectionDist);    
        if(npcBase == null) return; 
        UnityEditor.Handles.DrawWireDisc(this.transform.position, transform.forward, npcBase.npcBase.npcDetectionRadius);
    }
#endif
}
