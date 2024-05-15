using System.Collections.Generic;
using UnityEngine;

public class TP1_2 : MonoBehaviour
{
    private List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();
    void Start()
    {
        // On charge au démarrage la liste des devices de la main droite
        rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
    }

    void Update()
    {
        // On vérifie si la liste des devices de la main droite est vide
        if (rightHandDevices.Count == 0)
        {
            return;
        }

        // On vérifie si le bouton de la gâchette est pressé, si oui on crée un cube devant l'utilisateur
        foreach (var device in rightHandDevices)
        {
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool triggerValue) && triggerValue)
            {
                SpawnCubeInFrontOfUser();
            }
        }
    }

    private void SpawnCubeInFrontOfUser()
    {
        Vector3 position = new Vector3(0, 0, 1);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = Camera.main.transform.position + Camera.main.transform.forward + position;
    }
}
