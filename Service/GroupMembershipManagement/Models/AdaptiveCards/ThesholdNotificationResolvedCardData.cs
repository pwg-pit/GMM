// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;

namespace Models.AdaptiveCards
{
    public class ThesholdNotificationResolvedCardData
    {
        public string GroupName { get; set; }
        public int ChangeQuantityForAdditions { get; set; }
        public int ChangeQuantityForRemovals { get; set; }
        public int ChangePercentageForAdditions { get; set; }
        public int ChangePercentageForRemovals { get; set; }
        public int ThresholdPercentageForAdditions { get; set; }
        public int ThresholdPercentageForRemovals { get; set; }
        public string NotificationId { get; set; }
        public string ResolvedByUPN { get; set; }
        public string ResolvedTime { get; set; }
        public string Resolution { get; set; }
        public string ProviderId { get; set; }
        public DateTime CardCreatedTime { get; set; }
    }
}
