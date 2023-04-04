using UnityEngine;
//[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isMove;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    // [SerializeField] Transform posFirst;
    [SerializeField] LayerMask layerPlayer;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private MeshRenderer hairPlayer;


    private GameObject firstBrick;
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    private float additionHeight;
    public int _cubeListIndexCounter = 0;
    
    private void Awake()
    {
        int rd = Random.Range(0, ColorManager.instance.typeColor.newMat.Length);
        hairPlayer.material = ColorManager.instance.typeColor.newMat[rd];
        GameController.Instance.typeColorPlayer = rd;
    }
    private void FixedUpdate()
    {
        HandleInput();
        check();
        Movement();

    }
    private void HandleInput()
    {
        moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;
    }
    void Movement()
    {

        if ((_joystick.Horizontal != 0 || _joystick.Vertical != 0) && isMove)
        {
            var pos = _rigidbody.velocity;
            pos.y = 0f;

            transform.rotation = Quaternion.LookRotation(pos);
            _animator.SetBool("fowardSpeed", true);
        }
        else
        {
            _animator.SetBool("fowardSpeed", false);
        }

        if (isMove)
        {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        }
        else if (!isMove)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
    void check()
    {
        if (Physics.Raycast(transform.position + moveDirection + Vector3.up * 1f, Vector3.down, Mathf.Infinity, layerPlayer))
        {
            isMove = true;
            //Debug.DrawRay(posFirst.position, Vector3.down, Color.red);
        }
        else
        {
            isMove = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Brick") && other.GetComponent<Brick>().typeColorBrick == GameController.Instance.typeColorPlayer)
        {
            var lBrick = GameController.Instance.listBrick;
            lBrick.Add(other.gameObject);
            if (lBrick.Count == 1)
            {
                firstBrick = other.gameObject;
                var pos = GetComponent<MeshRenderer>().bounds.max;
                pos.y += 1.9f;
                _firstCubePos = pos;

                _currentCubePos = new Vector3(other.transform.position.x, _firstCubePos.y, other.transform.position.z);
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Brick>().UpdateCubePosition(transform, true);
            }
            else if (lBrick.Count > 1)
            {
                additionHeight += 0.1f;
                other.gameObject.transform.position = new Vector3(firstBrick.transform.position.x, firstBrick.transform.position.y + additionHeight, firstBrick.transform.position.z);
                other.gameObject.GetComponent<Brick>().UpdateCubePosition(lBrick[_cubeListIndexCounter].transform, true);
                _cubeListIndexCounter++;
            }
        }
    }
}
