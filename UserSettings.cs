﻿namespace mcc_server
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal class UserSettings
    {
        public string MccIp { get; set; }
        public ushort MccPort { get; set; }
        public string DbIP { get; set; }
        public ushort DbPort { get; set; }
        public string DbName { get; set; }
        public string DbTableName { get; set; }
        public string HostIp { get; set; }
        public ushort HostPort { get; set; }
        public ushort ClientsPort { get; set; }
        public bool RunInBG { get; set; }
        public bool SaveSettings { get; set; }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
