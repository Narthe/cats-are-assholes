using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    
    private bool _isMoving = false;
    private Vector3 _targetDirection = Vector3.zero;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        if (_isMoving)
        {
            Move();
        }
            
    }

    private void Move()
    {
        Vector2 movement = transform.up  * speed * Time.deltaTime;
        transform.position += _targetDirection * speed * Time.deltaTime;
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
    
}
