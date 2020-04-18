﻿using UnityEngine;

public class CheckCameraPoint: MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;


    public Transform newObject;
    private Transform _selection;

    private LineRenderer lr;

    void Start() {
        lr = GetComponent<LineRenderer>();
    }
    
    private void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            lr.SetPosition(1, hit.point);
        }
        
        if(Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("pressed E");
            
            if (Physics.Raycast(ray, out hit)) {
                //TODO: Insert Element that was casted
                HandleUse(hit);
            }
        }

        /*if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;
            }
        }*/
    }

    private void HandleUse(RaycastHit hit)
    {
        var position = hit.point;

        //TODO: Divide by element casted
        /*   EARTH BENDING   */
        if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            position += Vector3.Scale(new Vector3(-4, -4, -4), hit.normal);
            Debug.Log(hit.normal);
            newObject.GetComponent<SpawningMovement>().normalDir = hit.normal;
            Instantiate(newObject, position, Quaternion.FromToRotation(Vector3.up,hit.normal));

        } else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("EarthCube"))
        {
            hit.transform.gameObject.GetComponent<SpawningMovement>().changeCubeSize(2);

        }
        /********************************/
    }
}