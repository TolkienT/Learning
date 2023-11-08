using Aspose.Cells;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using SharpCompress.Common;
using SkiaSharp;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;
using System.Web;
using WebApi.Common.Helpers;
using WebApi.Core.Filter;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Entities.Sys;
using WebApi.Model.Enums;
using WebApi.Model.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Test")]
        public async Task<HttpResultModel<IEnumerable<object>>> TestGet()
        {
            List<object> list = new();
            list.Add(new
            {
                Id = 1,
                Name = "Jack"
            });
            list.Add(new
            {
                Id = 2,
                Name = "Rose"
            });
            return new HttpResultModel<IEnumerable<object>>(list);
        }

        [HttpPost]
        [Route("TestPost")]
        public async Task<HttpResultModel<object>> TestPost([FromBody] object dto)
        {
            return new HttpResultModel<object>(dto);
        }


        //[HttpPost]
        //[Route("TestExport")]
        //public async Task<ActionResult> TestExport()
        //{
        //    List<UserEntity> userEntities = new();
        //    userEntities.Add(new UserEntity()
        //    {
        //        UserName = "Test",
        //        NickName = "QWE"
        //    });
        //    var table = ConvertHelper.ListToDataTable(userEntities);

        //    var wb = AsposeExcelHelper.Export(table);

        //    // 写 WorkBook信息到 内存流中
        //    byte[] buffer = null;
        //    var resp = this.Response;
        //    resp.ContentType = "application/xlsx";
        //    string fileName = HttpUtility.UrlEncode("测试Excel导出", System.Text.Encoding.UTF8);
        //    resp.Headers.Add("content-disposition", "attachment; filename=" + $"{fileName}.xlsx");
        //    using (MemoryStream ms = new())
        //    {
        //        wb.Save(ms, SaveFormat.Xlsx);
        //        resp.Headers.Add("Content-Length", ms.Length.ToString());
        //        buffer = ms.ToArray();
        //        ms.Position = 0L;
        //        ms.WriteTo(resp.Body);
        //    }

        //    resp.Body.Flush();
        //    resp.Body.Close();
        //    return new EmptyResult();

        //}

        /// <summary>
        /// TTS语音播放
        /// </summary>
        /// <param name="content">播放内容</param>
        /// <param name="rate">语速</param>
        /// <param name="volume">音量</param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("TestSpeak")]
        //public async Task<HttpResultModel<string>> TestSpeak(string content, int rate = 0, int volume = 100)
        //{
        //    using (SpeechSynthesizer synth = new())
        //    {
        //        synth.Rate = rate;
        //        synth.Volume = volume;

        //        PromptBuilder builder = new();
        //        builder.AppendText(content);
        //        synth.Speak(builder);
        //    }

        //    return new HttpResultModel<string>("播放成功");
        //}


    }
}
