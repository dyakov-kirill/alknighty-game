using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject Rock;
    public GameObject Player;

    private Rigidbody2D rb;
    private CircleCollider2D cc;
    private bool isEmpty = false;

    void Start()
    {
        rb = Rock.GetComponent<Rigidbody2D>();
        cc = Rock.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRock()
    {
        if (!isEmpty)
        {
            isEmpty = true;
            GameObject Copy = Instantiate(Rock);
            Copy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Copy.transform.position = new Vector3(Player.gameObject.transform.position.x+1, Player.gameObject.transform.position.y + 7);
            StartCoroutine(SetSafe(Copy, 3));
            }
    }

    IEnumerator SetSafe(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.tag = "Untagged";
        
    }
}
