using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Alex : c'est cool de le garder indépendant des inputs, je l'utiliserais probablement pour les NPC si il reste comment ça 
public class CharacterControllerComponent : MonoBehaviour
{

    #region Go or components

    [Space]

    [SerializeField] private Transform groundCheck;                           
    private Rigidbody2D rb;
    

    #endregion


    #region Properties

    const float groundedRadius = .3f;
    public bool isGrounded;
    private bool facingRight = true;
    [SerializeField] private LayerMask whatIsGround;

    #endregion

    #region Inputs
    #endregion

    #region Variables

    [Header("Controls")]
    [Space]


    [Range(-0.5f, 0)] public float interractDetectAngle;
    [Range(0, 0.5f)] public float jumpDetectAngle;
    [SerializeField] [Range(0, 15)] private float jumpForce;
    [SerializeField] [Range(0, 2)] private float jumpCD;
    private bool jumpIsCD;
    private float jumpTimer = 0;
    private Vector3 velocity = Vector3.zero;
    
    
    [SerializeField] [Range(0, 10)] private float moveSpeed;
    [SerializeField] [Range(0, .3f)]  private float movementSmoothing = .05f;
    

    #endregion


    #region Events
    
    [Header("Event")]
    [Space]

    public UnityEvent OnLandEvent;


    #endregion


    #region Unity loop
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        

    }

	
    void Update()
    {
        GroundCheck();

        if (jumpTimer > 0)
            jumpTimer -= Time.deltaTime;
        else
        {
            jumpTimer = 0;
            jumpIsCD = false;
        }
    }
    #endregion

    #region Methods

    public void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * moveSpeed * 100 * Time.deltaTime, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        
        if (isGrounded && jump && !jumpIsCD)
        {
            jumpIsCD = true;
            isGrounded = false;
            
            rb.AddForce(new Vector2(0f, jumpForce * 100f));
        }
        
        
    }

    private void Flip()
    {
        
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;

                if (!wasGrounded)
                {
                    jumpTimer = jumpCD;
                    OnLandEvent.Invoke();
                }              
                      
            }

        }
    }

    #endregion
}
