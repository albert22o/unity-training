using UnityEngine;
using UnityEngine.EventSystems;

public class sphere : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Arrow arrow;
    [SerializeField] KickController kickController;
    private float velocityThreshold = 3f;

    void Update()
    {
        if (IsStationary())
        {
            arrow.Set_active(true);
        }
        else
        {
            arrow.Set_active(false);
        }
        if (IsStationary() && Input.GetMouseButtonDown(0)) 
        {
            rb.AddForce(arrow._direction * kickController.Force, ForceMode.Impulse);
        }
    }
    bool IsStationary()
    {
        // ѕровер€ем линейную и угловую скорость
        return rb.linearVelocity.magnitude < velocityThreshold &&
               rb.angularVelocity.magnitude < velocityThreshold;
       
    }
}
