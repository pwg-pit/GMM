// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using Repositories.Contracts.InjectConfig;

namespace Services.Entities
{
    public class AzureTableBackup : IAzureTableBackup
    {
        public string SourceTableName { get; }
        public string SourceConnectionString { get; }
        public string DestinationConnectionString { get; }
        public string BackupType { get; }
        public bool CleanupOnly { get; }
        public int DeleteAfterDays { get; }

        public AzureTableBackup(string sourceTableName, string sourceConnectionString, string destinationConnectionString, string backupType, bool cleanupOnly, int deleteAfterDays)
        {
            SourceTableName = sourceTableName;
            SourceConnectionString = sourceConnectionString;
            DestinationConnectionString = destinationConnectionString;
            BackupType = backupType;
            CleanupOnly = cleanupOnly;
            DeleteAfterDays = deleteAfterDays;
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            return (SourceTableName == ((AzureTableBackup) other).SourceTableName)
                && (SourceConnectionString == ((AzureTableBackup)other).SourceConnectionString)
                && (DestinationConnectionString == ((AzureTableBackup) other).DestinationConnectionString)
                && (BackupType == ((AzureTableBackup) other).BackupType)
                && (CleanupOnly == ((AzureTableBackup) other).CleanupOnly)
                && (DeleteAfterDays == ((AzureTableBackup) other).DeleteAfterDays);
        }

        public override int GetHashCode()
        {
            return SourceTableName.GetHashCode() 
                ^ SourceConnectionString.GetHashCode()
                ^ DestinationConnectionString.GetHashCode()
                ^ BackupType.GetHashCode()
                ^ CleanupOnly.GetHashCode()
                ^ DeleteAfterDays.GetHashCode();
        }
    }
}
