using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private GameObject player;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump_performed;
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
    
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.GetComponent<PlayerController>().Jump();
    }

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
    }
}
