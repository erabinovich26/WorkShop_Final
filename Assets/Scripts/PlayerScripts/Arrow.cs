using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 25f;
    public float radius = .2f;

    Vector3 direction;
    float remainingDistance;
    
   

    public void Launch(Vector3 shotDirection, float distance)
    {
        direction = shotDirection;
        remainingDistance = distance;
        transform.forward = direction;
    }
    
    void Update()
    {
        float step = Mathf.Min(speed * Time.deltaTime, remainingDistance);

        if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit, step, ~0, QueryTriggerInteraction.Ignore))   //hit logic. the sphere cast is checking to see if it collided with anything, and if it did the if statement is true, and it returns (hit). if it isnt true which is most of the time it moves onto the rest of the code.
        {
            transform.position += direction * hit.distance;
            End();
            return;
        }

        transform.position += direction * step; 
        remainingDistance -= step;

        if (remainingDistance <= 0)   //this will trigger if the arrow doesnt end up hitting anything, but instead just reaches its max distance. 
        {
            End();
        }
    }

    void End()
    {
        //
        Destroy(gameObject);
    }
}
