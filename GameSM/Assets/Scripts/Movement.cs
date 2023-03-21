using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private bool isMove;

    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    public int _cubeListIndexCounter = 0;
    public Text textScore;
    //private int _cubeListIndexCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft && !isMove)
        {
            isMove = true;
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight && !isMove)
        {
            isMove = true;
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp && !isMove)
        {
            isMove = true;
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown && !isMove)
        {
            isMove = true;
            rb.velocity = Vector3.forward * -speed * Time.deltaTime;
        }
        if (rb.velocity == Vector3.zero)
        {
            isMove = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            var lBrick = GameController.Instance.listBrick;
            lBrick.Add(other.gameObject);
            textScore.text = "Score: " + _cubeListIndexCounter.ToString();
            if (lBrick.Count == 1)
            {
                var pos = GetComponent<MeshRenderer>().bounds.max;
                pos.y += 1.9f;
                _firstCubePos = pos;
                _firstCubePos = GetComponent<MeshRenderer>().bounds.max;
                _currentCubePos = new Vector3(other.transform.position.x, _firstCubePos.y, other.transform.position.z);
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Brick>().UpdateCubePosition(transform, true);
            }
            else if (lBrick.Count > 1)
            {
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Brick>().UpdateCubePosition(lBrick[_cubeListIndexCounter].transform, true);
                _cubeListIndexCounter++;
            }
        }
        if (other.CompareTag("Respawn"))
        {
            _cubeListIndexCounter--;
        }
        if (other.CompareTag("Finish"))
        {

        }
    }
}
