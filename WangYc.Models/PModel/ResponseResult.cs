using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WangYc.Models.PModel
{
    /// <summary>
    /// Web响应数据返回实体模型对象
    /// </summary>
    [XmlRoot(ElementName = "ResponseResult", Namespace = "")]
    public class ResponseResult
    {
        /// <summary>
        /// 响应状态码
        /// </summary>
        [XmlElement(ElementName = "StatusCode", Namespace = "")]
        public int StatusCode { get; set; }
        /// <summary>
        /// 响应消息内容
        /// </summary>
        [XmlElement(ElementName = "Message", Namespace = "")]
        public string Message { get; set; }
        /// <summary>
        /// 结果内容
        /// </summary>
        [XmlElement(ElementName = "ResultContent", Namespace = "")]
        public object ResultContent { get; set; }
    }
}
