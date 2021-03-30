using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Ball : MonoBehaviour {

    private Rigidbody2D m_Rigidbody2D;
    private Vector2 m_Velocity;

    private float m_InitialSpeed;
    private Vector3 m_InitialPosition;

    private AudioSource m_AudioSource;

    [SerializeField] private float m_Speed;
    [SerializeField] private float m_MaxSpeed;
    [SerializeField] private float m_SpeedIncBy;

    // Use this for initialization
    void Start () {

        Random.InitState((int)System.DateTime.Now.Ticks);

        m_Velocity = m_Speed * (Random.Range(0, 100) < 50 ? Vector2.left : Vector2.right);

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = m_Velocity;

        m_InitialSpeed = m_Speed;
        m_InitialPosition = transform.position;

        m_AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        m_AudioSource.Play();

        switch (other.gameObject.name)
        {
            case "PaddleP1":
                IncSpeed();
                UpdateVelocity(1.0f, GetHitYAxis(other));
                break;
            case "PaddleP2":
                IncSpeed();
                UpdateVelocity(-1.0f, GetHitYAxis(other));
                break;
            case "WallTop":
            case "WallBottom":
                UpdateVelocity(m_Velocity.x, -m_Velocity.y);
                break;
            case "WallLeft":
                GameplayManager.Instance.IncScore(GameplayManager.PlayerType.P2);
                ResetSpeed();
                UpdateVelocity(1.0f, 0.0f);
                transform.position = m_InitialPosition;
                break;
            case "WallRight":
                GameplayManager.Instance.IncScore(GameplayManager.PlayerType.P1);
                ResetSpeed();
                UpdateVelocity(-1.0f, 0.0f);
                transform.position = m_InitialPosition;
                break;
        }
    }

    private float GetHitYAxis(Collision2D paddle)
    {
        return (transform.position.y - paddle.transform.position.y) / paddle.collider.bounds.size.y;
    }

    private void ResetSpeed()
    {
        m_Speed = m_InitialSpeed;
    }

    private void IncSpeed()
    {
        m_Speed += m_SpeedIncBy;

        if(m_Speed > m_MaxSpeed)
        {
            m_Speed = m_MaxSpeed;
        }
    }

    private void UpdateVelocity(float x, float y)
    {
        m_Velocity.x = x;
        m_Velocity.y = y;
        m_Velocity = m_Velocity.normalized * m_Speed;

        m_Rigidbody2D.velocity = m_Velocity;
    }
}
