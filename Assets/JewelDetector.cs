using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelDetector : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jewel") == false)
            return;

        Destroy(other.gameObject);
        transform.parent.GetComponent<Ball>().AddPoint(2);
    }
}
