using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class MergeRequest
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("iid")]
        public long Iid { get; set; }

        [JsonPropertyName("project_id")]
        public long ProjectId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("merged_by")]
        public Assignee MergedBy { get; set; }

        [JsonPropertyName("merged_at")]
        public DateTimeOffset? MergedAt { get; set; }

        [JsonPropertyName("closed_by")]
        public User ClosedBy { get; set; }

        [JsonPropertyName("closed_at")]
        public DateTimeOffset? ClosedAt { get; set; }

        [JsonPropertyName("target_branch")]
        public string TargetBranch { get; set; }

        [JsonPropertyName("source_branch")]
        public string SourceBranch { get; set; }

        [JsonPropertyName("user_notes_count")]
        public long UserNotesCount { get; set; }

        [JsonPropertyName("upvotes")]
        public long Upvotes { get; set; }

        [JsonPropertyName("downvotes")]
        public long Downvotes { get; set; }

        [JsonPropertyName("author")]
        public Assignee Author { get; set; }

        [JsonPropertyName("assignees")]
        public Assignee[] Assignees { get; set; }

        [JsonPropertyName("assignee")]
        public Assignee Assignee { get; set; }

        [JsonPropertyName("source_project_id")]
        public long SourceProjectId { get; set; }

        [JsonPropertyName("target_project_id")]
        public long TargetProjectId { get; set; }

        [JsonPropertyName("labels")]
        public string[] Labels { get; set; }

        [JsonPropertyName("work_in_progress")]
        public bool WorkInProgress { get; set; }

        [JsonPropertyName("milestone")]
        public Milestone Milestone { get; set; }

        [JsonPropertyName("merge_when_pipeline_succeeds")]
        public bool MergeWhenPipelineSucceeds { get; set; }

        [JsonPropertyName("merge_status")]
        public string MergeStatus { get; set; }

        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("merge_commit_sha")]
        public string MergeCommitSha { get; set; }

        [JsonPropertyName("squash_commit_sha")]
        public object SquashCommitSha { get; set; }

        [JsonPropertyName("discussion_locked")]
        public object DiscussionLocked { get; set; }

        [JsonPropertyName("should_remove_source_branch")]
        public bool? ShouldRemoveSourceBranch { get; set; }

        [JsonPropertyName("force_remove_source_branch")]
        public bool? ForceRemoveSourceBranch { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("references")]
        public References References { get; set; }

        [JsonPropertyName("web_url")]
        public Uri WebUrl { get; set; }

        [JsonPropertyName("time_stats")]
        public TimeStats TimeStats { get; set; }

        [JsonPropertyName("squash")]
        public bool Squash { get; set; }

        [JsonPropertyName("task_completion_status")]
        public TaskCompletionStatus TaskCompletionStatus { get; set; }

        [JsonPropertyName("has_conflicts")]
        public bool HasConflicts { get; set; }

        [JsonPropertyName("blocking_discussions_resolved")]
        public bool BlockingDiscussionsResolved { get; set; }

        [JsonPropertyName("changes_count")]
        public string ChangesCount { get; set; }

        [JsonPropertyName("latest_build_started_at")]
        public DateTimeOffset? LatestBuildStartedAt { get; set; }

        [JsonPropertyName("latest_build_finished_at")]
        public DateTimeOffset? LatestBuildFinishedAt { get; set; }

        [JsonPropertyName("first_deployed_to_production_at")]
        public object FirstDeployedToProductionAt { get; set; }

        [JsonPropertyName("pipeline")]
        public Pipeline Pipeline { get; set; }

        [JsonPropertyName("head_pipeline")]
        public HeadPipeline HeadPipeline { get; set; }

        [JsonPropertyName("diff_refs")]
        public DiffRefs DiffRefs { get; set; }

        [JsonPropertyName("merge_error")]
        public object MergeError { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
