using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public GameObject MistakeCross;
    public GameObject HitStar;
    Vector3 Dir;
    Vector3 directionOffset;
    Quaternion MoveDirection;

    Vector3 SpawnPosition;

    Vector3 position;
    Animator anim;

    public float moveSpeed;
    float currentmoveSpeed;
    public Vector3 force = Vector3.zero;

    void Start()
    {
        //Move();
        SpawnPosition = transform.position;

        anim = gameObject.GetComponent<Animator>();

        Dir = Vector3.zero - transform.position;
        Dir = Dir.normalized * 5;
        MoveDirection = Quaternion.LookRotation(Dir);

        Vector3 euler = MoveDirection.eulerAngles;
        euler.y += Random.Range(-15f, 15f);
        transform.eulerAngles = euler;
    }

    void Update()
    {
        AddBombForce();

        transform.Translate(Vector3.forward * Time.deltaTime * currentmoveSpeed);

        if (Vector3.Distance(transform.position, SpawnPosition) > 6f)
        {
            Destroy(this.gameObject);
            FindObjectOfType<UiScript>().AddPoints();
        }
    }

    public void AddBombForce()
    {
            Vector3 velocity = force * Time.deltaTime * 7;
            position = velocity;
            force *= 0.92f;
            transform.localPosition += position;
    }
    
    public void DestroyBoat()
    {
        Destroy(this.gameObject);
    }

    public void DontMove()
    {
        currentmoveSpeed = 0f;
    }

    public void Move()
    {
        currentmoveSpeed = moveSpeed;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Boat")
        {
            moveSpeed = 0f;
            force = Vector3.zero;
            anim.SetTrigger("BoatCollide");
            

            coll.gameObject.GetComponent<BoatScript>().enabled = false;
            if (this.gameObject.GetComponent<BoatScript>().enabled == true)
            {
            Instantiate(MistakeCross, new Vector3((this.transform.position.x + coll.transform.position.x) / 2, 0.4f, (this.transform.position.z + coll.transform.position.z) / 2), Quaternion.LookRotation(Camera.main.transform.position, Vector3.up));
                Instantiate(HitStar, (new Vector3((this.transform.position.x + coll.transform.position.x) / 2, 0.1f, (this.transform.position.z + coll.transform.position.z) / 2)), Quaternion.identity);
                FindObjectOfType<UiScript>().AddMistake();
            }
        }
    }
}

