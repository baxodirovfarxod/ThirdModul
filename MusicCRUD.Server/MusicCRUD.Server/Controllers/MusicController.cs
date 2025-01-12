using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCRUD.Service.DTOs;
using MusicCRUD.Service.Extension;
using MusicCRUD.Service.Service;

namespace MusicCRUD.Server.Controllers
{
    [Route("api/music")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicService _musicService;
        public MusicController()
        {
            _musicService = new MusicService();
        }

        [HttpPost("addMusic")]
        public Guid AddMusic(MusicCreatDto musicDto)
        {
            var id = _musicService.AddMusic(musicDto);
            return id;
        }

        [HttpPut("updateMusic")]
        public void UpdateMusic(MusicDto musicDto)
        {
            _musicService.UpdateMusic(musicDto);
        }

        [HttpDelete("deleteMusic")]
        public void DeleteMusic(Guid id)
        {
            _musicService.DeleteMusic(id);
        }

        [HttpGet("getallMusic")]
        public List<MusicDto> GetMusic()
        {
            return _musicService.GetAllMusic();
        }

        [HttpGet("getallMusicbyAuthorName")]
        public List<MusicDto> GetAllMusicByAuthorName(string name)
        {
            return _musicService.GetAllMusicByAuthorName(name);
        }

        [HttpGet("getMusicbyName")]
        public MusicDto GetMusicByName(string name)
        {
            return _musicService.GetMusicByName(name);
        }

        [HttpGet("getMostLikedMusic")]
        public MusicDto GetMostLikedMusic()
        {
            return _musicService.GetMostLikedMusic();
        }

        [HttpGet("getAllMusicAboveSize")]
        public List<MusicDto> GetAllMusicAboveSize(double minSize)
        {
            return _musicService.GetAllMusicAboveSize(minSize);
        }

        [HttpGet("getAllMusicBelowSize")]
        public List<MusicDto> GetAllMusicBelowSize(double maxSize)
        {
            return _musicService.GetAllMusicBelowSize(maxSize);
        }

        [HttpGet("getTopMostLikedMusic")]
        public List<MusicDto> GetTopMostLikedMusic(int count)
        {
            return _musicService.GetTopMostLikedMusic(count);
        }

        [HttpGet("getLowMostLikedMusic")]
        public List<MusicDto> GetLowMostLikedMusic(int count)
        {
            return _musicService.GetLowMostLikedMusic(count);
        }

        [HttpGet("getMusicByDescriptionKeyword")]
        public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
        {
            return _musicService.GetMusicByDescriptionKeyword(keyword);
        }

        [HttpGet("getMusicWithLikesInRange")]
        public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
        {
            return _musicService.GetMusicWithLikesInRange(minLikes, maxLikes);
        }

        [HttpGet("getAllUniqueAuthors")]
        public List<string> GetAllUniqueAuthors()
        {
            return _musicService.GetAllUniqueAuthors();
        }

        [HttpGet("getTotalMusicSizeByAuthor")]
        public double GetTotalMusicSizeByAuthor(string authorName)
        {
            return _musicService.GetTotalMusicSizeByAuthor(authorName);
        }

        [HttpGet("getMusicKB")]
        public double GetMusicKB(string musicName)
        {
            return _musicService.GetMusicKB(musicName);
        }

        [HttpGet("GetAllQuantityLikes")]
        public int GetAllQuantityLikes()
        {
            return _musicService.GetAllQuantityLikes();
        }
    }
}
