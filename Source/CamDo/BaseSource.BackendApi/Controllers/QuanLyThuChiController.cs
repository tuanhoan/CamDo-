using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.ThuChi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Controllers
{
    [Route("api/thuchi")]
    public class QuanLyThuChiController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly ICuaHang_TransactionLogService _transactionLogService;

        public QuanLyThuChiController(BaseSourceDbContext db, ICuaHang_TransactionLogService transactionLogService)
        {
            _db = db;
            _transactionLogService = transactionLogService;
        }
        #region Thu
        [HttpPost]
        [Route("incomes")]
        public async Task<IActionResult> GetIncomes([FromBody] GetThuHoatDongPagingRequest model)
        {
            var query = _db.CuaHang_TransactionLogs.AsQueryable();
            query = query.Where(x => x.FeatureType == EFeatureType.Thu && x.CuaHangId == model.ShopId);

            if (model.Type.GetValueOrDefault() > 0)
            {
                query = query.Where(x => x.ActionType == model.Type);
            }
            if (model.From != null)
            {
                query = query.Where(x => x.CreatedDate > model.From);
            }
            if (model.To != null)
            {
                query = query.Where(x => x.CreatedDate < model.To.GetValueOrDefault().AddDays(1).AddMilliseconds(-1));
            }
            if (!string.IsNullOrEmpty(model.Customer))
            {
                model.Customer = model.Customer.ToLower();
                query = query.Where(x => x.TenKhachHang.ToLower().Contains(model.Customer));
            }
            var totalAmount = await query.Where(x => x.CanceledDate == null && x.ActionType!= (byte)EPhieuThu_ActionType.HuyPhieuThu).SumAsync(x => (double?)x.MoneyAdd);

            var data = await (from log in query
                              join user in _db.Users on log.UserId equals user.Id
                              join profile in _db.UserProfiles on user.Id equals profile.UserId
                              select new CuaHang_TransactionLogAdminVm()
                              {
                                  Id = log.Id,
                                  ActionType = log.ActionType,
                                  FeatureType = log.FeatureType,
                                  CreatedDate = log.CreatedDate,
                                  MoneyAdd = log.MoneyAdd,
                                  Note = log.Note,
                                  UserId = log.UserId,
                                  TenKhachHang = log.TenKhachHang,
                                  FullName = profile.FullName,
                                  UserName = user.UserName,
                                  CanceledDate = log.CanceledDate,
                                  MoneySub = log.MoneySub
                              }).OrderByDescending(x => x.CreatedDate).ToPagedListAsync(model.Page, model.PageSize);

            var pagedResult = new PagedResult<CuaHang_TransactionLogAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = await data.ToListAsync()
            };
            pagedResult.Items.Add(new CuaHang_TransactionLogAdminVm
            {
                MoneyAdd = totalAmount.GetValueOrDefault()
            });
            return Ok(new ApiSuccessResult<PagedResult<CuaHang_TransactionLogAdminVm>>(pagedResult));
        }


        [HttpPost]
        [Route("income")]
        public async Task<IActionResult> CreateIncome([FromBody] CreateThuHoatDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var result = await _transactionLogService.CreateCuaHang_TransactionLogThuChiVm(UserId, new CreateCuaHang_TransactionLogThuChiVm
            {
                ActionType = (byte)model.Type,
                FeatureType = EFeatureType.Thu,
                Note = model.Note,
                Amount = model.Amount,
                ShopId = model.ShopId,
                Customer = model.Customer
            });

            if (result.Key)
            {
                return Ok(new ApiSuccessResult<string>("Tạo mới hợp đồng thành công"));
            }
            return Ok(new ApiErrorResult<string>(result.Value));
        }

        [HttpPost]
        [Route("income/{id:long:min(1)}/delete")]
        public async Task<IActionResult> DeleteInCome(long id)
        {
            try
            {
                var transactionEntity = await _db.CuaHang_TransactionLogs.FindAsync(id);

                if (transactionEntity == null)
                {
                    return Ok(new ApiErrorResult<string>("Phiếu thu không tồn tại"));
                }

                //update time Cancel
                transactionEntity.CanceledDate = DateTime.Now;

                //add transaction by type HuyPhieuThu
                _db.CuaHang_TransactionLogs.Add(new CuaHang_TransactionLog
                {
                    Note = transactionEntity.Note,
                    ReferId = transactionEntity.ReferId,
                    UserId = UserId,
                    ActionType = (byte)EPhieuThu_ActionType.HuyPhieuThu,
                    CreatedDate = DateTime.Now,
                    FeatureType = EFeatureType.Thu,
                    CuaHangId = transactionEntity.CuaHangId,
                    MoneySub = transactionEntity.MoneyAdd,
                    TenKhachHang = transactionEntity.TenKhachHang,
                });

                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>("Xóa phiếu thu thành công"));
            }
            catch (Exception ex)
            {
                return Ok(new ApiErrorResult<string>("Xóa phiếu thu không thành công"));
            }
        }
        #endregion

        #region Chi
        [HttpPost]
        [Route("Expenses")]
        public async Task<IActionResult> GetExpenses([FromBody] GetChiHoatDongPagingRequest model)
        {
            var query = _db.CuaHang_TransactionLogs.AsQueryable();
            query = query.Where(x => x.FeatureType == EFeatureType.Chi && x.CuaHangId == model.ShopId);

            if (model.Type.GetValueOrDefault() > 0)
            {
                query = query.Where(x => x.ActionType == model.Type);
            }
            if (model.From != null)
            {
                query = query.Where(x => x.CreatedDate > model.From);
            }
            if (model.To != null)
            {
                query = query.Where(x => x.CreatedDate < model.To.GetValueOrDefault().AddDays(1).AddMilliseconds(-1));
            }
            if (!string.IsNullOrEmpty(model.Customer))
            {
                model.Customer = model.Customer.ToLower();
                query = query.Where(x => x.TenKhachHang.ToLower().Contains(model.Customer));
            }
            var totalAmount = await query.Where(x => x.CanceledDate == null && x.ActionType!= (byte)EPhieuChi_ActionType.HuyPhieuChi).SumAsync(x => (double?)x.MoneySub);

            var data = await (from log in query
                              join user in _db.Users on log.UserId equals user.Id
                              join profile in _db.UserProfiles on user.Id equals profile.UserId
                              select new CuaHang_TransactionLogAdminVm()
                              {
                                  Id = log.Id,
                                  ActionType = log.ActionType,
                                  FeatureType = log.FeatureType,
                                  CreatedDate = log.CreatedDate,
                                  MoneyAdd = log.MoneyAdd,
                                  Note = log.Note,
                                  UserId = log.UserId,
                                  TenKhachHang = log.TenKhachHang,
                                  FullName = profile.FullName,
                                  UserName = user.UserName,
                                  CanceledDate = log.CanceledDate,
                                  MoneySub = log.MoneySub
                              }).OrderByDescending(x => x.CreatedDate).ToPagedListAsync(model.Page, model.PageSize);

            var pagedResult = new PagedResult<CuaHang_TransactionLogAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = await data.ToListAsync()
            };
            pagedResult.Items.Add(new CuaHang_TransactionLogAdminVm
            {
                MoneySub = totalAmount.GetValueOrDefault()
            });
            return Ok(new ApiSuccessResult<PagedResult<CuaHang_TransactionLogAdminVm>>(pagedResult));
        }


        [HttpPost]
        [Route("Expense")]
        public async Task<IActionResult> CreateExpense([FromBody] CreateChiHoatDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var result = await _transactionLogService.CreateCuaHang_TransactionLogThuChiVm(UserId, new CreateCuaHang_TransactionLogThuChiVm
            {
                ActionType = (byte)model.Type,
                FeatureType = EFeatureType.Chi,
                Note = model.Note,
                Amount = model.Amount,
                ShopId = model.ShopId,
                Customer = model.Customer
            });

            if (result.Key)
            {
                return Ok(new ApiSuccessResult<string>("Tạo mới phiếu chi thành công"));
            }
            return Ok(new ApiErrorResult<string>(result.Value));
        }

        [HttpPost]
        [Route("Expense/{id:long:min(1)}/delete")]
        public async Task<IActionResult> DeleteExpense(long id)
        {
            try
            {
                var transactionEntity = await _db.CuaHang_TransactionLogs.FindAsync(id);

                if (transactionEntity == null)
                {
                    return Ok(new ApiErrorResult<string>("Phiếu chi không tồn tại"));
                }

                //update time Cancel
                transactionEntity.CanceledDate = DateTime.Now;

                //add transaction by type HuyPhieuChi
                _db.CuaHang_TransactionLogs.Add(new CuaHang_TransactionLog
                {
                    Note = transactionEntity.Note,
                    ReferId = transactionEntity.ReferId,
                    UserId = UserId,
                    ActionType = (byte)EPhieuChi_ActionType.HuyPhieuChi,
                    CreatedDate = DateTime.Now,
                    FeatureType = EFeatureType.Chi,
                    CuaHangId = transactionEntity.CuaHangId,
                    MoneyAdd = transactionEntity.MoneySub,
                    TenKhachHang = transactionEntity.TenKhachHang,
                });

                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>("Xóa phiếu chi thành công"));
            }
            catch (Exception ex)
            {
                return Ok(new ApiErrorResult<string>("Xóa phiếu chi không thành công"));
            }
        }
        #endregion
    }
}
