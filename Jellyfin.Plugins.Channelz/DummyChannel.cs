using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Channels;
using MediaBrowser.Controller.Library;  // For later use
using MediaBrowser.Model;
using MediaBrowser.Model.Channels;

namespace Jellyfin.Plugins.Channelz
{
    public class DummyChannel : Channel
    {
        public DummyChannel()
        {
        }

        public override string Name => "Test Channelz";

        // public override string Description => "A dummy channel for testing – should appear in Live TV";

        // public override string DataVersion => "1";  // Required – simple version string

        // public string? HomePageUrl => null;  // Optional – can be a URL or null

        public ChannelParentalRating ParentalRating => ChannelParentalRating.GeneralAudience;

        public Task<ChannelItemResult> GetChannelItems(InternalChannelItemQuery query, CancellationToken cancellationToken)
        {
            // Return a single nonsense item to show in the guide
            var items = new List<ChannelItemInfo>
            {
                new ChannelItemInfo
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Nonsense Program",
                    Type = ChannelItemType.Media,
                    ContentType = ChannelMediaContentType.Movie,
                    MediaType = ChannelMediaType.Video,
                    // No real media source yet – this will error on play, but shows in guide
                }
            };

            return Task.FromResult(new ChannelItemResult
            {
                Items = items,
                TotalRecordCount = items.Count
            });
        }
    }
}
