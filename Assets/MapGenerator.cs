using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    public Transform cubeParent;
    public Cube baseItem;
    public GameObject jewel;
    public int makeCount = 20;

    private void Awake()
    {
        GenerateCubes();
    }

    // 랜덤하게 큐브 생성 시키자.
    [ContextMenu("큐브 생성")]
    private void GenerateCubes()
    {
        // 기존 블럭 부스자.
        DestroyExistCube();

        Vector3 previousPos = Vector3.zero;
        for (int i = 0; i < makeCount; i++)
        {
            var neweCube = Instantiate(baseItem, cubeParent);
            neweCube.transform.localRotation = Quaternion.identity;

            // previousPos의 x나 z를 1 증가하자.
            if (Random.Range(0, 2) == 0)
                previousPos += new Vector3(1, 0, 0);
            else
                previousPos += new Vector3(0, 0, 1);

            neweCube.transform.localPosition = previousPos;
            previousPos = neweCube.transform.localPosition;

            if (Random.Range(0, 2) == 0)
            {
                //보석 배치 하자.
                var neweJewel = Instantiate(jewel);


                neweJewel.transform.position = neweCube.transform.position;
                float addY = neweCube.transform.lossyScale.y * 0.5f;
                neweJewel.transform.Translate(0, addY, 0, Space.World);
            }
        }
    }

    private void DestroyExistCube()
    {
        var allCube = cubeParent.GetComponentsInChildren<Cube>();
        foreach (var item in allCube)
            DestroyImmediate(item.gameObject);
    }
}
