using Volo.Abp.Settings;

namespace Sabeco_Factsheet.Blazor
{
    public class MySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Enable cho người dùng được đăng ký tài khoản
            context.GetOrNull("Abp.Account.IsSelfRegistrationEnabled").DefaultValue = "false";

            //Enable cho người dùng đăng nhập bằng tài khoản cục bộ
            //context.GetOrNull("Abp.Account.EnableLocalLogin").DefaultValue = "true";
        }
    }
}
