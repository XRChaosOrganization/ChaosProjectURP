using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{

    #region Go or components

    [Space]

    [SerializeField] private Transform groundCheck;                           
    private Rigidbody2D rb;
    

    #endregion


    #region Properties

    const float groundedRadius = .2f;
    private bool isGrounded;
    private bool facingRight = true;
    [SerializeField] private LayerMask whatIsGround;

    #endregion

    #region Inputs
    #endregion

    #region Variables

    [Header("Controls")]
    [Space]

    [Range(0, 90)] public int jumpDetectAngle = 30;
    [SerializeField] [Range(20, 60)] private float jumpForce;

    private Vector3 velocity = Vector3.zero;
    
    [SerializeField] [Range(4, 15)] private float moveSpeed;
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
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;

                if (!wasGrounded)               //ne sert a rien pour l'instant, c'est au cas où on veut que le controlleur fasse quelque chose quand le perso touche le sol
                    OnLandEvent.Invoke();       //un effet de poussière a l'aterissage par exemple
            }
                
        }

    }

	
    void Update()
    {
        
    }
    #endregion

    #region Methods

    public void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * moveSpeed, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (isGrounded && jump)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce * 10f));
        }

    }

    private void Flip()
    {
        
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    #endregion
}
