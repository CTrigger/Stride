using Microsoft.AspNetCore.Http;
using Services.Interface;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class FileService : IFileService
    {
        #region Constants
        private const string ImagePath = @".\Content\Images\";
        private const string TextPath = @".\Content\Texts\";
        //private Logger logger;
        #endregion

        #region ctor
        public FileService()
        {
            //logger = NLog.LogManager.GetCurrentClassLogger();
        }
        #endregion

        public async Task WriteFile(string[] FileContent, string FileName, string FileExtension)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(TextPath + FileName + "." + FileExtension, true))
                {

                    for (int i = 0; i < FileContent.Length; i++)
                    {
                        await file.WriteLineAsync(FileContent[i]);
                    }


                }
            }
            catch (Exception e)
            {
                //logger.Error(e);
            }
        }

        public T ReadFile<T>(string FileName, string FileExtension)
        {

            object a = new object();
            string[] Text;
            int totalLines = 0;
            using (StreamReader File = new StreamReader(FileName + "." + FileExtension))
            {
                try
                {
                    Text = File.ReadToEnd().Split('\n');
                    totalLines = Text.Length;
                }
                catch (Exception e)
                {
                    //logger.Error(e);
                    throw;
                }

            }
            return (T)Convert.ChangeType(a, typeof(T));
            //return a;
        }


        /// <summary>
        /// Save image file with the same name
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task SaveImageAsync(IFormFile content, FileMode fileMode)
        {
            string completePath = ImagePath + content.FileName;
            await Save(content, fileMode, completePath);
        }


        
        #region Private Methods
        #region Save Local
        /// <summary>
        /// Method to manage the content to the disk
        /// </summary>
        /// <param name="content">File to save</param>
        /// <param name="path">path at the disk</param>
        /// <returns></returns>
        private async Task Save(IFormFile content, FileMode fileMode, string path)
        {
            try
            {
                if (content.Length > 0)
                {
                    using (Stream fileStream = new FileStream(path, fileMode))
                    {
                        await content.CopyToAsync(fileStream);
                    }
                }
            }
            catch (Exception e)
            {
                //logger.Error(e);
                throw;
            }
        }
        #endregion

        #region Save Azure Cloud
        /// <summary>
        /// method to manage the content at the Azure cloud
        /// Azure: Storage Account
        /// </summary>
        /// <param name="content">File</param>
        /// <returns></returns>
        //private async Task SaveAzure(IFormFile content)
        //{
        //    throw new NotImplementedException("pending");
        //}
        #endregion
        #endregion

    }
}
