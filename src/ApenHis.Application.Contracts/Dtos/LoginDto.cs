using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApenHis.Dtos
{
    public class LoginDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "账号不能为空。")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 发送验证码返回的校验码
        /// </summary>
        public string VerificationKey { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerificationCode { get; set; }
        public string LoginType { get; set; }

        public bool AutoLogin { get; set; }
    }

}
