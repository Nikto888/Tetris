using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Tooltip("Movement speed of object.")]
    public float MoveSpeed = 1f;
    [Tooltip("Color scaling factor.")]
    public float ColorScale = 1f;
    [Tooltip("Gradient color as object moves through space.")]
    public Gradient GradientColor;

    Renderer m_renderer;
    float GradientPosition;

    void Start()
    {
        m_renderer = this.GetComponent<Renderer>();
        GradientPosition = 0f;
    }

    void Update()
    {
        DoMove(GetMove() * MoveSpeed * Time.deltaTime);
        UpdateColor(transform.position);
    }

    public Vector3 GetMove()
    {
        Vector3 move; 
        if (Input.anyKey)
        {
            move = new Vector3(Input.GetAxisRaw("Axis_X"), Input.GetAxisRaw("Axis_Z"), Input.GetAxisRaw("Axis_Y"));
            move = Vector3.ClampMagnitude(move, 1f);
            return move;
        }
        move = Vector3.zero;
        return move;
    }

    public void DoMove(Vector3 move)
    {
        transform.Translate(move);
    }

    public void UpdateColor(Vector3 inputColor)
    {
        GradientPosition = Mathf.Pow(Mathf.Sin((inputColor.x + inputColor.y + inputColor.z) * ColorScale),2);
        m_renderer.material.SetColor("_Color",GradientColor.Evaluate(GradientPosition));
    }
}
