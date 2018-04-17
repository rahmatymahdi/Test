using System;
using System.Collections.Generic;
using System.Linq;
using UploadDownload.Models;

namespace UploadDownload.Classes
{
    public class TokenBiz
    {
        public static readonly TokenBiz Instance = new TokenBiz();
        private static List<Models.Token> _staticTokenList;

        public string Add()
        {
            var model=new Models.Token();
            if (_staticTokenList==null)
            {
                _staticTokenList=new List<Token>();
            }
            _staticTokenList.Add(model);
            return model.Id;
        }

        public void ValidateToken(string token)
        {
            if (_staticTokenList==null||string.IsNullOrEmpty(token))
            {
              throw  new Exception("توکن معتبر نیست");
            }
            var obj = _staticTokenList.FirstOrDefault(x=>x.Id==token);
            if (obj==null)
            {
                throw new Exception("توکن معتبر نیست");
            }
            
            var timestampExired = ( DateTime.Now-obj.Created).TotalSeconds;

            _staticTokenList.Remove(obj);

            //token time stamp validity
            var setting = UploadDownload.Properties.Settings.Default.TokenValidityTime;

            if (timestampExired > setting)
            {
                throw new Exception("اعتبار زمانی توکن به پایان رسیده است");
            }
        }
    }
}