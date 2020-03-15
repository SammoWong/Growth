using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Growth.IO
{
    public class FileHelper
    {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName">要创建的带路径的文件名，例如：path = @"D:\test.txt"</param>
        public static void CreateIfNotExists(string fileName)
        {
            if (File.Exists(fileName))
                return;

            var path = Path.GetFileName(fileName);
            if (path != null)
            {
                DirectoryHelper.CreateIfNotExists(path);
            }
            File.Create(fileName);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">要删除的带路径的文件名，例如：path = @"D:\test.txt"</param>
        public static void DeleteIfExists(string fileName)
        {
            if (!File.Exists(fileName))
                return;

            File.Delete(fileName);
        }


    }
}
