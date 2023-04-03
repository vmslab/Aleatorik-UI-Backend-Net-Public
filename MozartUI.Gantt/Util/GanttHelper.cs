using System.Collections.Generic;

namespace MozartUI.Gantt
{
    public static class GanttHelper
    {
        public static void SetLevel(List<GanttTask> tasks, out int count)
        {
            SetLevel(tasks, new List<GanttMilestone>(), false, out count);
        }

        public static void SetLevel(List<GanttTask> tasks, bool containsEqual, out int count)
        {
            SetLevel(tasks, new List<GanttMilestone>(), containsEqual, out count);
        }

        public static void SetLevel(List<GanttTask> tasks, List<GanttMilestone> milestones, out int count)
        {
            SetLevel(tasks, milestones, false, out count);
        }

        public static void SetLevel(List<GanttTask> tasks, List<GanttMilestone> milestones, bool containsEqual, out int count)
        {
            var prevRanges = new List<DateTimeRange>();

            if (tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    var taskRange = new DateTimeRange(task.StartTime, task.EndTime);
                    if (prevRanges.Count > 0)
                    {
                        int idx = 0;
                        foreach (var prevRange in prevRanges)
                        {
                            if (!prevRange.IsOverlaps(taskRange, containsEqual)) break;
                            idx++;
                        }
                        if (prevRanges.Count > idx)
                        {
                            prevRanges[idx] = taskRange;
                        }
                        else
                        {
                            prevRanges.Add(taskRange);
                        }
                        task.Level = idx + 1;
                    }
                    else
                    {
                        prevRanges.Add(taskRange);
                    }
                }
            }

            if (milestones.Count > 0)
            {
                foreach (var milestone in milestones)
                {
                    var milestoneRange = new DateTimeRange(milestone.Time, milestone.Time);
                    if (prevRanges.Count > 0)
                    {
                        int idx = 0;
                        foreach (var prevRange in prevRanges)
                        {
                            if (!prevRange.IsOverlaps(milestoneRange, containsEqual)) break;
                            idx++;
                        }
                        if (prevRanges.Count > idx)
                        {
                            prevRanges[idx] = milestoneRange;
                        }
                        else
                        {
                            prevRanges.Add(milestoneRange);
                        }
                        milestone.Level = idx + 1;
                    }
                    else
                    {
                        prevRanges.Add(milestoneRange);
                    }
                }
            }

            count = prevRanges.Count > 0 ? prevRanges.Count : 1;
        }
    }
}
