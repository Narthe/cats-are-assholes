using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1F;
    public Text counterStr;
    private bool left = false;
    public Transform currentFurball;
    Rect LeftBounds = new Rect(0, 0, Screen.width / 2, Screen.height);

    //Swipe Gesture parameters
    public float MinSwipeInputLenght = 1f;
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private Vector3 _swipeDirectionWorld = Vector2.zero;
    private float _distanceSwipe = 0f;

    void OnGui()
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0,0,Color.green);
        GUI.Box(LeftBounds, texture);
    }

    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if (IsSwipping(touch))
            {
                currentFurball.GetComponent<Movement>().SetMovement(_swipeDirectionWorld, _distanceSwipe, transform.localScale.x);
            }
            else
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    // Get movement of the finger since last frame
                    //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    //Left - half of the screen.
                    if (LeftBounds.Contains(Input.GetTouch(0).position))
                    {
                        if (left)
                        {
                            int counter = int.Parse(counterStr.text);
                            counter++;
                            currentFurball.localScale += new Vector3(0.1F, 0.1F, 0.1F);
                            counterStr.text = counter.ToString();
                            left = !left;
                        }
                    }
                    else
                    {
                        if (!left)
                        {
                            int counter = int.Parse(counterStr.text);
                            counter++;
                            currentFurball.localScale += new Vector3(0.1F, 0.1F, 0.1F);
                            counterStr.text = counter.ToString();
                            left = !left;
                        }
                    }
                    // Move object across XY plane
                    //transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
                }
            }
        }
    }

    /// <summary>
    /// This function check if the user is swipping with a minimum public parameters : MinSwipeInputLenght
    /// </summary>
    /// <param name="touch">This parameter recovers the current touch on the screen</param>
    /// <returns>This Function returns boolean</returns>
    private bool IsSwipping(Touch touch)
    {
        Vector2 m_startWorldPoint = Vector2.zero;
        Vector2 m_endWorldPoint = Vector2.zero;

        if(touch.phase == TouchPhase.Began)
        {
            _startPosition = touch.position;
            _endPosition = touch.position;

            m_startWorldPoint = Camera.main.ScreenToWorldPoint(_startPosition);
            
        }

        if (touch.phase == TouchPhase.Moved)
            _endPosition = new Vector2(touch.position.x, touch.position.y);

        if(touch.phase == TouchPhase.Ended)
        {
            //Check if the swipe distance is ok 
            if(Vector2.Distance(_startPosition, _endPosition) / 10f > MinSwipeInputLenght)
            {
                m_endWorldPoint = Camera.main.ScreenToWorldPoint(_endPosition);
                
                _swipeDirectionWorld = m_endWorldPoint - m_startWorldPoint;
                _distanceSwipe = Vector2.Distance(m_startWorldPoint, m_endWorldPoint);
                return true;
            }
        }
        return false;
    }
}