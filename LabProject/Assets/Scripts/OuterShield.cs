using UnityEngine;

public class OuterShield : MonoBehaviour
{
    
    private GoalsManager _goalsManager;

    private void Start()
    {
        _goalsManager = GoalsManager.GM;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            _goalsManager.message = "The object that you threw has been destroyed. It went outside the boundaries.";
            BallSpawner.IsBallInPlay = false;
            _goalsManager.CleanMessages();
            Destroy(other.gameObject);

            for (int i = 0; i < _goalsManager.leftGoals.Length; i++)
            {
                _goalsManager.leftGoals[i].SetActive(false);
                _goalsManager.rightGoals[i].SetActive(false);
            }
        }
    }

    
}
