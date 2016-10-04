using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Touch : MonoBehaviour
{
    public float speed = 0.1F;
    public Text counterStr;
    private bool left = false;
    public Transform furball;
    Rect LeftBounds = new Rect(0, 0, Screen.width / 2, Screen.height);

    void OnGui()
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0,0,Color.green);
        GUI.Box(LeftBounds, texture);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            // Get movement of the finger since last frame
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            //Left - half of the screen.
            if (LeftBounds.Contains(Input.GetTouch(0).position))
            {
                Debug.Log("Left!");
                if(left)
                {
                    int counter = int.Parse(counterStr.text);
                    counter++;
                    furball.localScale += new Vector3(0.1F, 0.1F, 0.1F);
                    counterStr.text = counter.ToString();
                    left = !left;
                }
            }
            else
            {
                Debug.Log("Right!");
                if (!left)
                {
                    int counter = int.Parse(counterStr.text);
                    counter++;
                    furball.localScale += new Vector3(0.1F, 0.1F, 0.1F);
                    counterStr.text = counter.ToString();
                    left = !left;
                }
            }
            // Move object across XY plane
            //transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        }
    }
}