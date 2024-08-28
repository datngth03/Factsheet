using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Sabeco_Factsheet.Permissions;
using Sabeco_Factsheet.TbCompanyBoards;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBoards
{

    [Authorize(Sabeco_FactsheetPermissions.TbCompanyBoards.Default)]
    public abstract class TbCompanyBoardsAppServiceBase : Sabeco_FactsheetAppService
    {
        protected IDistributedCache<TbCompanyBoardDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITbCompanyBoardRepository _tbCompanyBoardRepository;
        protected TbCompanyBoardManager _tbCompanyBoardManager;

        public TbCompanyBoardsAppServiceBase(ITbCompanyBoardRepository tbCompanyBoardRepository, TbCompanyBoardManager tbCompanyBoardManager, IDistributedCache<TbCompanyBoardDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _tbCompanyBoardRepository = tbCompanyBoardRepository;
            _tbCompanyBoardManager = tbCompanyBoardManager;

        }

        public virtual async Task<PagedResultDto<TbCompanyBoardDto>> GetListAsync(GetTbCompanyBoardsInput input)
        {
            var totalCount = await _tbCompanyBoardRepository.GetCountAsync(input.FilterText, input.BranchCode, input.CompanyCode, input.PersonCode, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
            var items = await _tbCompanyBoardRepository.GetListAsync(input.FilterText, input.BranchCode, input.CompanyCode, input.PersonCode, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TbCompanyBoardDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TbCompanyBoard>, List<TbCompanyBoardDto>>(items)
            };
        }

        public virtual async Task<TbCompanyBoardDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TbCompanyBoard, TbCompanyBoardDto>(await _tbCompanyBoardRepository.GetAsync(id));
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBoards.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _tbCompanyBoardRepository.DeleteAsync(id);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBoards.Create)]
        public virtual async Task<TbCompanyBoardDto> CreateAsync(TbCompanyBoardCreateDto input)
        {

            var tbCompanyBoard = await _tbCompanyBoardManager.CreateAsync(
            input.CompanyCode, input.PersonCode, input.IsActive, input.IsDeleted, input.BranchCode, input.FromDate, input.ToDate, input.PositionCode, input.PersonalValue, input.OwnerValue, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyBoard, TbCompanyBoardDto>(tbCompanyBoard);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBoards.Edit)]
        public virtual async Task<TbCompanyBoardDto> UpdateAsync(int id, TbCompanyBoardUpdateDto input)
        {

            var tbCompanyBoard = await _tbCompanyBoardManager.UpdateAsync(
            id,
            input.CompanyCode, input.PersonCode, input.IsActive, input.IsDeleted, input.BranchCode, input.FromDate, input.ToDate, input.PositionCode, input.PersonalValue, input.OwnerValue, input.Note, input.crt_date, input.crt_user, input.mod_date, input.mod_user
            );

            return ObjectMapper.Map<TbCompanyBoard, TbCompanyBoardDto>(tbCompanyBoard);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBoardExcelDownloadDto input, string fileName)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tbCompanyBoardRepository.GetListAsync(input.FilterText, input.BranchCode, input.CompanyCode, input.PersonCode, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TbCompanyBoard>, List<TbCompanyBoardExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, $"{fileName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBoards.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> tbcompanyboardIds)
        {
            await _tbCompanyBoardRepository.DeleteManyAsync(tbcompanyboardIds);
        }

        [Authorize(Sabeco_FactsheetPermissions.TbCompanyBoards.Delete)]
        public virtual async Task DeleteAllAsync(GetTbCompanyBoardsInput input)
        {
            await _tbCompanyBoardRepository.DeleteAllAsync(input.FilterText, input.BranchCode, input.CompanyCode, input.PersonCode, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PositionCode, input.PersonalValueMin, input.PersonalValueMax, input.OwnerValueMin, input.OwnerValueMax, input.Note, input.IsActive, input.crt_dateMin, input.crt_dateMax, input.crt_userMin, input.crt_userMax, input.mod_dateMin, input.mod_dateMax, input.mod_userMin, input.mod_userMax, input.IsDeleted);
        }
        public virtual async Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TbCompanyBoardDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new Sabeco_Factsheet.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}