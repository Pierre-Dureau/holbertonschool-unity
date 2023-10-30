using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform player;
    private readonly float rotationSpeed = 3.0f;
    private float currentRotationX = 0;
    private float currentRotationY = 0;
    private float horizontalInput;
    private float verticalInput;

    private Vector3 cameraStartPosition;

    public bool isInverted;

    void Start() {
        cameraStartPosition = transform.localPosition;
        cameraStartPosition.y -= 1.25f; // La taille du joueur
        transform.rotation = transform.localRotation;

        isInverted = PlayerPrefs.GetInt("yAxis") == 1;
    }

    void LateUpdate() {
        // Obtiens l'entr�e de la souris pour effectuer une rotation de la cam�ra
        if (!isInverted)
        {
            horizontalInput = Input.GetAxis("Mouse X");
            verticalInput = Input.GetAxis("Mouse Y");
        } else
        {
            horizontalInput = -Input.GetAxis("Mouse X");
            verticalInput = -Input.GetAxis("Mouse Y");
        }

        currentRotationX -= verticalInput * rotationSpeed;
        currentRotationX = Mathf.Clamp(currentRotationX, -10f, 60f); // Hauteur min et max de la cam�ra

        currentRotationY += horizontalInput * rotationSpeed;

        // Calcul la rotation de la cam�ra autour du joueur
        Quaternion rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);

        // Calcul la position de la cam�ra par rapport au joueur
        Vector3 newPosition = player.position + (rotation * cameraStartPosition);

        // D�place la cam�ra vers la nouvelle position
        transform.position = newPosition;

        // Assure que la cam�ra regarde toujours le joueur
        transform.LookAt(player);

        // Rotation du joueur pour faire face � la direction de la cam�ra
        player.rotation = Quaternion.Euler(0, currentRotationY, 0);
    }
}