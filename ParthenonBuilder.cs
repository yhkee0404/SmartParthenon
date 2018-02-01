﻿using System;
using System.Linq;
using UnityEngine;

public class ParthenonBuilder : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public float floorWidth = 5.0f;
    public float floorDepth = 10.0f;
    public float floorHeight = 0.25f;
    public float pillarRadius = 0.2f;
    public float pillarHeight = 2.0f;
    public float pillarCountWidth = 6.0f;
    public float pillarCountDepth = 10.0f;
    public float roofHeight = 1.0f;
    public Material floorMaterial;
    public Material pillarMaterial;
    public Material roofMaterial;
    private float topFloorWidth;
    private float topFloorDepth;

    [ContextMenu("Build")]
    void Build()
    {
        DestroyAllChildren();
        BuildFloors();
        BuildPillars();
        BuildRoof();
        /*
        var tr = transform;
        var newGameObject = tr.gameObject;
        tr.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        tr.localScale = new Vector3(floorWidth, floorHeight, floorDepth);

        for (int i = 0; i < 3; i++)
        {
            newGameObject = Instantiate(cubePrefab, tr);
            tr = newGameObject.transform;
            tr.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
            tr.localScale = new Vector3(0.9f, 1.0f, 0.9f);
        }
        */
    }

    private void BuildRoof()
    {
        var roof = Instantiate(cubePrefab, transform);
        roof.transform.localPosition = new Vector3(0, floorHeight * 3 + pillarHeight, 0);
        roof.transform.localScale = new Vector3(topFloorWidth, roofHeight, topFloorDepth);
        roof.GetComponentInChildren<MeshRenderer>().material = roofMaterial;
    }

    private void BuildPillars()
    {
        BuildPillarsAlongXaxis();
        BuildPillarsAlongZaxis();
    }

    private void BuildPillarsAlongZaxis()
    {
        var pillarX0 = -topFloorWidth / 2 + pillarRadius;
        var pillarZ0 = -topFloorDepth / 2 + pillarRadius;
        var distanceZ = (-pillarZ0 * 2) / (pillarCountDepth - 1);
        for (int i = 1; i < pillarCountDepth- 1; i++)
        {
            var pillar1 = Instantiate(cylinderPrefab, transform);
            pillar1.transform.localPosition = new Vector3(pillarX0, floorHeight * 3, pillarZ0 + i * distanceZ);
            pillar1.transform.localScale = new Vector3(pillarRadius / 0.5f, pillarHeight, pillarRadius / 0.5f);
            pillar1.GetComponentInChildren<MeshRenderer>().material = pillarMaterial;
            var pillar2 = Instantiate(cylinderPrefab, transform);
            pillar2.transform.localPosition = new Vector3(-pillarX0, floorHeight * 3, pillarZ0 + i * distanceZ);
            pillar2.transform.localScale = new Vector3(pillarRadius / 0.5f, pillarHeight, pillarRadius / 0.5f);
            pillar2.GetComponentInChildren<MeshRenderer>().material = pillarMaterial;
        }
    }

    private void BuildPillarsAlongXaxis()
    {
        var pillarX0 = -topFloorWidth / 2 + pillarRadius;
        var pillarZ0 = -topFloorDepth / 2 + pillarRadius;
        var distanceX = (-pillarX0 * 2) / (pillarCountWidth - 1);
        for (int i = 0; i < pillarCountWidth; i++)
        {
            var pillar1 = Instantiate(cylinderPrefab, transform);
            pillar1.transform.localPosition = new Vector3(pillarX0 + i * distanceX, floorHeight * 3, pillarZ0);
            pillar1.transform.localScale = new Vector3(pillarRadius / 0.5f, pillarHeight, pillarRadius / 0.5f);
            pillar1.GetComponentInChildren<MeshRenderer>().material = pillarMaterial;
            var pillar2 = Instantiate(cylinderPrefab, transform);
            pillar2.transform.localPosition = new Vector3(pillarX0 + i * distanceX, floorHeight * 3, -pillarZ0);
            pillar2.transform.localScale = new Vector3(pillarRadius / 0.5f, pillarHeight, pillarRadius / 0.5f);
            pillar2.GetComponentInChildren<MeshRenderer>().material = pillarMaterial;
        }
    }

    private void BuildFloors()
    {
        var sizeDecrement = floorWidth * 0.1f;
        var floor1 = Instantiate(cubePrefab, transform);
        floor1.transform.localScale = new Vector3(floorWidth, floorHeight, floorDepth);
        floor1.GetComponentInChildren<MeshRenderer>().material = floorMaterial;
        var floor2 = Instantiate(cubePrefab, transform);
        floor2.transform.localScale = new Vector3(floorWidth-sizeDecrement, floorHeight, floorDepth-sizeDecrement);
        floor2.transform.localPosition = new Vector3(0, floorHeight, 0);
        floor2.GetComponentInChildren<MeshRenderer>().material = floorMaterial;
        var floor3 = Instantiate(cubePrefab, transform);
        floor3.transform.localScale = new Vector3(floorWidth - sizeDecrement*2, floorHeight, floorDepth - sizeDecrement*2);
        floor3.transform.localPosition = new Vector3(0, floorHeight*2, 0);
        floor3.GetComponentInChildren<MeshRenderer>().material = floorMaterial;

        topFloorWidth = floorWidth - sizeDecrement * 2;
        topFloorDepth = floorDepth - sizeDecrement * 2;

    }
    
    [ContextMenu("Destroy All")]
    void DestroyAllChildren()
    {
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);//그 뽑아낸 걸 없애라.
        }
    }
}
