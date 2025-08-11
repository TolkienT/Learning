using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model.Dtos.File;
using WebServer.Model.Enums;
using WebServer.Model.Models;

namespace WebServer.Core.Controllers.Test
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FileUploadTestController : ControllerBase
    {


        [HttpPost]
        public async Task<HttpResultModel> MultipartUpload([FromForm] MultipartFileDto dto)
        {
            try
            {
                string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "TempUploads");
                var file = dto.FileChunk;
                var fileName = Path.GetFileName(file.FileName);
                var chunkIndex = dto.ChunkIndex;
                var totalChunks = dto.TotalChunks;

                if (file == null || file.Length == 0)
                {
                    return new HttpResultModel()
                    {
                        Status = HttpResultStatus.Error,
                        Success = false,
                        Message = "文件不能为空"
                    };
                }

                // 确保临时目录存在
                if (!Directory.Exists(tempFolder))
                {
                    Directory.CreateDirectory(tempFolder);
                }

                // 保存文件块
                var chunkFilePath = Path.Combine(tempFolder, $"{fileName}.part{chunkIndex}");
                using (var stream = new FileStream(chunkFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return new HttpResultModel()
                {
                    Status = HttpResultStatus.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new HttpResultModel()
                {
                    Status = HttpResultStatus.Error,
                    Success = false,
                    Message = "文件上传失败:" + ex.ToString()
                };
            }

        }

        [HttpPost]
        public async Task<HttpResultModel> MultipartMerge([FromBody] MergeRequestDto dto)
        {
            try
            {
                string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "TempUploads");
                var fileName = dto.FileName;
                var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                // 确保输出目录存在
                var outputFolder = Path.GetDirectoryName(outputFilePath);
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // 获取所有分块文件
                var chunkFiles = Directory.GetFiles(tempFolder, $"{fileName}.part*");
                if (chunkFiles.Length == 0)
                {
                    return new HttpResultModel()
                    {
                        Status = HttpResultStatus.Error,
                        Success = false,
                        Message = "未找到分块文件"
                    };
                }

                // 按分块索引排序
                chunkFiles = chunkFiles.OrderBy(f => int.Parse(f.Split(".part")[1])).ToArray();

                // 合并分块文件
                using (var outputStream = new FileStream(outputFilePath, FileMode.Create))
                {
                    foreach (var chunkFile in chunkFiles)
                    {
                        using (var chunkStream = new FileStream(chunkFile, FileMode.Open))
                        {
                            chunkStream.CopyTo(outputStream);
                        }
                    }
                }

                // 计算合并文件的哈希值
                var mergedFileHash = CalculateFileHash(outputFilePath);
                if (mergedFileHash != dto.FileHash)
                {
                    System.IO.File.Delete(outputFilePath); // 删除不完整的文件
                    return new HttpResultModel()
                    {
                        Status = HttpResultStatus.Error,
                        Success = false,
                        Message = "文件哈希值不匹配，文件可能已损坏"
                    };
                }


                // 删除临时分块文件
                foreach (var chunkFile in chunkFiles)
                {
                    System.IO.File.Delete(chunkFile);
                }

                return new HttpResultModel()
                {
                    Status = HttpResultStatus.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new HttpResultModel()
                {
                    Status = HttpResultStatus.Error,
                    Success = false,
                    Message = "合并失败:" + ex.ToString()
                };
            }

        }

        private string CalculateFileHash(string filePath)
        {
            using (var stream = System.IO.File.OpenRead(filePath))
            {
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    var hashBytes = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        [HttpGet]
        public async Task<HttpResultModel> GetTestResult()
        {

            _ = Task.Run(async () =>
            {
                await Task.Delay(10000); // 模拟耗时操作
                Console.WriteLine("测试数据");
            });
            await Task.Delay(1000);
            return new HttpResultModel()
            {
                Status = HttpResultStatus.OK,
                Success = true,
            };
        }

    }
}
