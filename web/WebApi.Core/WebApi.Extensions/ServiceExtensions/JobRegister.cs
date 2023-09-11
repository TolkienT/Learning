using Microsoft.AspNetCore.Builder;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Jobs;

namespace WebApi.Extensions.ServiceExtensions
{
    public static class JobRegister
    {
        public static async void RegisterJob(this IApplicationBuilder app)
        {
            var job = JobBuilder.Create<TestJob>()
                .WithIdentity("TestJob", "TestA")
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("TestTrigger", "TestA")
                .WithSimpleSchedule(x =>
                {
                    x.WithIntervalInSeconds(5).RepeatForever();
                }).Build();


            var factory = new StdSchedulerFactory();
            //创建任务调度器
            var scheduler = await factory.GetScheduler();
            //启动调度器
            await scheduler.Start();

            //将任务和触发器条件加入到任务调度器中
            await scheduler.ScheduleJob(job, trigger);


        }

    }
}
