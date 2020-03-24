using Financecalc_Server.Utils;

namespace Financecalc_Server.Models
{
    public class UserToken
    {
        public Usuario _user { get; set; }
        public string _token { get; set; }

        public UserToken(Usuario _usuario)
        {
            this._user = _usuario;
            this._token = Token(_usuario);
        }

        protected string Token(Usuario _usuario)
        {
            string StartToken = PasswordCipher.Encrypt(_usuario.Username);
            string MidToken = PasswordCipher.Encrypt(_usuario.Fullname);
            string EndToken = PasswordCipher.Encrypt("superUltraSecretToken");

            return $"{StartToken}.{MidToken}.{EndToken}";
        }
    }
}