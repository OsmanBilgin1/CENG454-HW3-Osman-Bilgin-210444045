using UnityEngine;

public class Node : MonoBehaviour 
{
    public Color hoverColor;
    public Vector3 positionOffset;
    
    private GameObject turret;
    private Renderer rend;
    private Color startColor;
    private static readonly int BaseColorID = Shader.PropertyToID("_BaseColor");

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.GetColor(BaseColorID);
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        turret = BuildManager.instance.BuildTurret(
            transform.position + positionOffset,
            transform.rotation
        );
    }

    void OnMouseEnter()
    {
        rend.material.SetColor(BaseColorID, hoverColor);
    }

    void OnMouseExit()
    {
        rend.material.SetColor(BaseColorID, startColor);
    }
}
