using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WangYc.MVC.Handler
{
    /// <summary>
    /// GetVcode 的摘要说明
    /// </summary>
    public class GetVcode : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        ///   
        /// </summary>
        HttpContext _tecontent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _tecontent = context;
            Load();
        }

        private const int LetterWidth = 18; //单个字体的宽度范围  
        private const int LetterHeight = 28; //单个字体的高度范围  
        private const int LetterCount = 4; //验证码位数  
        private readonly char[] _chars = "0123456789".ToCharArray();
        private readonly string[] _fonts = { "Arial", "Georgia" };
        private const double Pi2 = 6.283185307179586476925286766559;
        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            var strValidateCode = GetRandomNumberString(LetterCount);
            var coderef = _tecontent.Request["vname"];
            if (string.IsNullOrWhiteSpace(coderef)) return;
            _tecontent.Session[coderef.ToLower()] = strValidateCode.ToLower();
            CreateImage(strValidateCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkCode"></param>
        private void CreateImage(string checkCode)
        {
            var intImageWidth = checkCode.Length * LetterWidth + 4;//左右留边 2px
            var newRandom = new Random();
            var image = new Bitmap(intImageWidth, LetterHeight);
            var g = Graphics.FromImage(image);
            //生成随机生成器  
            var random = new Random();
            //白色背景  
            g.Clear(Color.White);
            //画图片的背景噪音线  
            for (var i = 0; i < 10; i++)
            {
                var x1 = random.Next(image.Width);
                var x2 = random.Next(image.Width);
                var y1 = random.Next(image.Height);
                var y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Red), x1, y1, x2, y2);
            }

            //画图片的前景噪音点  
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //随机字体和颜色的验证码字符  

            for (var intIndex = 0; intIndex < checkCode.Length; intIndex++)
            {
                var findex = newRandom.Next(_fonts.Length - 1);
                var strChar = checkCode.Substring(intIndex, 1);
                var newBrush = new SolidBrush(GetRandomColor());
                var thePos = new Point(intIndex * LetterWidth + 1 + newRandom.Next(3), 1 + newRandom.Next(3));//5+1+a+khtime+p+x  
                g.DrawString(strChar, new Font(_fonts[findex], 16, FontStyle.Bold), newBrush, thePos);
            }
            //灰色边框  
            g.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, intImageWidth - 1, (LetterHeight - 1));
            //图片扭曲  
            //将生成的图片发回客户端  
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            _tecontent.Response.ClearContent(); //需要输出图象信息 要修改HTTP头   
            _tecontent.Response.AddHeader("cache-control", "no-cache");
            _tecontent.Response.ContentType = "image/Png";
            _tecontent.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
        }
        /// <summary>  
        /// 正弦曲线Wave扭曲图片  
        /// </summary>  
        /// <param name="srcBmp">图片路径</param>  
        /// <param name="bXDir">如果扭曲则选择为True</param>
        /// <param name="dMultValue"></param>
        /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>  
        /// <returns></returns>  
        private Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            var destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            // 将位图背景填充为白色  
            var graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            double dBaseAxisLen = bXDir ? destBmp.Height : destBmp.Width;
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = bXDir ? (Pi2 * j) / dBaseAxisLen : (Pi2 * i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);
                    // 取得当前点的颜色  
                    int nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    int nOldY = bXDir ? j : j + (int)(dy * dMultValue);
                    var color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            var randomNumFirst = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(randomNumFirst.Next(50));
            var randomNumSencond = new Random((int)DateTime.Now.Ticks);
            var intRed = randomNumFirst.Next(210);
            var intGreen = randomNumSencond.Next(180);
            var intBlue = (intRed + intGreen > 300) ? 0 : 400 - intRed - intGreen;
            intBlue = (intBlue > 255) ? 255 : intBlue;
            return Color.FromArgb(intRed, intGreen, intBlue);// 5+1+a+khtime+p+x  
        }
        /// <summary>
        /// 生成随机数字字符串
        /// </summary>
        /// <param name="intNumberLength"></param>
        /// <returns></returns>
        private string GetRandomNumberString(int intNumberLength)
        {
            var random = new Random();
            string validateCode = string.Empty;
            for (int i = 0; i < intNumberLength; i++)
                validateCode += _chars[random.Next(0, _chars.Length)].ToString(CultureInfo.InvariantCulture);
            return validateCode;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}