using UnityEngine;
using System.Collections;

public class KnifeController : MonoBehaviour
{
    public float stabDistance = 0.5f;  // How far the knife moves forward during the stab
    public float stabSpeed = 10f;      // Speed of the stabbing motion
    public float rotationSpeed = 10f;  // Speed of the rotation before/after the stab
    public float attackRange = 2f;     // Maximum range for the hit detection raycast
    public int damage = 10;

    // Add this line to reference the knife tip
    public Transform knifeTip;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isStabbing;

    private EnemyHealth enemy;

    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isStabbing)
        {
            StartCoroutine(StabKnife());
        }
    }

    private IEnumerator StabKnife()
    {
        isStabbing = true;

        // Step 1: Rotate the knife to a stabbing position
        float time = 0f;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0f, 0f, 66f); // Adjust the angle as needed
        while (time < 1f)
        {
            time += Time.deltaTime * rotationSpeed;
            transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, time);
            yield return null;
        }

        // Step 2: Move forward for the stab
        time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * stabSpeed;
            float stabOffset = Mathf.Lerp(0f, stabDistance, time);
            transform.localPosition = initialPosition + new Vector3(0f, 0f, stabOffset);
            yield return null;
        }

        // Step 3: Perform hit detection from the knife tip
        //PerformHitDetection();

        // Step 4: Return to initial position
        time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * stabSpeed;
            float stabOffset = Mathf.Lerp(stabDistance, 0f, time);
            transform.localPosition = initialPosition + new Vector3(0f, 0f, stabOffset);
            yield return null;
        }

        // Step 5: Rotate back to the initial rotation
        time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * rotationSpeed;
            transform.localRotation = Quaternion.Slerp(targetRotation, initialRotation, time);
            yield return null;
        }

        isStabbing = false;
    }

    /*private void PerformHitDetection()
    {
        RaycastHit hit;
        // Use the knifeTip's position and forward direction for the raycast.
        Vector3 rayStart = knifeTip.position;
        
        // Draw a debug ray to see where it's going (visible in Scene View)
        Debug.DrawRay(rayStart, knifeTip.forward * attackRange, Color.red, 1.0f);

        if (Physics.Raycast(rayStart, knifeTip.forward, out hit, attackRange))
        {
            Debug.Log("Hit: " + hit.collider.name);
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Enemy took damage!");
            }
            else
            {
                Debug.Log("Hit something, but it's not an enemy.");
            }
        }
        else
        {
            Debug.Log("Missed!");
        }
    }*/


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyHealth>();
            Debug.Log("Enemy hit");
            if (isStabbing)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
