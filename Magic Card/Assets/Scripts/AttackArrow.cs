using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AttackArrow : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Camera cameraCache;

    private bool isSecondPointAdded = false;

    private void Awake()
    {
        cameraCache = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        lineRenderer.SetPosition(0, cameraCache.ScreenToWorldPoint(Input.mousePosition));
    }

    private void Start()
    {
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (isSecondPointAdded)
        {
            return;
        }

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = cameraCache.ScreenToWorldPoint(mousePosition);

        lineRenderer.SetPosition(1, new Vector3(worldMousePosition.x, worldMousePosition.y, 0f));
    }

    public void EnableArrow()
    {
        gameObject.SetActive(true);
    }

    public void DisableArrow()
    {
        gameObject.SetActive(false);
    }

    public void SetFirstPoint(Vector3 position)
    {
        lineRenderer.SetPosition(0, position);
    }

    public void SetSecondPoint()
    {
        isSecondPointAdded = true;
    }
}