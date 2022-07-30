using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseSource.Utilities.Helper
{
    public class FileHelper
    {
        private static string GetUploadDirectoryGen(FileUploadType type)
        {
            var directoryGen = string.Empty;

            switch (type)
            {
                case FileUploadType.KhachHang:
                    directoryGen = "upload\\khachhang";
                    break;
                case FileUploadType.HopDong:
                    directoryGen = "upload\\hopdong";
                    break;
                default:
                    return string.Empty;
            }
            return directoryGen;
        }

        public static bool IsValidImage(IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the mime types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                postedFile.ContentType.ToLower() != "image/jpeg" &&
                postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                {
                    return false;
                }

                if (postedFile.Length <= 0)
                {
                    return false;
                }

                byte[] buffer = new byte[512];
                postedFile.OpenReadStream().Read(buffer, 0, 512);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<?php|<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidSize(IFormFile postedFile, int size)
        {
            if (postedFile.Length <= 0 || postedFile.Length > (1024 * 1024 * size))
            {
                return false;
            }
            return true;
        }

        //public static WebImage CropImage(IFormFile sourceImage, int maxW = 1024)
        //{
        //    var newImage = new WebImage(sourceImage.OpenReadStream());

        //    var width = newImage.Width;
        //    var height = newImage.Height;

        //    if (width > height)
        //    {
        //        var leftRightCrop = (width - height) / 2;
        //        newImage.Crop(0, leftRightCrop, 0, leftRightCrop);
        //    }
        //    else if (height > width)
        //    {
        //        var topBottomCrop = (height - width) / 2;
        //        newImage.Crop(topBottomCrop, 0, topBottomCrop, 0);
        //    }

        //    if (newImage.Width > maxW)
        //    {
        //        newImage.Resize(maxW, maxW);
        //    }

        //    //do something with cropped image...
        //    return newImage;
        //}

        /// <summary>Resizes an image to a new width and height value.</summary>
        /// <returns>The new image. The old image is unaffected.</returns>
        public static Image ResizeImage(IFormFile sourceImage, int newWidth = 1024, int newHeight = 1024)
        {
            Image image = Image.FromStream(sourceImage.OpenReadStream(), true, true);
            Bitmap output = new Bitmap(newWidth, newHeight, PixelFormat.Format16bppRgb555);

            using (Graphics gfx = Graphics.FromImage(output))
            {
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.SmoothingMode = SmoothingMode.HighQuality;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.Clear(Color.Transparent);

                double ratioW = (double)newWidth / (double)image.Width;
                double ratioH = (double)newHeight / (double)image.Height;
                double ratio = ratioW < ratioH ? ratioW : ratioH;

                int insideWidth = (int)(image.Width * ratio);
                int insideHeight = (int)(image.Height * ratio);

                gfx.DrawImage(image, new Rectangle((newWidth / 2) - (insideWidth / 2), (newHeight / 2) - (insideHeight / 2), insideWidth, insideHeight));
            }

            return output;
        }

        public static async Task<string> Upload(IFormFile sourceImage, FileUploadType fileType, string rootPath, int maxWidth = 0, int maxHeight = 0)
        {
            var fileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(sourceImage.FileName);
            var directoryGen = GetUploadDirectoryGen(fileType);
            var directory = Path.Combine(rootPath, directoryGen);

            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, fileName);

            if (maxWidth == 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await sourceImage.CopyToAsync(fileStream);
                }
            }
            else
            {
                //var cropted = FileHelper.CropImage(sourceImage, maxWidth);
                var cropted = FileHelper.ResizeImage(sourceImage, maxWidth, maxHeight);
                cropted.Save(path);
            }
            //upload done

            return (Path.Combine("\\" + directoryGen, fileName));
        }

        public static bool RemoveFileFromServer(string path, string rootPath)
        {
            try //Maybe error could happen like Access denied or Presses Already User used
            {
                var fullPath = rootPath + path;
                if (!File.Exists(fullPath))
                    return false;

                File.Delete(fullPath);
                return true;
            }
            catch (Exception)
            {
                //Debug.WriteLine(e.Message);
            }
            return false;
        }
    }

    public enum FileUploadType : int
    {
        KhachHang = 1,
        HopDong

    }
}
