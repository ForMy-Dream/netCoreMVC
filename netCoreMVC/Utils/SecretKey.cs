using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using netCoreMVC.Models;

namespace netCoreMVC.Utils
{
    public class Secretkey
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="info"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static string Enc_SecKey(AuthInfo info, string secret)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(info, secret);
            return token;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="token"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static AuthInfo Dec_SecKey(string token, string secret)
        {
            //secret需要加密
            JWT.IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

            var authInfo = decoder.DecodeToObject<AuthInfo>(token, secret, verify: true);

            return authInfo;
        }
    }
}
