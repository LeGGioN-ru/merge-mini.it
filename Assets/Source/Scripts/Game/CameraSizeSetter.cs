using UnityEngine;
using Zenject;

public class CameraSizeSetter : ITickable
{
    private readonly Camera _camera;
    private readonly float _landscapeSize = 4;
    private readonly float _portraitSize = 7;

    public CameraSizeSetter(Camera camera)
    {
        _camera = camera;
    }

    public void Tick()
    {
        if (Screen.width > Screen.height)
        {
            _camera.orthographicSize = _landscapeSize;
        }
        else
        {
            _camera.orthographicSize = _portraitSize;
        }
    }
}
