using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public abstract class TbInfoUpdateManagerBase : DomainService
    {
        public ITbInfoUpdateRepository _tbInfoUpdateRepository;

        public TbInfoUpdateManagerBase(ITbInfoUpdateRepository tbInfoUpdateRepository)
        {
            _tbInfoUpdateRepository = tbInfoUpdateRepository;
        }

        public virtual async Task<TbInfoUpdate> CreateAsync(
        string tableName, string columnName, int screenId, int rowId, string command, int isActive, bool isVisible, string? screenName = null, string? groupName = null, string? lastValue = null, string? newValue = null, byte? docStatus = null, string? comment = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null, Guid? changeSetId = null, DateTime? timeAssessment = null)
        {
            Check.NotNullOrWhiteSpace(tableName, nameof(tableName));
            Check.Length(tableName, nameof(tableName), TbInfoUpdateConsts.TableNameMaxLength);
            Check.NotNullOrWhiteSpace(columnName, nameof(columnName));
            Check.Length(columnName, nameof(columnName), TbInfoUpdateConsts.ColumnNameMaxLength);
            Check.NotNullOrWhiteSpace(command, nameof(command));
            Check.Length(command, nameof(command), TbInfoUpdateConsts.CommandMaxLength); 
            Check.Length(comment, nameof(comment), TbInfoUpdateConsts.CommentMaxLength);

            var tbInfoUpdate = new TbInfoUpdate(

             tableName, columnName, screenId, rowId, command, isActive, isVisible, screenName, groupName, lastValue, newValue, docStatus, comment, crt_user, crt_date, mod_user, mod_date, changeSetId, timeAssessment
             );

            return await _tbInfoUpdateRepository.InsertAsync(tbInfoUpdate);
        }

        public virtual async Task<TbInfoUpdate> UpdateAsync(
            int id,
            string tableName, string columnName, int screenId, int rowId, string command, int isActive, bool isVisible, string? screenName = null, string? groupName = null, string? lastValue = null, string? newValue = null, byte? docStatus = null, string? comment = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null, Guid? changeSetId = null, DateTime? timeAssessment = null
        )
        {
            Check.NotNullOrWhiteSpace(tableName, nameof(tableName));
            Check.Length(tableName, nameof(tableName), TbInfoUpdateConsts.TableNameMaxLength);
            Check.NotNullOrWhiteSpace(columnName, nameof(columnName));
            Check.Length(columnName, nameof(columnName), TbInfoUpdateConsts.ColumnNameMaxLength);
            Check.NotNullOrWhiteSpace(command, nameof(command));
            Check.Length(command, nameof(command), TbInfoUpdateConsts.CommandMaxLength); 
            Check.Length(comment, nameof(comment), TbInfoUpdateConsts.CommentMaxLength);

            var tbInfoUpdate = await _tbInfoUpdateRepository.GetAsync(id);

            tbInfoUpdate.TableName = tableName;
            tbInfoUpdate.ColumnName = columnName;
            tbInfoUpdate.ScreenId = screenId;
            tbInfoUpdate.RowId = rowId;
            tbInfoUpdate.Command = command;
            tbInfoUpdate.IsActive = isActive;
            tbInfoUpdate.IsVisible = isVisible;
            tbInfoUpdate.ScreenName = screenName;
            tbInfoUpdate.GroupName = groupName;
            tbInfoUpdate.LastValue = lastValue;
            tbInfoUpdate.NewValue = newValue;
            tbInfoUpdate.DocStatus = docStatus;
            tbInfoUpdate.Comment = comment;
            tbInfoUpdate.crt_user = crt_user;
            tbInfoUpdate.crt_date = crt_date;
            tbInfoUpdate.mod_user = mod_user;
            tbInfoUpdate.mod_date = mod_date;
            tbInfoUpdate.ChangeSetId = changeSetId;
            tbInfoUpdate.TimeAssessment = timeAssessment;

            return await _tbInfoUpdateRepository.UpdateAsync(tbInfoUpdate);
        }

    }
}