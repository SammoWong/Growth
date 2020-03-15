using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Growth.IO
{
    public class DirectoryHelper
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path">要创建的文件夹路径</param>
        public static void CreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
