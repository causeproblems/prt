using UnityEngine;
using UnityEngine.SceneManagement;


public class Door1 : MonoBehaviour
{
    private bool isTouch;
    public int room;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (isTouch && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(room);

        }
    }

    public void OnTriggerEnter2D(Collider2D boxCollider)
    {
        if (boxCollider.tag == "Player")
        {
            isTouch = true;
            anim.SetBool("isTouch", true);
        }
    }

    public void OnTriggerExit2D(Collider2D boxCollider)
    {
        if (boxCollider.tag == "Player")
        {
            isTouch = false;
            anim.SetBool("isTouch", false);
        }
    }

}
