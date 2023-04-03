using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class HorizontalMovement : MonoBehaviour
{
    public TMP_Text GearUI;
    public TMP_Text CooldownUI;

    public float Velocity = 200f;
    public int Gear = 1;
    public int GearMax = 5;
    public float GearDelay = 3f;
    private float GearCooldown = 0f;
    private bool Delay = false;
    public Rigidbody2D rb;

    void Start()
    {
        GearUI.text = Gear.ToString();
        CooldownUI.text = GearCooldown.ToString();
    }

    void Update()
    {
        //Checks and updates delay
        if (Delay)
        {
            GearCooldown -= 1 * Time.deltaTime;
            CooldownUI.text = GearCooldown.ToString("0.0");
            if (GearCooldown <= 0)
            {
                Delay = false;
                GearCooldown = 0;
            }
            CooldownUI.text = GearCooldown.ToString("0.0");
        }

        //Gearshift
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!Delay && Gear < GearMax)
            {
                Gear += 1;
                Delay = true;
                GearCooldown = GearDelay;
                GearUI.text = Gear.ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Delay && 1 < Gear)
            {
                Gear -= 1;
                Delay = true;
                GearCooldown = GearDelay;
                GearUI.text = Gear.ToString();
            }
        }
    }

    void FixedUpdate()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, 300));
        }

        //Calculaes and adds forward force
        rb.AddForce(new Vector2(Velocity * Gear * Time.deltaTime, 0));
    }
}
