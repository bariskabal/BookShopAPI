using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyToAsync(uploading);
                }
            }
            var result = NewPath(file);
            File.Move(sourcePath, result.result);
            return result.Path;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static Files NewPath(IFormFile file)
        {
            FileInfo fi = new FileInfo(file.FileName);
            string fileExtension = fi.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\img";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";

            return new Files { result = result, Path = newPath };
        }
    }
}
