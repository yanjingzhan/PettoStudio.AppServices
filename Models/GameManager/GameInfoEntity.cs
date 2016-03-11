using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.GameManager
{
    public class GameInfoEntity
    {
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Version { get; set; }
        public string Icon { get; set; }
        public string Size { get; set; }
        public string Level { get; set; }
        public string Url { get; set; }
        public string DownloadType { get; set; }
        public string ActionType { get; set; }
        public string Ispc { get; set; }
        public string Iszhuanshu { get; set; }

        public string GameProfileInfo { get; set; }
        public string GameClassify { get; set; }
        public string GameProfileUrl { get; set; }

        /// <summary>
        /// 游戏类型/Silverlight/Unity/XNA/Cocos
        /// </summary>
        public string GameSourceType { get; set; }

        public string ID { get; set; }

        /// <summary>
        /// 下载状态 已下载/未下载
        /// </summary>
        public string DownloadState { get; set; }

        public float NumSize { get; set; }

        public string FileName { get; set; }

        public string RealDownloadUrl { get; set; }

        public string OriginalName { get; set; }
    }
}
