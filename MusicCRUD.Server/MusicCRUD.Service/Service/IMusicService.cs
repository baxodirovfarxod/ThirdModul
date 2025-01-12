using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Service;
public interface IMusicService
{
    Guid AddMusic(MusicCreatDto musicDto);
    void UpdateMusic(MusicDto musicDto);
    void DeleteMusic(Guid id);
    List<MusicDto> GetAllMusic();
    List<MusicDto> GetAllMusicByAuthorName(string name);
    MusicDto GetMusicByName(string name);
    MusicDto GetMostLikedMusic();
    List<MusicDto> GetAllMusicAboveSize(double minSize);
    List<MusicDto> GetAllMusicBelowSize(double maxSize);
    List<MusicDto> GetTopMostLikedMusic(int count);
    List<MusicDto> GetLowMostLikedMusic(int count);
    List<MusicDto> GetMusicByDescriptionKeyword(string keyword);
    List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}