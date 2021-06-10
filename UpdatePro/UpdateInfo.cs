/*----------------------------------------------- 
// DockerLiu版权所有。 
// 文件名： 
// 文件功能描述： 
// 创建标识： 
// 修改标识： 
// 修改描述： 
//-----------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary> 
/// 作者:DockerLiu
/// 邮箱:DockerLiu2019@Gmail.com 
/// 网站：www.68s.org 
/// </summary>
namespace UpdatePro
{
    /// <summary>
    /// 升级管理器实体类
    /// </summary>
    public class UpdateInfo
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 更新文件所在服务器URL
        /// </summary>
        public string UpdateURL { get; set; }
        /// <summary>
        /// 更新文件信息列表[和ListView的显示对应]
        /// </summary>
        public string[] fileList { get; set; }
    }
}
