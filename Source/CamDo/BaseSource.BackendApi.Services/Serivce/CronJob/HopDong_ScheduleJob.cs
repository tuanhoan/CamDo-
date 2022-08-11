using BaseSource.BackendApi.Services.Serivce.HopDong;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Serivce.CronJob
{
    public class HopDong_ScheduleJob : CronJobService
    {
        private readonly ILogger<HopDong_ScheduleJob> _logger;
        private readonly IHopDongService _hopDongService;

        public HopDong_ScheduleJob(IScheduleConfig<HopDong_ScheduleJob> config, ILogger<HopDong_ScheduleJob> logger,
            IHopDongService hopDongService)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            _hopDongService = hopDongService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ScheduleJob starts.");
            _hopDongService.TinhLaiToiNgayHienTai();
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} ScheduleJob is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ScheduleJob is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
