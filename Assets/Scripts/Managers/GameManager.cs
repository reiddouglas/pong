using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
        }else
        {
            _Instance = this;
        }
    }

    public Ball ball;
    public PlayerOne p1;
    public PlayerTwo p2;

    private Vector2 ballStartPos;
    private Vector2 p1StartPos;
    private Vector2 p2StartPos;

    private Vector2 ballStartSpeed;

    private void Start()
    {
        ball = GameObject.FindFirstObjectByType<Ball>();
        p1 = GameObject.FindFirstObjectByType<PlayerOne>();
        p2 = GameObject.FindFirstObjectByType<PlayerTwo>();

        ballStartPos = ball.transform.position;
        p1StartPos = p1.transform.position;
        p2StartPos = p2.transform.position;

        ballStartSpeed = ball.speed;

        ScoreManager.Instance.ResetScores();
    }

    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreChanged += ResetRound;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= ResetRound;
    }

    public void ResetRound(int[] scores)
    {
        StartCoroutine(ResetRoundCoroutine());
    }

    private IEnumerator ResetRoundCoroutine()
    {
        ball.speed = Vector2.zero;

        ball.transform.position = ballStartPos;
        p1.transform.position = p1StartPos;
        p2.transform.position = p2StartPos;

        float ball_rand_x = Mathf.Sign(Random.Range(-1, 1));
        float rand_angle = Random.Range(-30, 30);
        rand_angle = rand_angle * Mathf.Deg2Rad;

        ball.dir = new Vector2(Mathf.Cos(rand_angle) * ball_rand_x, Mathf.Sin(rand_angle));

        // wait a few seconds
        yield return new WaitForSeconds(2f);

        ball.speed = ballStartSpeed;
    }
}
