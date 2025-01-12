using MusicCRUD.DataAccess.Entities;
using MusicCRUD.Repository.Repository;
using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Service;
public class MusicService : IMusicService
{
    private IMusicRepository _musicRepository;
    public MusicService()
    {
        _musicRepository = new MusicRepository();
    }
    public Guid AddMusic(MusicCreatDto musicDto)
    {
        var music = ConvertToEntity(musicDto);
        var id = _musicRepository.AddMusic(music);
        return id;
    }
    public void UpdateMusic(MusicDto musicDto)
    {
        var music = ConvertToEntity(musicDto);
        _musicRepository.UpdateMusic(music);
    }
    public void DeleteMusic(Guid id)
    {
        _musicRepository.DeleteMusic(id);
    }
    public List<MusicDto> GetAllMusic()
    {
        var musicList = _musicRepository.GetAllMusic();
        var musicDtoList = musicList.Select(music => ConvertToDto(music)).ToList();
        return musicDtoList;
    }
    public List<MusicDto> GetAllMusicByAuthorName(string name)
    {
        var musicList = GetAllMusic();
        var musicByAuthor = musicList.Where(music => music.AuthorName.ToLower() == name.ToLower()).ToList();
        return musicByAuthor;
    }
    public MusicDto GetMusicByName(string name)
    {
        var musicList = GetAllMusic();
        var music = musicList.FirstOrDefault(music => music.Name == name);
        return music;
    }
    public MusicDto GetMostLikedMusic()
    {
        var musicList = GetAllMusic();
        var amountLikes = musicList.Max(music => music.QuentityLikes);
        var mostLikedMusic = musicList.FirstOrDefault(music => music.QuentityLikes == amountLikes);
        if (mostLikedMusic is null)
        {
            throw new NullReferenceException("Storage is empty");
        }
        return mostLikedMusic;
    }
    public List<MusicDto> GetAllMusicAboveSize(double minSize)
    {
        var musicList = GetAllMusic();
        var musicAboveSize = musicList.Where(music => music.MB >= minSize).ToList();
        return musicAboveSize;
    }
    public List<MusicDto> GetAllMusicBelowSize(double maxSize)
    {
        var musicList = GetAllMusic();
        var musicBelowSize = musicList.Where(music => music.MB < maxSize).ToList();
        return musicBelowSize;
    }
    public List<MusicDto> GetTopMostLikedMusic(int count)
    {
        var musicList = GetAllMusic();
        var res = musicList.OrderByDescending(music => music.QuentityLikes).ThenBy(mu => mu.Name).Take(count).ToList();
        return res;
    }
    public List<MusicDto> GetLowMostLikedMusic(int count)
    {
        var musicList = GetAllMusic();
        var res = musicList.OrderByDescending(music => music.QuentityLikes).ThenBy(music => music.Name).TakeLast(count).ToList();
        return res;
    }
    public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
    {
        var musicList = GetAllMusic();
        return musicList.Where(music => music.Description.ToLower().Contains(keyword.ToLower())).ToList();
    }
    public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        var musicList = GetAllMusic();
        var res = musicList.Where(music => music.QuentityLikes > minLikes && music.QuentityLikes < maxLikes).ToList();
        return res;
    }
    public List<string> GetAllUniqueAuthors()
    {
        var musicList = GetAllMusic();
        var names = new List<string>();
        foreach (var music in musicList)
        {
            var mus = musicList.Count(mu => music.AuthorName == mu.AuthorName);
            if (mus == 1) names.Add(music.AuthorName);
        }

        return names;
    }
    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        var musicList = GetAllMusic();
        var music = GetAllMusicByAuthorName(authorName).Sum(mu => mu.MB);
        return music;
    }
    private Music ConvertToEntity(MusicDto musicDto)
    {
        return new Music
        {
            Id = musicDto.Id,
            Name = musicDto.Name,
            MB = musicDto.MB,
            AuthorName = musicDto.AuthorName,
            Description = musicDto.Description,
            QuentityLikes = musicDto.QuentityLikes,
        };
    }
    private Music ConvertToEntity(MusicCreatDto musicDto)
    {
        return new Music
        {
            Id = Guid.NewGuid(),
            Name = musicDto.Name,
            MB = musicDto.MB,
            AuthorName = musicDto.AuthorName,
            Description = musicDto.Description,
            QuentityLikes = musicDto.QuentityLikes,
        };
    }
    private MusicDto ConvertToDto(Music music)
    {
        return new MusicDto 
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };

    }
}
