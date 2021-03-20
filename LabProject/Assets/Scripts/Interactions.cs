using UnityEngine;

public class Interactions : MonoBehaviour
{
    public Transform holder;
    public float throwForce;
    public bool carryingObject;
    public bool isThrowable;
    public float interactableRange;
    private GameObject item;
    private InputManager _inputManager;

    private void Start()
    {
        _inputManager = InputManager.Instance;
    }

    private void FixedUpdate()
    {
        if (_inputManager.hold)
        {
            RaycastHit hit;
            Ray directionRay = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(directionRay, out hit, interactableRange))
            {
                if (hit.collider.GetComponent<IInteractable>() != null)
                {
                    carryingObject = true;
                    isThrowable = true;
                    if (carryingObject)
                    {
                        item = hit.collider.gameObject;
                        item.transform.SetParent(holder);
                        item.GetComponent<Rigidbody>().isKinematic = true;
                        item.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }
        else
        {
            carryingObject = false;
            isThrowable = false;
        }

        if (carryingObject == false && item != null)
        {
            holder.DetachChildren();
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().useGravity = true;
        }
        
        if (_inputManager.attacked && isThrowable)
        {
            holder.DetachChildren();
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().AddRelativeForce( (Vector3.up + Vector3.forward) *throwForce);
        }

    }
}
