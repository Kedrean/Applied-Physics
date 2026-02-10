using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float speed = 4f;

    private Animator animator;
    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller || !controller.enabled) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        move = Vector3.ClampMagnitude(move, 1f);

        controller.SimpleMove(move * speed);

        animator.SetFloat("MoveX", h);
        animator.SetFloat("MoveZ", v);
        animator.SetFloat("Speed", move.magnitude);
    }
}
