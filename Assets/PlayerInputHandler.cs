using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] Creature playerCreature;

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
        {
            input.y += -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            input.y += 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            input.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }

        playerCreature.Movement(input);
    }
}
