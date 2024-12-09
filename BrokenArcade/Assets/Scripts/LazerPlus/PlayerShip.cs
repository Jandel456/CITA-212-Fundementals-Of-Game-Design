using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerShip : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float paddingleft;
    [SerializeField] float paddingright;
    [SerializeField] float paddingtop;
    [SerializeField] float paddingbottom;

    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2(); // allows us to account for boundries of player movement.
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingleft, maxBounds.x - paddingright);       // this is what restricts us from moving beyond the screen horizontally
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingbottom, maxBounds.y - paddingtop);       // this is what restricts us from moving beyond the screen vertically
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
