using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private float _speed = 1f;
    private bool _isMoving = false;
    private Vector2 _targetDirection = Vector2.zero;
    private float _scale = 0f;

	void Start ()
    {
	    
	}
	
    void Update()
    {
        if (transform.localScale.x > _scale / 0.5 && _isMoving)
        {
            transform.localScale = new Vector3(transform.localScale.x - _speed * _scale / 3 * 7f * Time.deltaTime, transform.localScale.y - _speed * _scale / 3 * 7f * Time.deltaTime, transform.localScale.z);
            transform.position += (Vector3)_targetDirection * _speed * Time.deltaTime;
        }

        if (transform.localScale.x <= _scale / 0.5)
            _isMoving = false;
    }
    
    //Setter

    public void SetSpeed(float distance)
    {
        _speed = distance / 10;
    }

    public void SetMovement(Vector2 target, float distance, float currentScale)
    {
        _isMoving = true;
        _targetDirection = target;
        _scale = currentScale;
        SetSpeed(distance);
    }
}
