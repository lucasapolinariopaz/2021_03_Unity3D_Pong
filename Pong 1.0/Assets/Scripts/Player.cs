using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour {

    [SerializeField]
    private string m_InputName;
    [SerializeField]
    private float m_Speed;

    private Rigidbody2D m_Rigidbody2D;
    private Vector2 m_Velocity;

	// Use this for initialization
	void Start () {

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Velocity = m_Rigidbody2D.velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        m_Velocity.y = Input.GetAxisRaw(m_InputName) * m_Speed;
        m_Rigidbody2D.velocity = m_Velocity;
	}
}
