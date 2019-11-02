using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public MovementController controller;
    public Animator animator;
    public CapsuleCollider2D collider;
    public float MoveSpeed = 40f;
    public float standingColliderXSize;
    public float standingColliderYSize;
    public float crouchingColliderXSize;
    public float crouchingColliderYSize;

    private float _horizontalDirection = 0;
    bool jump = false;
    bool crouch = false;

    void Start () {
        collider.direction = CapsuleDirection2D.Vertical;
        collider.size = new Vector2(standingColliderXSize, standingColliderYSize);
    }

    void Update () {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(_horizontalDirection * MoveSpeed));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnCrouching(bool IsCrouching) {
        animator.SetBool("IsCrouching", IsCrouching);
        if (IsCrouching) {
            collider.direction = CapsuleDirection2D.Horizontal;
            collider.size = new Vector2(crouchingColliderXSize, crouchingColliderYSize);
        }
        else {
            collider.direction = CapsuleDirection2D.Vertical;
            collider.size = new Vector2(standingColliderXSize, standingColliderYSize);
        }
    }

    void FixedUpdate () {
        // Movement
        controller.Move(_horizontalDirection * MoveSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}