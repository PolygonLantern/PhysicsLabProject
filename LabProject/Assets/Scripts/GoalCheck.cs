using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    private GoalsManager _goalsManager;

    private void Start()
    {
        _goalsManager = GoalsManager.GM;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            
            ++ScoreManager.Score;
            
            _goalsManager.message = "You scored! Good Job!";
            _goalsManager.CleanMessages();
            
            BallSpawner.IsBallInPlay = false;

            if (transform.parent.CompareTag("LeftGoal"))
            {
                for (int i = 0; i < _goalsManager.rightGoals.Length; i++)
                {
                    _goalsManager.rightGoals[i].SetActive(false);
                }
            }
            else if(transform.parent.CompareTag("RightGoal"))
            {
                for (int i = 0; i < _goalsManager.leftGoals.Length; i++)
                {
                    _goalsManager.leftGoals[i].SetActive(false);
                }
            }
        
            gameObject.SetActive(false);
        }
        
    }
}
