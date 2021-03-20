using System.Collections;
using UnityEngine;

public class GoalsManager : MonoBehaviour
{
    public static GoalsManager GM { get; private set; }
    public string message;
    
    
    public GameObject[] leftGoals;
    public GameObject[] rightGoals;

    private void Awake()
    {
        if (GM != null && GM != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GM = this;
        }

        message = "";
    }

    public void CleanMessages()
    {
        StartCoroutine(nameof(ClearMessage));
    }
    
    IEnumerator ClearMessage()
    {
        yield return new WaitForSeconds(5f);
        message = "";
    }
}
