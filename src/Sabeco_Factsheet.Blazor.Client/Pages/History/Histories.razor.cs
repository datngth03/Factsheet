using Blazorise;
using Blazorise.DataGrid;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.TbInfoUpdates;
using Sabeco_Factsheet.TbCompanies;
using Sabeco_Factsheet.TbNationalities;
using Sabeco_Factsheet.TbPersons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Microsoft.AspNetCore.Components;
using Sabeco_Factsheet.TsClasses;
using Sabeco_Factsheet.TbUsers;

namespace Sabeco_Factsheet.Blazor.Client.Pages.History
{
    public partial class Histories
    { 
        private List<TbInfoUpdateDto> TbInfoUpdateList { get; set; } = new List<TbInfoUpdateDto>();

        [Parameter]
        public List<TbUserDto> UserList { get; set; }
        
        [Parameter]
        public List<TsClassDto> TypeClassList { get; set; }

        [Parameter]
        public List<TsClassDto> ReportClassList { get; set; }

        [Parameter]
        public List<TsClassDto> ReportKindClassList { get; set; }

        [Parameter]
        public IEnumerable<IGrouping<Guid?, TbInfoUpdateDto>> GroupedChanges { get; set; }

        [Parameter]
        public string screenName { get; set; }

        [Parameter]
        public int screenId { get; set; }
         
        [Parameter]
        public bool isAll { get; set; } = false;

        [Parameter]
        public bool isColumn1Visible { get; set; }

        [Parameter]
        public bool isColumn2Visible { get; set; }
         
        private List<TbInfoUpdateUpdateDto> InfoUpdateList = new List<TbInfoUpdateUpdateDto> { };
         
        public async Task GetGroupedChangesAsync()
        {
            if (TbInfoUpdateList.Count() > 0)
            {
                if (isAll)
                {
                    screenId = 0;
                    GroupedChanges = TbInfoUpdateList
                    .Where(x => x.ChangeSetId.HasValue && x.ScreenName == screenName && x.IsVisible == true)
                    .GroupBy(x => x.ChangeSetId)
                    .ToList();
                }
                else
                { 
                    GroupedChanges = TbInfoUpdateList
                    .Where(x => x.ChangeSetId.HasValue && x.ScreenName == screenName && x.ScreenId == screenId && x.IsVisible == true)
                    .GroupBy(x => x.ChangeSetId)
                    .ToList();
                }
            }
            else
            {
                await UiMessageService.Warn(L["NoHistoryAvailable"]);
            }

            await InvokeAsync(StateHasChanged);
        }



        //================================== ToolBar - Breadcrumb - Permission =======================================
           
        public static string TruncateText(string text, int maxLength)
        {
            if (text != null)
            {
                if (text.Length <= maxLength)
                    return text;
                return text.Substring(0, maxLength) + "...";
            }
            return "";
        }

    }
}
