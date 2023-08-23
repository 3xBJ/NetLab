using NetLab.GitLab.Modelos.GitLab;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.Modelos.Entidades.GitLab
{

    public class Issue
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

        [JsonPropertyName("closed_at")]
        public string ClosedAt { get; set; }

        [JsonPropertyName("closed_by")]
        public User ClosedBy { get; set; }

        [JsonPropertyName("labels")]
        public IEnumerable<string> Labels { get; set; }

        [JsonPropertyName("milestone")]
        public Milestone Milestone { get; set; }

        [JsonPropertyName("assignees")]
        public IEnumerable<Author> Assignees { get; set; }

        [JsonPropertyName("author")]
        public Author Author { get; set; }

        [JsonPropertyName("assignee")]
        public Author Assignee { get; set; }

        [JsonPropertyName("user_notes_count")]
        public long UserNotesCount { get; set; }

        [JsonPropertyName("merge_requests_count")]
        public long MergeRequestsCount { get; set; }

        [JsonPropertyName("upvotes")]
        public long Upvotes { get; set; }

        [JsonPropertyName("downvotes")]
        public long Downvotes { get; set; }

        [JsonPropertyName("due_date")]
        public DateTimeOffset? DueDate { get; set; }

        [JsonPropertyName("confidential")]
        public bool Confidential { get; set; }

        [JsonPropertyName("discussion_locked")]
        public string DiscussionLocked { get; set; }

        [JsonPropertyName("web_url")]
        public Uri WebUrl { get; set; }

        [JsonPropertyName("time_stats")]
        public TimeStats TimeStats { get; set; }

        [JsonPropertyName("task_completion_status")]
        public TaskCompletionStatus TaskCompletionStatus { get; set; }

        [JsonPropertyName("has_tasks")]
        public bool HasTasks { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("references")]
        public References References { get; set; }

        [JsonPropertyName("moved_to_id")]
        public string MovedToId { get; set; }
    }
}
