using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private MeshRenderer hairPlayer;
    public Animator _animator;
    public int typeColorEnemy;
    public NavMeshAgent navMeshAgent;
    public State currentState;

    public FindBrickState findBrickState = new FindBrickState();
    public IdleState idleState = new IdleState();
    public BuildBrick buildState = new BuildBrick();

    private GameObject firstBrick;
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    private float additionHeight;
    public int _cubeListIndexCounter = 0;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        int rd = Random.Range(0, ColorManager.instance.typeColor.newMat.Length);
        hairPlayer.material = ColorManager.instance.typeColor.newMat[rd];
        typeColorEnemy = rd;
        GameController.Instance.typeColorEnemy = rd;
        currentState = findBrickState;
        currentState.OnEnter(this);
        //currentState.OnUpdate(this);
        StartCoroutine(changeStateFind());
    }


    // Update is called once per frame
    void Update()
    {
        CheckHair();
        if (currentState != null)
        {
            currentState.OnUpdate(this);
        }
        print("current state" + currentState);
        //GetComponent<NavMeshAgent>().Move(transform.forward * Time.deltaTime * 2f);
    }
    void CheckHair()
    {
        if (typeColorEnemy == GameController.Instance.typeColorPlayer)
        {
            int rd = Random.Range(0, ColorManager.instance.typeColor.newMat.Length);
            hairPlayer.material = ColorManager.instance.typeColor.newMat[rd];
            typeColorEnemy = rd;
        }
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
        currentState.OnEnter(this);
        currentState.OnUpdate(this);
        //currentState.OnExit(this);
    }
    IEnumerator changeStateIdle()
    {
        yield return new WaitForSeconds(5f);
        ChangeState(idleState);
        //currentState = idleState;
        StartCoroutine(changeStateFind());
    }
    IEnumerator changeStateFind()
    {
        yield return new WaitForSeconds(2f);
        ChangeState(findBrickState);
        //currentState = findBrickState;
        StartCoroutine(changeStateBuild());
    }
    IEnumerator changeStateBuild()
    {
        yield return new WaitForSeconds(10f);
        ChangeState(buildState);
        //currentState = buildState;
        StartCoroutine(changeStateIdle());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick") && other.GetComponent<Brick>().typeColorBrick == GameController.Instance.typeColorEnemy)
        {
            var lBrick = GameController.Instance.listBrickEnemy;
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
