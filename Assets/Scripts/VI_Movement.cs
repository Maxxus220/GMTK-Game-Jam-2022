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

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputSys = GetComponent<PlayerInput>();
        moveUpAction = inputSys.actions["MoveUp"];
        moveDownAction = inputSys.actions["MoveDown"];
        moveLeftAction = inputSys.actions["MoveLeft"];
        moveRightAction = inputSys.actions["MoveRight"];
        moveUpAction.performed += MoveUp;
        moveDownAction.performed += MoveDown;
        moveRightAction.performed += MoveRight;
        moveLeftAction.performed += MoveLeft;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        LayerMask mask = LayerMask.GetMask("Structure");
        Vector2 position = rb.position;
        RaycastHit2D ray = Physics2D.Raycast(position, Vector2.up, 1f, mask);
        if(ray.collider == null)
        {
            position += Vector2.up;
            rb.MovePosition(position);
        }
    }

    private void MoveDown(InputAction.CallbackContext context)
    {
        LayerMask mask = LayerMask.GetMask("Structure");
        Vector2 position = rb.position;
        RaycastHit2D ray = Physics2D.Raycast(position, Vector2.down, 1f, mask);
        if (ray.collider == null)
        {
            position += Vector2.down;
            rb.MovePosition(position);
        }
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        LayerMask mask = LayerMask.GetMask("Structure");
        Vector2 position = rb.position;
        RaycastHit2D ray = Physics2D.Raycast(position, Vector2.right, 1f, mask);
        if (ray.collider == null)
        {
            position += Vector2.right;
            rb.MovePosition(position);
        }
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        LayerMask mask = LayerMask.GetMask("Structure");
        Vector2 position = rb.position;
        RaycastHit2D ray = Physics2D.Raycast(position, Vector2.left, 1f, mask);
        if (ray.collider == null)
        {
            position += Vector2.left;
            rb.MovePosition(position);
        }
    }
}
