using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    void LateUpdate()
    {
        if (target != null)
        {
            if (target.position.x > -0.4)
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}
