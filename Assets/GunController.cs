
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{

    public InputActionReference trigger;
    public GameObject projectile;
    public GameObject gunTip;
    public GameObject world;

    private void HandleTrigger(InputAction.CallbackContext ctx)
    {
        var bullet = Instantiate(projectile, gunTip.transform.position, gunTip.transform.rotation * Quaternion.Euler(Vector3.forward * 90), world.transform);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.right.normalized * 50, ForceMode.VelocityChange);
    }

    private void Awake()
    {
        trigger.action.started += HandleTrigger;
    }

    private void OnDestroy()
    {
        trigger.action.started -= HandleTrigger;
    }
}
