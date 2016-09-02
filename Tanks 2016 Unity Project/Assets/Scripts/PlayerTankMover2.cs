using UnityEngine;

public class PlayerTankMover2 : MonoBehaviour
{
    //public int PlayerNum = 2;
    public float Speed = 12f;
    public float TurnSpeed = 180f;

    private string MovementAxisName;
    private string TurnAxisName;
    private Rigidbody RBody;
    private float MovementInputVal;
    private float TurnInputVal;

    private void Awake()
    {
        RBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        RBody.isKinematic = false;

        MovementInputVal = 0f;
        TurnInputVal = 0f;
    }

    private void OnDisable()
    {
        RBody.isKinematic = true;

        MovementInputVal = 0f;
        TurnInputVal = 0f;
    }

    private void Start()
    {
        MovementAxisName = "2LVert";
        TurnAxisName = "2LHorz";
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Update()
    {
        MovementInputVal = Input.GetAxis(MovementAxisName);
        TurnInputVal = Input.GetAxis(TurnAxisName);
    }

    private void Move()
    {
        Vector3 movement = transform.forward * MovementInputVal * Speed * Time.deltaTime;

        RBody.MovePosition(RBody.position + movement);
    }

    private void Turn()
    {
        float turn = TurnInputVal * TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        RBody.MoveRotation(RBody.rotation * turnRotation);
    }
}