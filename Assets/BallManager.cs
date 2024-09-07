using UnityEngine;
using UnityEngine.InputSystem; // For new Input System

public class BallManager : MonoBehaviour
{
    public BallPrefab ballPrefab;
    public int maxBalls = 10;

    private int ballCount = 0;
    private int ballsRemaining;

    void Start()
    {
        ballsRemaining = maxBalls;

        // Check if Touchscreen is detected
        if (Touchscreen.current == null)
        {
            Debug.LogError("No Touchscreen device detected!");
        }
        else
        {
            Debug.Log("Touchscreen device detected.");
        }
    }

    void Update()
    {

        // Handle touch input (for mobile)
        if (Touchscreen.current.press.isPressed)
        {
            Debug.Log("Touch detected");
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        BallPrefab ball = Instantiate<BallPrefab>(ballPrefab);
        ball.transform.localPosition = transform.position;

        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward *
            UnityEngine.Random.Range(500, 750));

        ballCount++;
        ballsRemaining--;
        Debug.Log("Balls Thrown: " + ballCount + "/" + maxBalls);
        Debug.Log("Balls Remaining: " + ballsRemaining);
    }
}
