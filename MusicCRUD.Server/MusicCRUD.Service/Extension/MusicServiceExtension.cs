using MusicCRUD.Service.DTOs;
using MusicCRUD.Service.Service;

namespace MusicCRUD.Service.Extension;
public static class MusicServiceExtension
{
    public static double GetMusicKB(this IMusicService musicServic, string name)
    {
        var music = musicServic.GetMusicByName(name);
        return music.MB * 1024;
    }
    public static int GetAllQuantityLikes(this IMusicService musicServic)
    {
        var music = musicServic.GetAllMusic();
        return music.Sum(m => m.QuentityLikes);
    }
}
