using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour
{
    private bool _devil = true ;
    public Material _rockMaterial;
    public Material _angelMaterial;
    public Material _lavaMaterial;
    public Material _soulMaterial;
    public Material _swordMaterial;
    public Material _skyboxAngelMaterial;
    public Material _skyboxDevilMaterial;
    public Skybox _skyBox;
    void Start()
    {

    }

    Color HexToColor(string hex)
    {
        if (hex.StartsWith("#") && hex.Length == 7)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString(hex, out color))
            {
                return color;
            }
        }
        return Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Color"))
        {
            Debug.Log("Contact");
            if (_devil)
            {
                Debug.Log("ColorChange");
                _rockMaterial.color = HexToColor("#FFFFFF");
                _angelMaterial.color = HexToColor("#000000");
                _soulMaterial.color = HexToColor("#FFFFFF");
                _swordMaterial.color = HexToColor("#00AED9");
                _lavaMaterial.color = HexToColor("#3842FB");
                _skyBox.material = _skyboxAngelMaterial;
                _devil = false;
            }
            else
            {
                Debug.Log("ColorChange");
                _rockMaterial.color = HexToColor("#525252");
                _angelMaterial.color = HexToColor("#FFFFFF");
                _soulMaterial.color = HexToColor("#4B0000");
                _swordMaterial.color = HexToColor("#D90000");
                _lavaMaterial.color = HexToColor("#FFFFFF");
                _skyBox.material = _skyboxDevilMaterial;
                _devil = true;
            }

        }

    }
}
