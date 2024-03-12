using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool walkingRight = true;
    private Animator anim;

    [SerializeField]private float speed = 2f;
    [SerializeField]private Transform rayStart;
    [SerializeField]private GameObject crystalEffect;
    [SerializeField] private Transform deathZone;

	private void Start()
	{
		StartCoroutine(IncreaseSpeed());   
	}

	void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            //movement
            rb.transform.position = transform.position + transform.forward * speed * Time.deltaTime;
            anim.SetTrigger("gameStarted");

            //switch direction
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchDirection();
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
            {
                SwitchDirection();
            }

            // check if we are falling
            RaycastHit hit;
            if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
            {
                anim.SetTrigger("falling");
                rb.useGravity = true;
            }
            else
            {
				anim.SetTrigger("notFalling");
			}

            //end Game
            if(transform.position.y < -10)
            {
                GameManager.instance.EndGame();   
            }
        }
        else
        {
            return;
        }
    }

    private void SwitchDirection()
    {
        walkingRight = !walkingRight;
        if(walkingRight)
        {
            transform.rotation = Quaternion.Euler( 0, 45, 0 );
        }
        else
        {
			transform.rotation = Quaternion.Euler(0, -45, 0);
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Crystal")
        {
            Destroy(other.gameObject);
            GameManager.instance.IncreaseScore();
            GameObject effect = Instantiate(crystalEffect, other.transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }

        if (other.transform.position.z < deathZone.transform.position.z)
        {
            Destroy(other.gameObject);
        }
	}

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            speed += .20f;
        }
    }
}
