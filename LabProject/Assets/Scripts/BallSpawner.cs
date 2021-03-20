using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public static bool IsBallInPlay;
    GoalsManager _goalsManager;
    private void Start()
    {
        _goalsManager = GoalsManager.GM;
        StartCoroutine(nameof(SpawnBall));
    }

    IEnumerator SpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            while (!IsBallInPlay)
            {
                GameObject leftGoal = _goalsManager.leftGoals[Random.Range(0, _goalsManager.leftGoals.Length)];
                leftGoal.SetActive(true);
                GameObject rightGoal = _goalsManager.rightGoals[Random.Range(0, _goalsManager.rightGoals.Length)];
                rightGoal.SetActive(true);
                Instantiate(ballPrefab, transform.position, Quaternion.identity);
                IsBallInPlay = true;
            }
        }
    }
}
