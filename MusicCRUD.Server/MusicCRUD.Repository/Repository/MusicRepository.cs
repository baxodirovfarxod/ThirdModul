using MusicCRUD.DataAccess.Entities;
using System.Text.Json;

namespace MusicCRUD.Repository.Repository;
public class MusicRepository : IMusicRepository
{
    private readonly string _path;
    private List<Music> _music;
    public MusicRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Music.json");
        if (File.Exists(_path) is false)
        {
            File.WriteAllText(_path, "[]");
        }
        _music = ReadAll();
    }
    public Guid AddMusic(Music music)
    {
        _music.Add(music);
        SaveData();
        return music.Id;
    }
    public void DeleteMusic(Guid id)
    {
        var music = GetMusicById(id);
        _music.Remove(music);
        SaveData();
    }
    public List<Music> GetAllMusic()
    {
        return _music;
    }
    public Music GetMusicById(Guid id)
    {
        var music = _music.FirstOrDefault(m => m.Id == id);
        if (music is null)
        {
            throw new Exception($"Bunday {id} lik musiqa yo'q !");
        }
        return music;
    }
    public void UpdateMusic(Music updatedMusic)
    {
        var music = GetMusicById(updatedMusic.Id);
        var index = _music.IndexOf(music);
        _music[index] = updatedMusic;
        SaveData();
    }
    private List<Music> ReadAll()
    {
        var musicJson = File.ReadAllText(_path);
        var music = JsonSerializer.Deserialize<List<Music>>(musicJson);
        return music;
    }
    private void SaveData()
    {
        var musicJson = JsonSerializer.Serialize(_music);
        File.WriteAllText(_path, musicJson);
    }
}
