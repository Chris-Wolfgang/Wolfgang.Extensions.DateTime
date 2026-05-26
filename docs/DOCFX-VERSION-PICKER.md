## 🔧 Troubleshooting: DocFX Version Picker

The DocFX version-switcher dropdown (top-right corner of the docs site) lets readers jump between published versions. If the dropdown is missing, empty, or shows stale entries, work through the checklist below.

### Root Cause Summary

After a repo scan:
- ✅ **Templates & partials** – no custom `templates/` or `_overwrite/` folder; the project uses DocFX's built-in `default` and `modern` templates unmodified.
- ✅ **`docfx.json` config** – `_enableVersionDropdown: true`, `_versionScheme: "docfx"`, and a `versioning.groups` block that matches `v*` tags are all present and correct.
- ⚠️ **Asset cleanup** – the **critical** issue is that `keep_files: true` on every `peaceiris/actions-gh-pages` deploy step means old DocFX static files from a previous build accumulate at the gh-pages root and can conflict with a newer build's file paths, causing the version picker JavaScript to silently fail.

The workflow now includes an explicit **cleanup step** that removes all stale root-level files from `gh-pages` (except version folders such as `v1.0.0/`, the `latest/` alias, `CNAME`, and `.nojekyll`) before the latest docs are deployed.

---

### `docfx.json` Requirements

The following `globalMetadata` keys must be set for the version picker to appear:

```json
"globalMetadata": {
  "_enableVersionDropdown": true,
  "_versionScheme": "docfx"
}
```

The `versioning` block that generates per-tag builds must also be present:

```json
"versioning": {
  "groups": [
    { "tags": ["v*"], "version": "{tag}" }
  ]
}
```

---

### `versions.json` Format

The version picker reads a `versions.json` file from the **site root** (`/versions.json`). This file is generated automatically by the workflow. Its expected format is:

```json
[
  { "version": "latest", "url": "/" },
  { "version": "v1.2.3", "url": "/v1.2.3/" },
  { "version": "v1.0.0", "url": "/v1.0.0/" }
]
```

If this file is missing or malformed, the dropdown will appear empty or not render at all.

---

### Expected gh-pages Folder Structure

```
gh-pages root/
├── index.html          ← latest docs landing page
├── versions.json       ← consumed by the version picker dropdown
├── .nojekyll           ← disables Jekyll processing on GitHub Pages
├── CNAME               ← custom domain (if configured)
├── v1.2.3/             ← versioned docs (keep_files preserves these)
│   └── index.html
├── v1.0.0/
│   └── index.html
└── latest/             ← stable alias pointing to the latest version
    └── index.html
```

---

### Cleaning Up Old Files Manually

If stale files are already present on `gh-pages` and the automated cleanup step has not yet run, you can clean the branch locally:

```bash
# 1. Check out the gh-pages branch
git fetch origin gh-pages
git checkout gh-pages

# 2. Remove all root-level items except versioned folders, CNAME, and .nojekyll
find . -mindepth 1 -maxdepth 1 \
  ! -name '.git' \
  ! -name 'CNAME' \
  ! -name '.nojekyll' \
  ! -regex '.*/v[0-9].*' \
  ! -name 'latest' \
  -exec rm -rf {} +

# 3. Commit and push
git add -A
git commit -m "chore: manual cleanup of stale root DocFX assets"
git push origin gh-pages

# 4. Return to your working branch
git checkout main
```

---

### Post-Deploy Validation

Use the included validation script to verify the gh-pages branch after deployment:

```bash
bash scripts/Validate-DocsDeploy.sh
```

The script checks that:
- `index.html` exists at root
- `versions.json` exists at root and has the correct structure
- `.nojekyll` is present
- Every version referenced in `versions.json` has a corresponding folder with an `index.html`
- No known stale DocFX artifacts remain at root

---

### Common Issues

| Symptom | Likely Cause | Fix |
|---------|-------------|-----|
| Dropdown not visible at all | `_enableVersionDropdown` not set to `true` | Add `"_enableVersionDropdown": true` to `docfx.json` `globalMetadata` |
| Dropdown visible but empty | `versions.json` missing from site root | Re-run the workflow; verify the "Generate versions.json" step succeeded |
| Dropdown shows wrong versions | `versions.json` is stale | Trigger a new deployment to regenerate `versions.json` from current git tags |
| Version link returns 404 | Version folder missing from gh-pages | Redeploy that version tag via `workflow_dispatch` with `deploy_as_latest: false` |
| Picker JS fails silently | Old JS/CSS files from a previous build conflict with new build | Run the cleanup step or the manual cleanup commands above |

---
