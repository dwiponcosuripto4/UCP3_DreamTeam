using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public Transform ball; 
    public float speed = 5f; 
    public float decisionInterval = 2f;

    private bool followBall = true; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeBehaviorRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (followBall)
        {
            if (ball.localPosition.z <= 6.0f && ball.localPosition.z >= -6.0f)
            {
                float step = speed * Time.deltaTime; 
                Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, ball.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
        }
        else
        {
            RandomIdleMovement();
        }
    }

    private IEnumerator ChangeBehaviorRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(decisionInterval);

            followBall = Random.value > 0.5f; 
        }
    }

    // Fungsi untuk gerakan idle saat tidak mengikuti bola
    private void RandomIdleMovement()
    {
        float step = speed * 0.5f * Time.deltaTime; 
        float randomZ = Mathf.PingPong(Time.time, 12f) - 6f; 
        Vector3 idlePosition = new Vector3(transform.position.x, transform.position.y, randomZ);
        transform.position = Vector3.MoveTowards(transform.position, idlePosition, step);
    }
}
