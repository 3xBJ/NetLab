using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Project
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_with_namespace")]
        public string NameWithNamespace { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("path_with_namespace")]
        public string PathWithNamespace { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("default_branch")]
        public string DefaultBranch { get; set; }

        [JsonPropertyName("tag_list")]
        public object[] TagList { get; set; }

        [JsonPropertyName("ssh_url_to_repo")]
        public string SshUrlToRepo { get; set; }

        [JsonPropertyName("http_url_to_repo")]
        public Uri HttpUrlToRepo { get; set; }

        [JsonPropertyName("web_url")]
        public Uri WebUrl { get; set; }

        [JsonPropertyName("readme_url")]
        public object ReadmeUrl { get; set; }

        [JsonPropertyName("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonPropertyName("forks_count")]
        public long ForksCount { get; set; }

        [JsonPropertyName("star_count")]
        public long StarCount { get; set; }

        [JsonPropertyName("last_activity_at")]
        public DateTimeOffset LastActivityAt { get; set; }

        [JsonPropertyName("namespace")]
        public Namespace Namespace { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("packages_enabled")]
        public bool PackagesEnabled { get; set; }

        [JsonPropertyName("empty_repo")]
        public bool EmptyRepo { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        [JsonPropertyName("resolve_outdated_diff_discussions")]
        public bool ResolveOutdatedDiffDiscussions { get; set; }

        [JsonPropertyName("container_registry_enabled")]
        public bool ContainerRegistryEnabled { get; set; }

        [JsonPropertyName("container_expiration_policy")]
        public ContainerExpirationPolicy ContainerExpirationPolicy { get; set; }

        [JsonPropertyName("issues_enabled")]
        public bool IssuesEnabled { get; set; }

        [JsonPropertyName("merge_requests_enabled")]
        public bool MergeRequestsEnabled { get; set; }

        [JsonPropertyName("wiki_enabled")]
        public bool WikiEnabled { get; set; }

        [JsonPropertyName("jobs_enabled")]
        public bool JobsEnabled { get; set; }

        [JsonPropertyName("snippets_enabled")]
        public bool SnippetsEnabled { get; set; }

        [JsonPropertyName("service_desk_enabled")]
        public bool ServiceDeskEnabled { get; set; }

        [JsonPropertyName("service_desk_address")]
        public object ServiceDeskAddress { get; set; }

        [JsonPropertyName("can_create_merge_request_in")]
        public bool CanCreateMergeRequestIn { get; set; }

        [JsonPropertyName("issues_access_level")]
        public string IssuesAccessLevel { get; set; }

        [JsonPropertyName("repository_access_level")]
        public string RepositoryAccessLevel { get; set; }

        [JsonPropertyName("merge_requests_access_level")]
        public string MergeRequestsAccessLevel { get; set; }

        [JsonPropertyName("forking_access_level")]
        public string ForkingAccessLevel { get; set; }

        [JsonPropertyName("wiki_access_level")]
        public string WikiAccessLevel { get; set; }

        [JsonPropertyName("builds_access_level")]
        public string BuildsAccessLevel { get; set; }

        [JsonPropertyName("snippets_access_level")]
        public string SnippetsAccessLevel { get; set; }

        [JsonPropertyName("pages_access_level")]
        public string PagesAccessLevel { get; set; }

        [JsonPropertyName("emails_disabled")]
        public bool EmailsDisabled { get; set; }

        [JsonPropertyName("shared_runners_enabled")]
        public bool SharedRunnersEnabled { get; set; }

        [JsonPropertyName("lfs_enabled")]
        public bool LfsEnabled { get; set; }

        [JsonPropertyName("creator_id")]
        public long CreatorId { get; set; }

        [JsonPropertyName("import_status")]
        public string ImportStatus { get; set; }

        [JsonPropertyName("import_error")]
        public object ImportError { get; set; }

        [JsonPropertyName("open_issues_count")]
        public long OpenIssuesCount { get; set; }

        [JsonPropertyName("runners_token")]
        public string RunnersToken { get; set; }

        [JsonPropertyName("ci_default_git_depth")]
        public long CiDefaultGitDepth { get; set; }

        [JsonPropertyName("ci_forward_deployment_enabled")]
        public bool CiForwardDeploymentEnabled { get; set; }

        [JsonPropertyName("public_jobs")]
        public bool PublicJobs { get; set; }

        [JsonPropertyName("build_git_strategy")]
        public string BuildGitStrategy { get; set; }

        [JsonPropertyName("build_timeout")]
        public long BuildTimeout { get; set; }

        [JsonPropertyName("auto_cancel_pending_pipelines")]
        public string AutoCancelPendingPipelines { get; set; }

        [JsonPropertyName("build_coverage_regex")]
        public string BuildCoverageRegex { get; set; }

        [JsonPropertyName("ci_config_path")]
        public string CiConfigPath { get; set; }

        [JsonPropertyName("shared_with_groups")]
        public object[] SharedWithGroups { get; set; }

        [JsonPropertyName("only_allow_merge_if_pipeline_succeeds")]
        public bool OnlyAllowMergeIfPipelineSucceeds { get; set; }

        [JsonPropertyName("allow_merge_on_skipped_pipeline")]
        public bool AllowMergeOnSkippedPipeline { get; set; }

        [JsonPropertyName("request_access_enabled")]
        public bool RequestAccessEnabled { get; set; }

        [JsonPropertyName("only_allow_merge_if_all_discussions_are_resolved")]
        public bool OnlyAllowMergeIfAllDiscussionsAreResolved { get; set; }

        [JsonPropertyName("remove_source_branch_after_merge")]
        public bool RemoveSourceBranchAfterMerge { get; set; }

        [JsonPropertyName("printing_merge_request_link_enabled")]
        public bool PrintingMergeRequestLinkEnabled { get; set; }

        [JsonPropertyName("merge_method")]
        public string MergeMethod { get; set; }

        [JsonPropertyName("suggestion_commit_message")]
        public string SuggestionCommitMessage { get; set; }

        [JsonPropertyName("auto_devops_enabled")]
        public bool AutoDevopsEnabled { get; set; }

        [JsonPropertyName("auto_devops_deploy_strategy")]
        public string AutoDevopsDeployStrategy { get; set; }

        [JsonPropertyName("autoclose_referenced_issues")]
        public bool AutocloseReferencedIssues { get; set; }

        [JsonPropertyName("permissions")]
        public Permissions Permissions { get; set; }
    }
}
