using Microsoft.AspNetCore.Mvc;
using WebFileManagment.Service.Service;

namespace WebFileManagment.Server.Controllers
{
    [Route("api/storageController")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("creatDirectory")]
        public void CreatDirectory(string name)
        {
            _storageService.CreateDirectory(name);
        }

        [HttpPost("uploadFile")]
        public void UploadFile(IFormFile file, string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            directoryPath = Path.Combine(directoryPath, file.FileName);

            using (var stream = file.OpenReadStream())
            {
                _storageService.UploadFile(directoryPath, stream);
            }
        }

        [HttpGet("getAllFilesAndFolders")]
        public List<string> GetAllFilesAndFolders(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            return _storageService.GetAllFilesAndDirectories(directoryPath);
        }

        [HttpDelete("deleteDirectory")]
        public void DeleteDirectory(string directoryPath)
        {
            _storageService.DeleteDirectory(directoryPath);
        }

        [HttpDelete("deleteFile")]
        public void DeleteFile(string filePath)
        {
            _storageService.DeleteFile(filePath);
        }

        [HttpGet("downloadFile")]
        public FileStreamResult DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }

            var fileName = Path.GetFileName(filePath);
            var stream = _storageService.DownLoadFile(fileName);

            var res = new FileStreamResult(stream, "application/octet-stream")
            { 
                FileDownloadName = fileName,
            };

            return res;
        }

        [HttpGet("downloadFolder")]
        public FileStreamResult DownLoadFolder(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new Exception("Error!");
            }

            var folderName = Path.GetFileName(directoryPath);
            var stream = _storageService.DownLoadDirectory(directoryPath);

            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = folderName + ".zip"
            };

            return res;
        }
    }
}
