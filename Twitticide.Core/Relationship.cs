using System;
using System.Collections.Generic;
using System.Linq;

namespace Twitticide
{
    public class Relationship
    {
        public class FollowEvent //TODO: make private; only public for serialising
        {
            public FollowEvent() { }

            public FollowEvent(bool isFollowing)
            {
                IsFollowing = isFollowing;
                Timestamp = DateTime.Now;
            }

            public bool IsFollowing { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public enum StatusEnum
        {
            NotFollowing,
            Following,
            Unfollowed,
        }

        public List<FollowEvent> Events { get; set; } //TODO: make private; only public for serialising

        public Relationship()
        {
            Events = new List<FollowEvent>();
        }

        public void UpdateFollowStatus(bool isFollowing)
        {
            if (!Events.Any())
            {
                Events.Add(new FollowEvent(isFollowing));
                return;
            }

            if (GetLatestStatus() != isFollowing) Events.Add(new FollowEvent(isFollowing));
        }

        public StatusEnum Status {
            get
            {
                if(!Events.Any()) return StatusEnum.NotFollowing;
                
                var isFollowing = GetLatestStatus();
                
                if(isFollowing) return StatusEnum.Following;
                
                if(Events.Any(e=>e.IsFollowing)) return StatusEnum.Unfollowed;

                return StatusEnum.NotFollowing;
            }
        }

        private bool GetLatestStatus()
        {
            if (!Events.Any()) return false;
            return Events.Last().IsFollowing;
        }

        public FollowEvent GetLatestEvent()
        {
            if (!Events.Any()) return null;
            return Events.Last();
        }
    }
}