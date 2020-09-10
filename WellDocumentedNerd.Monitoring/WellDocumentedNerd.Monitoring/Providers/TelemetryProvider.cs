using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Text;
using WellDocumentedNerd.Monitoring.Interfaces;

namespace WellDocumentedNerd.Monitoring.Providers
{
    public class TelemetryProvider : ITelemetryProvider
    {
        private TelemetryClient _client;
        public Guid CorrelationKey { get; set; }

        public TelemetryProvider()
        {
            _client = new TelemetryClient(TelemetryConfiguration.CreateDefault());
            CorrelationKey = Guid.NewGuid();
        }
        public void TrackEvent(string name)
        {
            var properties = this.AddCorrelationKey();
            _client.TrackEvent(name, properties);
        }

        public void TrackEvent(string name, Dictionary<string, string> properties)
        {
            properties = this.AddCorrelationKey(properties);
            _client.TrackEvent(name, properties);
        }

        public void TrackEvent(string name, Dictionary<string, string> properties, Dictionary<string, double> metrics)
        {
            properties = this.AddCorrelationKey(properties);
            _client.TrackEvent(name, properties, metrics);
        }

        public void TrackMetric(string name, double value)
        {
            var properties = this.AddCorrelationKey();
            _client.TrackMetric(name, value, properties);
        }

        public void TrackException(Exception ex)
        {
            var properties = this.AddCorrelationKey();
            _client.TrackException(ex, properties);
        }

        public void TrackDependency(string name, string typeName, string data, DateTime startTime, TimeSpan duration, bool success)
        {
            _client.TrackDependency(typeName, name, data, startTime, duration, success);
        }

        private Dictionary<string, string> AddCorrelationKey()
        {
            var properties = new Dictionary<string, string>();
            return this.AddCorrelationKey(properties);
        }

        private Dictionary<string, string> AddCorrelationKey(Dictionary<string, string> properties)
        {
            properties.Add("CorrelationKey", CorrelationKey.ToString());
            return properties;
        }
    }
}
