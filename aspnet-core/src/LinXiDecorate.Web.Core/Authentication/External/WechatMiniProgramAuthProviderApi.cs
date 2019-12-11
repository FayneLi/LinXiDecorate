using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinXiDecorate.Authentication.External
{
    public class WechatMiniProgramAuthProviderApi : ExternalAuthProviderApiBase
    {
        /// <summary>
        /// 微信小程序
        /// </summary>
        public const string ProviderName = "WeChatMiniProgram";
        WeChatMiniProgramOptions _options;
        JSchema schema = JSchema.Parse(JsonConvert.SerializeObject(new WeChatSession()));
        JSchema accessSchema = JSchema.Parse(JsonConvert.SerializeObject(new { AccessCode = "", Name = "" }));
        const string url = "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&grant_type=authorization_code&js_code={2}";
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        private readonly ILogger logger;
        public WechatMiniProgramAuthProviderApi(IExternalAuthConfiguration externalAuthConfiguration, ILogger logger)
        {
            _externalAuthConfiguration = externalAuthConfiguration;
            var r = externalAuthConfiguration.Providers.First(p => p.Name == ProviderName);
            _options = new WeChatMiniProgramOptions
            {
                AppId = r.ClientId,
                Secret = r.ClientSecret
            };
            this.logger = logger;
        }

        public async override Task<ExternalAuthUserInfo> GetUserInfo(string accessCode)
        {
            //因为需要获取微信放进User.Name 所以accessCode需要多一个Name
            //就长这样 {"AccessCode":"xxxxxxxx", "Name":"Sam"} 所以用Jobect解析出来
            JObject jObject = JObject.Parse(accessCode);
            if (!jObject.IsValid(accessSchema))
            {
                throw new Abp.UI.UserFriendlyException("accessCode Json inVaild");
            }
            accessCode = jObject["AccessCode"].ToString();
            string name = jObject["Name"].ToString();
            //string rowData = jObject["RowData"].ToString();
            var result = await GetOpenId(accessCode);////获取到OpenId，说明accessCode是对的   实际上应该再通过OpenId解密数据后获取NickName的，偷懒了...

            //logger.Info("OpenId:" + result.Openid);　　　　　　　　　　　　　　　　　//获取不到则在方法内部抛出异常，不会返回用户信息，也就不会执行之后的登陆注册操作
            var t = result == null ? new ExternalAuthUserInfo() : new ExternalAuthUserInfo//
            {
                EmailAddress = result.Openid + "@test.cn",
                Surname = name,
                ProviderKey = result.Openid,//唯一
                Provider = ProviderName,
                Name = name
            };
            return t;
        }

        private async Task<WeChatSession> GetOpenId(string code)
        {
            string geturl = string.Format(url, _options.AppId, _options.Secret, code);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetAsync(geturl);
            if (result.IsSuccessStatusCode)
            {                           //{"errcode":40163,"errmsg":"code been used, hints: [ req_id: tWZH6a0160th19 ]"}
                string re = await result.Content.ReadAsStringAsync();//{"session_key":"eafmjK9FYzCVpqPSo\/FBsQ==","openid":"oUigJ47QGkNOOXUjHkii5LyJbukw"}
                var jo = JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    var m = JsonConvert.DeserializeObject<WeChatSession>(re);
                    return m;
                }
            }
            return null;
        }

        class WeChatSession
        {
            public string Openid { get; set; }
            public string Session_key { get; set; }
        }

        /// <summary>
        /// 微信小程序配置选项
        /// </summary>
        public class WeChatMiniProgramOptions
        {
            /// <summary>
            /// AppId
            /// </summary>
            public string AppId { get; set; }
            /// <summary>
            /// 密钥
            /// </summary>
            public string Secret { get; set; }
        }
    }
}
