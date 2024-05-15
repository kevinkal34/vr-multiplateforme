using TMPro;
using UnityEngine;

public class TP1_1 : MonoBehaviour
{
    void Start()
    {
        string currentDevice = GetDeviceModel();
        SetTextOnCanvas(currentDevice);
    }

    private string GetDeviceModel()
    {
        return SystemInfo.deviceModel;
    }
    private void SetTextOnCanvas(string text)
    {
        GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}