using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private float _speed = 1f;

    private float _distance = 0f;
    private bool _isMoving = false;
    private Vector3 _targetDirection = Vector3.zero;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        if (_isMoving)
            Move();
    }

    private void Move()
    {
        Vector2 movement = transform.up  * _speed * Time.deltaTime;
        transform.position += _targetDirection * _speed * Time.deltaTime;
    }

    //Setter
    public void SetMoving(bool isMoving)
    {
        _isMoving = isMoving;
    }

    public void SetDirection(Vector3 target)
    {
        _targetDirection = target;
    }

    public void SetSpeed(float distance)
    {
        _speed = distance / 100;
    }
}
