using System;

namespace ConsoleApp1
{
    public class LegacyEvent
    {
        public Guid Id { get; set; }

        public Guid PerformedById { get; set; }

        public Guid PerformedOnId { get; set; }

        public int PerformedOnOfficeId { get; set; }

        public int PerformedByOfficeId { get; set; }

        public bool IsEventProcessed { get; set; }

        public bool IsPerformedByUserProcessed { get; set; }

        public bool IsPerformedOnUserProcessed { get; set; }

        public bool IsPerformedByOfficeProcessed { get; set; }

        public bool IsPerformedOnOfficeProcessed { get; set; }
    }
}