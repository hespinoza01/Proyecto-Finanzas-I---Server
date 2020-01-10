using System;

namespace Financecalc_Server.Utils
{
    public abstract class ResponseType
    {

        public static _Response Success(string ResMsg = "Request Success", int ResCod = 200) => new _Response
        {
            ResponseCode = ResCod,
            ResponseText = ResMsg,
            ResponseDateTime = new DateTime().ToString("dd-MM-yy HH:mm:ss")
        };

        public static _Response Error(string ResMsg = "Request Error", int ResCod = 500) => new _Response
        {
            ResponseCode = ResCod,
            ResponseText = ResMsg,
            ResponseDateTime = new DateTime().ToString("dd-MM-yy HH:mm:ss")
        };

    }

    public class _Response
    {
        public int ResponseCode { get; set; }
        public string ResponseText { get; set; }
        public string ResponseDateTime { get; set; }
    }
}