using UnityEngine;
using Cinemachine;

public class CameraViewportHandler : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineConfiner confiner;

    private void Start()
    {
        CalculateOrtograhicSize();
    }

    private void CalculateOrtograhicSize()
    {
        var size = confiner.m_BoundingShape2D.bounds.size.x * Screen.height / Screen.width * 0.5;

        virtualCamera.m_Lens.OrthographicSize = (float)size;
    }
}