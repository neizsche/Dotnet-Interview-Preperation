# Reusable Prompt: Senior .NET Interview Playbook Transformer

Use this prompt whenever you want to convert a raw note file into a compact, senior-level interview playbook.

## Prompt Template

Act as a Senior .NET Interviewer and Technical Architect.
I am going to provide you with my raw study notes. Your task is to re-organize and condense them into a professional Interview Playbook for a developer with 5 years of experience.

Objective:
- Do not delete any technical concepts or notes.
- Compress language to high-signal study material.
- Focus on senior depth: explain why a concept is used, trade-offs, performance/memory implications, and architectural impact.
- Preserve code examples, syntax, and samples from the source notes.
- If code samples are missing in source notes for critical topics, add concise canonical examples.
- Place code examples near their related topic (inline/contextual), not in a separate standalone section.
- In possible comparison/difference scenarios, present them in a structured format (not plain prose).
- For comparisons, include: what differs, why it matters, when to choose each option, performance/memory trade-offs, migration/compatibility impact, and common interview traps.

Output format (Markdown only):
1. The Elevator Pitch (Executive Summary): 2-3 sentence summary.
2. Structured Study Material: clean Markdown tables and categorized bullets around architectural building blocks, with contextual code/syntax snippets directly under related subsections.
   - If there are comparisons (for example, Framework vs Core vs .NET 8, ADO.NET vs EF, Managed vs Unmanaged), use structured comparison tables with columns such as: `Aspect`, `Option A`, `Option B` (and `Option C` if needed), `Trade-offs`, `When to Use`.
3. Senior Perspective (The "Why"): trade-offs, scaling, memory management, and evolution (.NET Framework vs .NET 8+).
4. Interview Gotchas & Confusion Points: detailed traps and misconceptions (not over-condensed); each point should include why candidates fail and what a strong answer should clarify.
5. Tiered Interview Q&A:
   - Mid-Level: foundational "How it works".
   - Senior/Lead: scenario-based "Design & Troubleshooting".
6. The Revision Bank: 10-12 rapid-fire recall questions.
7. Clarification / Suggested Additions Before Finalizing:
   - Ask for clarification if any source note is ambiguous.
   - Suggest missing senior-level subtopics before finalizing.

Constraints:
- The output must remain Markdown.
- Keep section titles exactly as requested.
- Do not remove original concepts; de-duplicate and compress instead.
- Keep interview language practical and architecture-oriented.
- Keep the gotchas section detailed and explanatory (not terse one-liners).
- Use structured tables for all meaningful differences/comparisons instead of dense paragraphs.

Input file:
`<REPLACE_WITH_NOTE_PATH>`

Optional merge file(s):
`<REPLACE_WITH_RELATED_NOTE_PATHS_OR_LEAVE_EMPTY>`

## Quick-Use Version

Transform `<NOTE_PATH>` into a Senior .NET Interview Playbook in Markdown.
Rules:
1. Keep all technical concepts from source notes.
2. Preserve/add code samples and place each sample near its related topic.
3. Use sections: Elevator Pitch, Structured Study Material, Senior Perspective, Gotchas, Tiered Q&A, Revision Bank, Clarification.
4. Make gotchas detailed (why it is a trap + what correct senior framing looks like).
5. For every major comparison/difference topic, use structured tables with decision criteria and trade-offs.
6. Focus on why/trade-offs/performance/memory/evolution.
7. If critical senior topics are missing or ambiguous, ask before finalizing.
