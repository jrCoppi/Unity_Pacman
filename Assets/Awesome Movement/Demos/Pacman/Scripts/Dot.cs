using UnityEngine;
using System.Collections;

public class Dot : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.name == "Pacman")
            Destroy(gameObject);
    }
}