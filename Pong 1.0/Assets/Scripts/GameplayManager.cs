using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour {

    // Singleton.
    private static GameplayManager s_Instance = null;

    private int[] m_Score;
    private bool m_IsGameOver;

    [Header("Game")]
    [SerializeField] private GameObject m_GameGroup;

    [Header("Score")]
    [SerializeField] private UnityEngine.UI.Text[] m_UITextScore = new UnityEngine.UI.Text[2];
    [SerializeField] private int m_EndGameScore;

    [Header("Game Over")]
    [SerializeField] private GameObject m_GameOverGroup;
    [SerializeField] private UnityEngine.UI.Text m_UITextWinner;

    // Use this for initialization
    void Start () {

        m_Score = new int[2];
        ResetScore();
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || m_IsGameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void SetGameOver(bool isGameOver)
    {
        m_IsGameOver = isGameOver;
        m_GameGroup.SetActive(!m_IsGameOver);
        m_GameOverGroup.SetActive(m_IsGameOver);
    }

    public void ResetScore()
    {
        m_Score[0] = 0;
        m_Score[1] = 0;
        SetGameOver(false);
        m_UITextScore[0].text = m_Score[0].ToString();
        m_UITextScore[1].text = m_Score[1].ToString();
    }

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

    public PlayerType GetWinner()
    {
        return m_Score[0] > m_Score[1] ? PlayerType.P1 : PlayerType.P2;
    }

    private void GameOver()
    {
        m_UITextWinner.text = "JOGADOR " + ((int)GetWinner() + 1) + " GANHOU!";
        SetGameOver(true);
    }

    public void IncScore(PlayerType player)
    {
        int index = (int)player;
        ++m_Score[index];
        m_UITextScore[index].text = m_Score[index].ToString();

        if (m_Score[(int)player] == m_EndGameScore)
        {
            GameOver();
        }
    }

    public int GetScore(PlayerType player)
    {
        return m_Score[(int)player];
    }
}
