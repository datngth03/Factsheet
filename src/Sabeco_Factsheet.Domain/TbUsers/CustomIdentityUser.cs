using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Sabeco_Factsheet.TbUsers
{
    public class CustomIdentityUser : IdentityUser
    {
        public Guid? Id
        {
            // Đọc giá trị Id, sử dụng giá trị của lớp cơ sở
            get => base.Id;

            // Thiết lập giá trị Id, gọi phương thức SetId với giá trị được cung cấp
            set => SetId(value);
        }

        // Thiết lập giá trị Id bằng Reflection
        private void SetId(Guid? value)
        {
            /* Lấy PropertyInfo (thông tin thuộc tính) cho thuộc tính Id của lớp cơ sở IdentityUser
			 * BindingFlags.Public: Tìm kiếm các thành phần (như các phương thức, thuộc tính, trường) mà có phạm vi truy cập là public.
			 * BindingFlags.NonPublic: Tìm kiếm các thành phần công khai, bao gồm internal set.
			 * BindingFlags.Instance: Chỉ áp dụng cho các thành phần của đối tượng (instance), không áp dụng cho các thành phần tĩnh (static).
			 */
            var idProperty = typeof(IdentityUser).GetProperty("Id", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (idProperty == null)
            {
                throw new Exception("Không tìm thấy thuộc tính Id.");
            }


            /* Lấy phương thức set của thuộc tính Id
			 * Nếu gán true sẽ lấy các phương thức public, internal, protected. Nếu là false sẽ chỉ lấy các phương thức public
			 * Nếu thuộc tính Id có phương thức set công khai, thì setMethod sẽ lưu trữ phương thức set đó.
			 * Nếu thuộc tính Id chỉ có phương thức set không công khai(internal set), thì setMethod sẽ lưu trữ phương thức set không công khai.
			 */
            var setMethod = idProperty.GetSetMethod(true);
            if (setMethod == null)
            {
                throw new Exception("Không tìm thấy phương thức set cho thuộc tính Id.");
            }

            // Gọi/truy cập phương thức set của thuộc tính Id với giá trị được cung cấp
            setMethod.Invoke(this, new object[] { value });
        }

        public string UserName
		{
			get => base.UserName;
			set => SetUserName(value);
		}

		private void SetUserName(string value)
		{
			var userNameProperty = typeof(IdentityUser).GetProperty("UserName", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (userNameProperty == null)
			{
				throw new Exception("Không tìm thấy thuộc tính UserName.");
			}

			var setMethod = userNameProperty.GetSetMethod(true);
			if (setMethod == null)
			{
				throw new Exception("Không tìm thấy phương thức set cho thuộc tính UserName.");
			}

			setMethod.Invoke(this, new object[] { value });
		}
		
		public string SecurityStamp
        {
			get => base.SecurityStamp;
			set => SetSecurityStamp(value);
		}

		private void SetSecurityStamp(string value)
		{
			var securityStampProperty = typeof(IdentityUser).GetProperty("SecurityStamp", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (securityStampProperty == null)
			{
				throw new Exception("Không tìm thấy thuộc tính SecurityStamp.");
			}

			var setMethod = securityStampProperty.GetSetMethod(true);
			if (setMethod == null)
			{
				throw new Exception("Không tìm thấy phương thức set cho thuộc tính SecurityStamp.");
			}

			setMethod.Invoke(this, new object[] { value });
		}

		public string NormalizedUserName
        {
			get => base.NormalizedUserName;
			set => SetNormalizedUserName(value);
		}

		private void SetNormalizedUserName(string value)
		{
			var normalizedUserName = typeof(IdentityUser).GetProperty("NormalizedUserName", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (normalizedUserName == null)
			{
				throw new Exception("Không tìm thấy thuộc tính NormalizedUserName.");
			}

			var setMethod = normalizedUserName.GetSetMethod(true);
			if (setMethod == null)
			{
				throw new Exception("Không tìm thấy phương thức set cho thuộc tính NormalizedUserName.");
			}

			setMethod.Invoke(this, new object[] { value });
		}
		
		public string NormalizedEmail
        {
			get => base.NormalizedEmail;
			set => SetNormalizedEmail(value);
		}

		private void SetNormalizedEmail(string value)
		{
			var normalizedEmail = typeof(IdentityUser).GetProperty("NormalizedEmail", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (normalizedEmail == null)
			{
				throw new Exception("Không tìm thấy thuộc tính NormalizedEmail.");
			}

			var setMethod = normalizedEmail.GetSetMethod(true);
			if (setMethod == null)
			{
				throw new Exception("Không tìm thấy phương thức set cho thuộc tính NormalizedEmail.");
			}

			setMethod.Invoke(this, new object[] { value });
		}

		

		public string Email
		{
			get => base.UserName;
			set => SetEmail(value);
		}

		private void SetEmail(string value)
		{
			var emailProperty = typeof(IdentityUser).GetProperty("Email", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (emailProperty == null)
			{
				throw new Exception("Không tìm thấy thuộc tính Email.");
			}

			var setMethod = emailProperty.GetSetMethod(true);
			if (setMethod == null)
			{
				throw new Exception("Không tìm thấy phương thức set cho thuộc tính Email.");
			}

			setMethod.Invoke(this, new object[] { value });
		}

		
		
		public bool IsActive
		{
			get => base.IsActive;
			set => SetIsActive(value);
		}

		private void SetIsActive(bool value)
		{
			var isActiveProperty = typeof(IdentityUser).GetProperty("IsActive", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (isActiveProperty == null)
			{
				throw new Exception("Không tìm thấy thuộc tính IsActive.");
			}

			var setMethod = isActiveProperty.GetSetMethod(true);
			if (setMethod == null)
			{
				throw new Exception("Không tìm thấy phương thức set cho thuộc tính IsActive.");
			}

			setMethod.Invoke(this, new object[] { value });
		}


	}

}
