using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{

    private float _speed = 5;
    private float _direction;
    private float _directionSpeed = 180;

    private float _distanceBetweenBodySegments = 1.5f;
    public float _speedIncrice;
    public Rigidbody rb;

    [SerializeField]
    public List<GameObject> bodyPrefab;

    [SerializeField]
    public LandBuilder2 landBuilder2;

    public List<GameObject> body = new List<GameObject>();

    [SerializeField]
    public List<GameObject> heads;
    private GameObject snakeHead;
    public float headLocalScale;

    [SerializeField]
    public GameObject bodyDeathEffect;

    [SerializeField]
    public int _startBodyCount;

    [SerializeField]
    public UnityEvent _snakeCollideEvent;

    [SerializeField]
    private AudioManager _audioManager;

    private bool _canMove = false;
    public void SetCanMove(bool b) {
        _canMove = b;
    }
    public void CreateNewGame() {

        transform.position = new Vector3(10, 1, 10);
        transform.rotation = Quaternion.Euler(Vector3.zero);

        int headnumber = Random.Range(0, heads.Count);

        snakeHead = Instantiate(heads[headnumber], transform.position, Quaternion.identity);
        snakeHead.transform.parent = transform;
        snakeHead.transform.localScale = new Vector3(headLocalScale, headLocalScale, headLocalScale);

        for (int x = 0; x < _startBodyCount; x++) { AddBodySegment(); }
    }

    public void SetDirection(float _DIRECTION) {
        _direction = _DIRECTION;
    }

    public void FixedUpdate()
    {
        if (_canMove)
        {
           // _direction = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * _direction * _directionSpeed * Time.deltaTime);
            rb.velocity = transform.forward.normalized * _speed;

            MoveSnakeBody();
        }
        else rb.velocity = Vector3.zero;
    }
    public void MoveSnakeBody() {
        for (int i = 0; i < body.Count; i++)
        {
            if (i == 0) MoveBodySegment(this.gameObject, body[i]);
            else MoveBodySegment(body[i - 1], body[i]);
        }
    }
    public void RemoveBodySegment()
    {
        if (body.Count > 0) {
            Destroy(body[body.Count - 1]);
            body.Remove(body[body.Count - 1]);

            _audioManager.DestroyUnitSound();
        }
    }
    public void AddBodySegment() {
        int k = Random.Range(0, bodyPrefab.Count);
        body.Add(Instantiate(bodyPrefab[k], transform.position, Quaternion.identity));

        _audioManager.CreateUnitSound();
    }
    public void MoveBodySegment(GameObject _prevBodySegment, GameObject _bodySegment) {

        _bodySegment.transform.LookAt(_prevBodySegment.transform);

        if(Vector3.Distance(_prevBodySegment.transform.position, _bodySegment.transform.position) > _distanceBetweenBodySegments)
        _bodySegment.transform.position += _bodySegment.transform.forward * _speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            AddBodySegment();
            _speed+=_speedIncrice;
            _snakeCollideEvent.Invoke();
        }

        if (other.tag == "breaker") {
            RemoveBodySegment();
            _speed -= _speedIncrice;
            _snakeCollideEvent.Invoke();
        }
    }

    public void KillSnake() {

        Destroy(snakeHead);

        if (body.Count > 0)
        {
            foreach (var v in body) {
                Destroy(v);
            }

            body.Clear();
        }

    }
}
