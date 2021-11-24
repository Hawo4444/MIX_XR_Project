using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var pin = collision.gameObject.GetComponent<Pin>();
        if (pin != null)
        {
            pin.IsDown = true;
        }
    }
}
