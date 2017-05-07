using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataDogListener.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataDogListener.Controllers
{
    [Route("api/datadog/[controller]")]
    public class IncrementController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogIncrementMetricStats stat)
        {
            // Invalid
            if (stat.MetricName == null) return;
            if (stat.Value == null) return;
            stat.Send(stat.Value.Value);
        }
    }

    [Route("api/datadog/[controller]")]
    public class DecrementController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogDecrementMetricStats stat)
        {
            // Invalid
            if (stat.MetricName == null) return;
            if (stat.Value == null) return;
            stat.Send(stat.Value.Value);
        }
    }

    [Route("api/datadog/[controller]")]
    public class GaugeController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogGaugeMetricStats stat)
        {
            // Invalid
            if (stat.MetricName == null) return;

            if (stat.LongValue != null)
            {
                stat.Send(stat.LongValue.Value);
            }
            else if (stat.DoubleValue != null)
            {
                stat.Send(stat.DoubleValue.Value);
            }
        }
    }

    [Route("api/datadog/[controller]")]
    public class HistogramController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogHistogramMetricStats stat)
        {
            // Invalid
            if (stat.MetricName == null) return;

            if (stat.LongValue != null)
            {
                stat.Send(stat.LongValue.Value);
            }
            else if (stat.DoubleValue != null)
            {
                stat.Send(stat.DoubleValue.Value);
            }
        }
    }

    [Route("api/datadog/[controller]")]
    public class SetController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogSetMetricStats stat)
        {
            // Invalid
            if (stat.MetricName == null) return;

            if (stat.LongValue != null)
            {
                stat.Send(stat.LongValue.Value);
            }
            else if (stat.DoubleValue != null)
            {
                stat.Send(stat.DoubleValue.Value);
            }
        }
    }

    [Route("api/datadog/[controller]")]
    public class TimerController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogTimerMetricStats stat)
        {
            // Invalid
            if (stat.MetricName == null) return;

            if (stat.LongValue != null)
            {
                stat.Send(stat.LongValue.Value);
            }
            else if (stat.DoubleValue != null)
            {
                stat.Send(stat.DoubleValue.Value);
            }
        }
    }

    [Route("api/datadog/[controller]")]
    public class EventController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogEventMetricStats stat)
        {
            // Invalid
            if (stat.Title == null) return;
            if (stat.Text == null) return;

            stat.Send();
        }
    }

    [Route("api/datadog/[controller]")]
    public class ServiceCheckController : Controller
    {
        [HttpPost]
        public async Task Post([FromBody]DataDogServiceCheckMetricStats stat)
        {
            // Invalid
            if (stat.Name == null) return;
            if (stat.Status == null) return;

            stat.Send();
        }
    }
}
