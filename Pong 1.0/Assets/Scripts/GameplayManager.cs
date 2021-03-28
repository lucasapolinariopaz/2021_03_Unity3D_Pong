using UnityEngine;

public class GameplayManager : MonoBehaviour {

    // Singleton.
    private static GameplayManager s_Instance = null;

    public static GameplayManager Instance
    {
        get { return s_Instance; }
    }

    void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else if (s_Instance != this)
            Destroy(gameObject);
    }

    public enum PlayerType
    {
        P1 = 0,
        P2
    }

    [SerializeField]
    private int m_EndGameScore;

    private int[] m_Score;

    private bool m_IsGameOver;

    // Use this for initialization
    void Start () {

        m_Score = new int[2];
        ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetScore()
    {
        m_Score[0] = 0;
        m_Score[1] = 0;

        m_IsGameOver = false;
    }

    public void IncScore(PlayerType player)
    {
        ++m_Score[(int)player];

        if (m_Score[(int)player] == m_EndGameScore)
        {
            GameOver();
        }
    }

    public int GetScore(PlayerType player)
    {
        return m_Score[(int)player];
    }

    public PlayerType GetWinner()
    {
        return m_Score[0] > m_Score[1] ? PlayerType.P1 : PlayerType.P2;
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Winner: " + GetWinner());
        m_IsGameOver = true;
    }
}
