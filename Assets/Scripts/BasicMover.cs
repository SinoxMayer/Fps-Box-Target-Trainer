using UnityEngine;

public class BasicMover : MonoBehaviour
{
  [SerializeField]private float spinSpeed = 180.0f;
  [SerializeField]private float motionMagnitude = 0.1f;

  [SerializeField] private bool doSpin = true;
  [SerializeField] private bool doMotion = true;
    
    // Update is called once per frame
    void Update()
    {
        if (doSpin)
        {
            gameObject.transform.Rotate(Vector3.up * (spinSpeed * Time.deltaTime));
        }


        if (doMotion)
        {
            //objeyi mathf.cos ile aşa yukarı oynattım.
            gameObject.transform.Translate(Vector3.up * (Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude));

        }
       
    }
}
