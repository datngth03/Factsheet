using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public abstract class TbInfoUpdateBase : Entity<int>
    {
        [NotNull]
        public virtual string TableName { get; set; }

        [NotNull]
        public virtual string ColumnName { get; set; }

        [CanBeNull]
        public virtual string? ScreenName { get; set; }

        public virtual int ScreenId { get; set; }

        public virtual int RowId { get; set; }

        [NotNull]
        public virtual string Command { get; set; }

        [CanBeNull]
        public virtual string? GroupName { get; set; }

        [CanBeNull]
        public virtual string? LastValue { get; set; }

        [CanBeNull]
        public virtual string? NewValue { get; set; }

        public virtual byte? DocStatus { get; set; }

        [CanBeNull]
        public virtual string? Comment { get; set; }

        public virtual int IsActive { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual Guid? ChangeSetId { get; set; }

        public virtual DateTime? TimeAssessment { get; set; }

        public virtual bool IsVisible { get; set; }

        protected TbInfoUpdateBase()
        {

        }

        public TbInfoUpdateBase(string tableName, string columnName, int screenId, int rowId, string command, int isActive, bool isVisible, string? screenName = null, string? groupName = null, string? lastValue = null, string? newValue = null, byte? docStatus = null, string? comment = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null, Guid? changeSetId = null, DateTime? timeAssessment = null)
        {

            Check.NotNull(tableName, nameof(tableName));
            Check.Length(tableName, nameof(tableName), TbInfoUpdateConsts.TableNameMaxLength, 0);
            Check.NotNull(columnName, nameof(columnName));
            Check.Length(columnName, nameof(columnName), TbInfoUpdateConsts.ColumnNameMaxLength, 0);
            Check.NotNull(command, nameof(command));
            Check.Length(command, nameof(command), TbInfoUpdateConsts.CommandMaxLength, 0); 
            Check.Length(comment, nameof(comment), TbInfoUpdateConsts.CommentMaxLength, 0);
            TableName = tableName;
            ColumnName = columnName;
            ScreenId = screenId;
            RowId = rowId;
            Command = command;
            IsActive = isActive;
            IsVisible = isVisible;
            ScreenName = screenName;
            GroupName = groupName;
            LastValue = lastValue;
            NewValue = newValue;
            DocStatus = docStatus;
            Comment = comment;
            this.crt_user = crt_user;
            this.crt_date = crt_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
            ChangeSetId = changeSetId;
            TimeAssessment = timeAssessment;
        }

    }
}