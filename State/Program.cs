// Main Context Class
class Camera
{
    private ICameraState _state;
    private string _mediaFileDescription;
    public string MediaFileDescription { get => _mediaFileDescription; set => _mediaFileDescription = value; }
    public Camera()
    {
        _state = new UsualModeState(this);
        _mediaFileDescription = "No media";
    }
    public void SetState(ICameraState state)
    {
        _state = state;
    }
    public void Shoot()
    {
        _state.Shoot();
    }
    public void SwitchToUsualMode()
    {
        _state.UsualMode();
    }
    public void SwitchToPortraitMode()
    {
        _state.PortraitMode();
    }
    public void SwitchToVideoMode()
    {
        _state.Video();
    }
}
interface ICameraState
{
    void Shoot();
    void UsualMode();
    void PortraitMode();
    void Video();
}
class UsualModeState : ICameraState
{
    private Camera _camera;
    public UsualModeState(Camera context)
    {
        _camera = context;
    }
    public void PortraitMode()
    {
        _camera.SetState(new PortraitModeState(_camera));
        Console.WriteLine($"Switched to portrait mode");
    }

    public void Shoot()
    {
        _camera.MediaFileDescription = "Media file is a usual photo";
    }

    public void UsualMode()
    {
        Console.WriteLine("Already in usual mode");
    }

    public void Video()
    {
        _camera.SetState(new VideoModeState(_camera));
        Console.WriteLine($"Switched to video mode");
    }
}
class PortraitModeState : ICameraState
{
    private Camera _camera;
    public PortraitModeState(Camera context)
    {
        _camera = context;
    }
    public void PortraitMode()
    {
        Console.WriteLine($"Already in portrait mode");
    }

    public void Shoot()
    {
        _camera.MediaFileDescription = "Media file is photo with blured background";
    }

    public void UsualMode()
    {
        _camera.SetState(new UsualModeState(_camera));
        Console.WriteLine($"Switched to usual mode");
    }

    public void Video()
    {
        _camera.SetState(new VideoModeState(_camera));
        Console.WriteLine($"Switched to video mode");
    }
}
class VideoModeState : ICameraState
{
    private Camera _camera;
    public VideoModeState(Camera context)
    {
        _camera = context;
    }
    public void PortraitMode()
    {
        _camera.SetState(new PortraitModeState(_camera));
        Console.WriteLine($"Switched to portrait mode");
    }

    public void Shoot()
    {
        _camera.MediaFileDescription = "Media file is video";
    }

    public void UsualMode()
    {
        _camera.SetState(new UsualModeState(_camera));
        Console.WriteLine($"Switched to portrait mode");
    }

    public void Video()
    {
        Console.WriteLine("Already in video mode");
    }
}

class Program
{
    static void Main()
    {
        Camera camera = new Camera();
        camera.Shoot(); // Usual picture
        Console.WriteLine($"Media file description: {camera.MediaFileDescription}");
        camera.SwitchToUsualMode(); // Already in usual mode
        camera.SwitchToPortraitMode(); // Switched to portrait mode
        camera.Shoot(); // Picture with blured bg
        Console.WriteLine($"Media file description: {camera.MediaFileDescription}");
        camera.SwitchToVideoMode(); // Switched to video mode
        camera.Shoot(); // Video
        Console.WriteLine($"Media file description: {camera.MediaFileDescription}");


    }
}