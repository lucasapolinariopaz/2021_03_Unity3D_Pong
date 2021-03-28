using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Ball : MonoBehaviour {

    [SerializeField]
    private float m_Speed;
    [SerializeField]
    private float m_MaxSpeed;
    [SerializeField]
    private float m_SpeedIncBy;

    private Rigidbody2D m_Rigidbody2D;
    private Vector2 m_Velocity;

    private float m_InitialSpeed;
    private Vector3 m_InitialPosition;

    // Use this for initialization
    void Start () {

        Random.InitState((int)System.DateTime.Now.Ticks);

        m_Velocity = m_Speed * (Random.Range(0, 100) < 50 ? Vector2.left : Vector2.right);

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = m_Velocity;

        m_InitialSpeed = m_Speed;
        m_InitialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
