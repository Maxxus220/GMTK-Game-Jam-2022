using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VI_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput inputSys;
    private InputAction moveUpAction;
    private InputAction moveDownAction;
    private InputAction moveLeftAction;
    private InputAction moveRightAction;
    public Vector2 lookDirection;
    [SerializeField] Game_Manager gm;
    private VI_Action_Selector vas;
    public int canMove;
    const int CAN_MOVE = 1;
    const int CANT_MOVE = 0;
    const int DISABLED = -1;
    private AudioSource roll;

    // Start is called before the first frame update
    void Awake()
    {
        roll = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        vas = GetComponent<VI_Action_Selector>();
        inputSys = GetComponent<PlayerInput>();
        moveUpAction = inputSys.actions["MoveUp"];
        moveDownAction = inputSys.actions["MoveDown"];
        moveLeftAction = inputSys.actions["MoveLeft"];
        moveRightAction = inputSys.actions["MoveRight"];
        moveUpAction.performed += MoveUp;
        moveDownAction.performed += MoveDown;
        moveRightAction.performed += MoveRight;
        moveLeftAction.performed += MoveLeft;



        canMove = DISABLED;
        lookDirection = Vector2.left;
    }

    private void OnDisable()
    {
        moveUpAction.performed -= MoveUp;
        moveDownAction.performed -= MoveDown;
        moveRightAction.performed -= MoveRight;
        moveLeftAction.performed -= MoveLeft;
    }

    private void Update()
    {
        if(lookDirection == Vector2.right)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(lookDirection == Vector2.left)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        if (canMove == CAN_MOVE)
        {
            LayerMask mask = 49344;
            Vector2 position = rb.position;
            RaycastHit2D ray = Physics2D.Raycast(position, Vector2.up, 1.4f, mask);
            
            if (ray.collider == null)
            {
                roll.Play();
                lookDirection = Vector2.up;
                StartCoroutine(ActionTaken(0.075f));
                position += Vector2.up;
                rb.MovePosition(position);
                gm.Roll();
                gm.MoveEnemies();
                lowerVASCooldowns();
            }
        }
        else if(vas.selectState > 0)
        {
            lookDirection = Vector2.up;
        }
    }

    private void MoveDown(InputAction.CallbackContext context)
    {
        if (canMove == CAN_MOVE)
        {
            LayerMask mask = 49344;
            Vector2 position = rb.position;
            RaycastHit2D ray = Physics2D.Raycast(position, Vector2.down, 1.4f, mask);
            if (ray.collider == null)
            {
                roll.Play();
                lookDirection = Vector2.down;
                StartCoroutine(ActionTaken(0.075f));
                position += Vector2.down;
                rb.MovePosition(position);
                gm.Roll();
                gm.MoveEnemies();
                lowerVASCooldowns();
            }
        }
        else if (vas.selectState > 0)
        {
            lookDirection = Vector2.down;
        }
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        if (canMove == CAN_MOVE)
        {
            LayerMask mask = 49344;
            Vector2 position = rb.position;
            RaycastHit2D ray = Physics2D.Raycast(position, Vector2.right, 1.4f, mask);
            
            if (ray.collider == null)
            {
                roll.Play();
                lookDirection = Vector2.right;
                StartCoroutine(ActionTaken(0.075f));
                position += Vector2.right;
                rb.MovePosition(position);
                gm.Roll();
                gm.MoveEnemies();
                lowerVASCooldowns();
            }
        }
        else if (vas.selectState > 0)
        {
            lookDirection = Vector2.right;
        }
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (canMove == CAN_MOVE)
        {
            LayerMask mask = 49344;
            Vector2 position = rb.position;
            RaycastHit2D ray = Physics2D.Raycast(position, Vector2.left, 1.4f, mask);
            
            if (ray.collider == null)
            {
                roll.Play();
                lookDirection = Vector2.left;
                StartCoroutine(ActionTaken(0.075f));
                position += Vector2.left;
                rb.MovePosition(position);
                gm.Roll();
                gm.MoveEnemies();
                lowerVASCooldowns();
            }
        }
        else if (vas.selectState > 0)
        {
            lookDirection = Vector2.left;
        }
    }

    public void Die()
    {
        gm.Lose();
        Destroy(gameObject);
    }

    public IEnumerator ActionTaken(float time)
    {
        canMove = DISABLED;
        yield return new WaitForSeconds(time);
        canMove = CAN_MOVE;
    }

    private void lowerVASCooldowns()
    {
        if (vas.ability1Cooldown != 0)
        {
            vas.ability1Cooldown--;
        }
        if (vas.ability2Cooldown != 0)
        {
            vas.ability2Cooldown--;
        }
        if (vas.ability3Cooldown != 0)
        {
            vas.ability3Cooldown--;
        }
        if (vas.ability4Cooldown != 0)
        {
            vas.ability4Cooldown--;
        }
    }
}
