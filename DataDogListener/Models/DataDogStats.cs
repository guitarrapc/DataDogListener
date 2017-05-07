using DatadogSharp.DogStatsd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataDogListener.Models
{
    public enum DataDogPostType
    {
        Increment,
        Decrement,
        Gauge,
        Histogram,
        Set,
        Timer,
        Event,
        ServiceCheck,
    }

    public interface IDataDogStats
    {
        //DataDogPostType DataDogType { get; }
        string MetricName { get; set; }
        double SampleRates { get; set; }
        string[] Tags { get; set; }
    }

    public class DataDogIncrementMetricStats : IDataDogStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.Increment; } }
        public string MetricName { get; set; }
        public double SampleRates { get; set; } = 1.0;
        public string[] Tags { get; set; }
        public long? Value { get; set; }

        public DataDogIncrementMetricStats(string metricName)
        {
            MetricName = metricName;
        }

        public void Send(long value)
        {
            DatadogStats.Default.Increment(MetricName, value, SampleRates, Tags);
        }
    }

    public class DataDogDecrementMetricStats : IDataDogStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.Decrement; } }
        public string MetricName { get; set; }
        public double SampleRates { get; set; } = 1.0;
        public string[] Tags { get; set; }
        public long? Value { get; set; }

        public DataDogDecrementMetricStats(string metricName)
        {
            MetricName = metricName;
        }

        public void Send(long value)
        {
            DatadogStats.Default.Decrement(MetricName, value, SampleRates, Tags);
        }
    }

    public class DataDogGaugeMetricStats : IDataDogStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.Gauge; } }
        public string MetricName { get; set; }
        public double SampleRates { get; set; } = 1.0;
        public string[] Tags { get; set; }
        public long? LongValue { get; set; }
        public double? DoubleValue { get; set; }

        public DataDogGaugeMetricStats(string metricName)
        {
            MetricName = metricName;
        }

        public void Send(long value)
        {
            DatadogStats.Default.Gauge(MetricName, value, SampleRates, Tags);
        }

        public void Send(double value)
        {
            DatadogStats.Default.Gauge(MetricName, value, SampleRates, Tags);
        }
    }

    public class DataDogHistogramMetricStats : IDataDogStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.Histogram; } }
        public string MetricName { get; set; }
        public double SampleRates { get; set; } = 1.0;
        public string[] Tags { get; set; }
        public long? LongValue { get; set; }
        public double? DoubleValue { get; set; }

        public DataDogHistogramMetricStats(string metricName)
        {
            MetricName = metricName;
        }

        public void Send(long value)
        {
            DatadogStats.Default.Histogram(MetricName, value, SampleRates, Tags);
        }

        public void Send(double value)
        {
            DatadogStats.Default.Histogram(MetricName, value, SampleRates, Tags);
        }
    }

    public class DataDogSetMetricStats : IDataDogStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.Set; } }
        public string MetricName { get; set; }
        public double SampleRates { get; set; } = 1.0;
        public string[] Tags { get; set; }
        public long? LongValue { get; set; }
        public double? DoubleValue { get; set; }

        public DataDogSetMetricStats(string metricName)
        {
            MetricName = metricName;
        }

        public void Send(long value)
        {
            DatadogStats.Default.Set(MetricName, value, SampleRates, Tags);
        }

        public void Send(double value)
        {
            DatadogStats.Default.Set(MetricName, value, SampleRates, Tags);
        }
    }

    public class DataDogTimerMetricStats : IDataDogStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.Timer; } }
        public string MetricName { get; set; }
        public double SampleRates { get; set; } = 1.0;
        public string[] Tags { get; set; }
        public long? LongValue { get; set; }
        public double? DoubleValue { get; set; }

        public DataDogTimerMetricStats(string metricName)
        {
            MetricName = metricName;
        }

        public void Send(long value)
        {
            DatadogStats.Default.Timer(MetricName, value, SampleRates, Tags);
        }

        public void Send(double value)
        {
            DatadogStats.Default.Timer(MetricName, value, SampleRates, Tags);
        }
    }

    public class DataDogEventMetricStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.Event; } }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? DateHappened { get; set; } = null;
        public string HostName { get; set; } = null;
        public string AggregationKey { get; set; } = null;
        public Priority Priority { get; set; } = Priority.Normal;
        public string SourceTypeName { get; set; } = null;
        public AlertType AlertType { get; set; } = AlertType.Info;
        public string[] Tags { get; set; }
        public bool TruncateText { get; set; } = true;

        public DataDogEventMetricStats(string title, string text)
        {
            Title = title;
            Text = text;
        }

        public void Send()
        {
            DatadogStats.Default.Event(Title, Text, DateHappened, HostName, AggregationKey, Priority, SourceTypeName, AlertType, Tags, TruncateText);
        }
    }

    public class DataDogServiceCheckMetricStats
    {
        public DataDogPostType DataDogType { get { return DataDogPostType.ServiceCheck; } }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? TimeStamp { get; set; } = null;
        public string HostName { get; set; } = null;
        public string[] Tags { get; set; }
        public string ServiceCheckMessage { get; set; } = null;
        public bool TruncateText { get; set; } = true;

        public DataDogServiceCheckMetricStats(string title, string status)
        {
            Name = title;
            Status = status;
        }

        public void Send()
        {
            DatadogStats.Default.ServiceCheck(Name, Status, TimeStamp, HostName, Tags, ServiceCheckMessage, TruncateText);
        }
    }
}