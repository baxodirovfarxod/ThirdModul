using MusicCRUD.DataAccess.Entities;

namespace MusicCRUD.Repository.Repository;
public interface IMusicRepository
{
    Guid AddMusic(Music music);
    Music GetMusicById(Guid id);
    void UpdateMusic(Music music);
    void DeleteMusic(Guid id);
    List<Music> GetAllMusic();
}