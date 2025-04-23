using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference moveAction;
    public InputActionReference sprintAction;

    public Rigidbody2D rb;

    public bool isSprinting = false;

    public float movementSpeed = 3f;
    private float sprintingSpeed =  6f;
    public bool movementEnabled = true; //Variable pour empecher le personnage de se déplacer dans un menu


    Vector2 dir;

    private void OnEnable()
    {
        moveAction.action.performed += onMoveActionPerf;
        moveAction.action.canceled += onMoveActionCanceled;
        moveAction.action.Enable();

        sprintAction.action.performed += onSprintActionPerf;
        sprintAction.action.canceled += onSprintActionCanceled;
        sprintAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.performed -= onMoveActionPerf;
        moveAction.action.canceled -= onMoveActionCanceled;
        moveAction.action.Disable();

        sprintAction.action.performed -= onSprintActionPerf;
        sprintAction.action.canceled -= onSprintActionCanceled;
        sprintAction.action.Disable();
    }

    private void onSprintActionCanceled(InputAction.CallbackContext obj)
    {
        movementSpeed = 4f;
    }

    private void onSprintActionPerf(InputAction.CallbackContext obj)
    {
        movementSpeed = sprintingSpeed;
    }

    private void onMoveActionCanceled(InputAction.CallbackContext obj)
    {
        dir = Vector2.zero;
    }

    private void onMoveActionPerf(InputAction.CallbackContext obj)
    {
        dir = obj.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementEnabled) //Permet d'empecher le perso de bouger dans un menu
        {
            rb.MovePosition(rb.position + dir * movementSpeed * Time.fixedDeltaTime);
        }

    }
}
