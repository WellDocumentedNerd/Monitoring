using System;
using System.Collections.Generic;
using System.Text;

namespace WellDocumentedNerd.Monitoring.Interfaces
{
    public interface ITelemetryProvider
    {
        Guid CorrelationKey { get; set; }

        void TrackDependency(string name, string typeName, string data, DateTime startTime, TimeSpan duration, bool success);
        void TrackEvent(string name);
        void TrackEvent(string name, Dictionary<string, string> properties);
        void TrackEvent(string name, Dictionary<string, string> properties, Dictionary<string, double> metrics);
        void TrackException(Exception ex);
        void TrackMetric(string name, double value);
    }
}
