using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Swagger
{
    public class SwaggerOptions
    {
        /// <summary>
        /// 是否启用Swagger
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Swagger节点Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// SwaggerTitle
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Swagger版本
        /// </summary>
        public int Version { get; set; } = 1;
    }
}
