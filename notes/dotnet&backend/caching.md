# Caching - Senior Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
Caching is a performance and scalability control plane: it reduces latency, protects backend systems, and improves user experience by serving precomputed or recently fetched data. Senior-level caching decisions are mainly about consistency boundaries, invalidation, and operational safety, not just `Get/Set` APIs. In .NET, strong designs combine the right cache type (memory/distributed/response/client) with explicit expiry, key design, observability, and security controls.

## 2. Structured Study Material

### Caching Fundamentals and Why It Matters

Caching = storing frequently accessed data in a temporary fast store so subsequent access avoids expensive source calls.

Business and technical impact from the source notes:
- Performance improvement: lower data access time.
- Scalability: lower pressure on DB/external APIs.
- Reduced latency: faster response times.
- Cost efficiency: better compute/resource usage.
- Better UX: more responsive applications.
- Reliability/availability: partial resilience during backend hiccups.
- Optimized resource utilization: reduced network and CPU overhead.

### Caching Types and Trade-offs

| Aspect | In-Memory Cache | Distributed Cache | Output/Response Cache | Client-Side Cache | Trade-offs | When to Use |
|---|---|---|---|---|---|---|
| Location | App process memory | External multi-node cache | Cached HTTP output | Browser/mobile storage | Faster local access vs cross-instance consistency | Choose by deployment topology and consistency needs |
| Speed | Fastest (in-process) | Fast network hop | Very fast for repeated identical responses | No server round-trip for cached assets | In-memory is fastest but per-instance only | Single instance or non-shared hot data |
| Sharing across app instances | No | Yes | Depends on server/proxy setup | N/A | Shared cache adds network/ops complexity | Multi-instance/cloud deployments |
| Typical data | Reference/config/session-like data | Shared read models/session/tokens | HTML/API response payloads | Static assets and offline-friendly content | Caching too much dynamic data increases staleness risk | Stable/semi-stable content |

Additional type from notes:
- Database query result caching: avoid repeated identical query execution for read-heavy workloads.

### .NET Caching Mechanisms: Framework vs Core/Modern .NET

| Aspect | .NET Framework | .NET Core / .NET 8+ | Trade-offs | When to Use |
|---|---|---|---|---|
| In-memory API | `System.Runtime.Caching.MemoryCache` | `Microsoft.Extensions.Caching.Memory.IMemoryCache` | Legacy API is powerful but less aligned with modern DI pipeline | Prefer `IMemoryCache` in modern ASP.NET Core apps |
| Distributed cache abstraction | No first-class built-in abstraction historically | `IDistributedCache` with provider model | Distributed cache improves scale but adds serialization/network costs | Multi-instance apps or shared cache needs |
| Output/response caching | ASP.NET output cache patterns | Response caching / Output caching middleware by ASP.NET Core version | Response caching depends on HTTP semantics and cache headers | API or page responses with safe caching contracts |
| SQL cache dependency | Available in classic ASP.NET scenarios | Usually modeled with custom invalidation/event-driven patterns | Dependency tracking precision vs operational complexity | Use where change tracking signal is reliable |

### `System.Runtime.Caching.MemoryCache` (Framework-style) Overview

Core elements from source notes:
- `MemoryCache`: add/get/set/remove cache items.
- `CacheItem`: cached value + metadata.
- `CacheItemPolicy`: expiration, priority, callbacks, change monitors.
- Features: expiration, eviction priority, change monitoring, removed callbacks, stats.
- Considerations: memory pressure, invalidation strategy, scale boundary.

```csharp
using System.Runtime.Caching;

var cache = new MemoryCache("AppCache");

var policy = new CacheItemPolicy
{
    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30),
    Priority = CacheItemPriority.Default,
    RemovedCallback = args =>
    {
        Console.WriteLine($"Removed: {args.CacheItem.Key}, reason: {args.RemovedReason}");
    }
};

cache.Set("user:42", "Alice", policy);
var value = cache.Get("user:42");
cache.Remove("user:42");
```

File-based dependency example (from source concept):

```csharp
var dependency = new CacheDependency("filePath");
cache.Insert("config:key", "value", dependency);
```

### `Microsoft.Extensions.Caching` in ASP.NET Core

#### In-memory cache setup and usage

```csharp
// Program.cs
builder.Services.AddMemoryCache();

public class ProductService
{
    private readonly IMemoryCache _cache;

    public ProductService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Product GetProduct(int id)
    {
        var cacheKey = $"product:{id}";

        return _cache.GetOrCreate(cacheKey, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
            entry.SlidingExpiration = TimeSpan.FromMinutes(2);
            entry.Priority = CacheItemPriority.High;

            return FetchProductFromSource(id);
        });
    }

    private Product FetchProductFromSource(int id)
    {
        // Database/API call
        return new Product { Id = id, Name = "Demo" };
    }
}
```

#### Distributed cache setup (Redis example from source)

```csharp
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = "SampleInstance";
});
```

```csharp
public class UserProfileService
{
    private readonly IDistributedCache _distributedCache;

    public UserProfileService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<string?> GetProfileJsonAsync(string userId)
    {
        return await _distributedCache.GetStringAsync($"profile:{userId}");
    }
}
```

### Managing Cache Entries and Expiration Policies

| Aspect | Option A | Option B | Trade-offs | When to Use |
|---|---|---|---|---|
| Expiration type | Absolute expiration | Sliding expiration | Absolute gives predictable max staleness; sliding keeps hot keys alive but can retain stale data longer | Absolute for strict freshness windows; sliding for hot read paths |
| Invalidation trigger | Time-based | Event/dependency-based | Time-based is simpler but can be stale; event-driven is accurate but operationally harder | Event-driven for correctness-critical data |
| Removal | Automatic eviction | Manual remove (`Remove`) | Manual gives precise control but needs discipline | Use manual invalidation in write paths |

```csharp
// Absolute expiration
_cache.Set("key:absolute", value, TimeSpan.FromMinutes(10));

// Sliding expiration
_cache.Set("key:sliding", value, new MemoryCacheEntryOptions
{
    SlidingExpiration = TimeSpan.FromMinutes(10)
});

// Manual invalidation
_cache.Remove("key:absolute");
```

Cache entry options from source concepts:
- Priority controls eviction preference.
- Post-eviction callbacks allow cleanup/logging.
- Expiration tokens/dependencies can tie cache to external changes.

### Cache Dependencies and Invalidation Patterns

Cache dependency concept: cached item is linked to a source condition; when source changes, item is invalidated.

Dependency kinds from source notes:
- File dependency.
- Key dependency.
- Database dependency/change tracking.
- Custom dependency.

Practical invalidation toolkit (source-preserving):
- Expiration-based invalidation.
- Dependency/event-driven invalidation.
- Eviction when cache limits are reached (LRU/LFU/FIFO-like behavior by provider).
- Manual invalidation after writes.
- Cache busting via versioned keys.
- Automated invalidation jobs/background workers.

Cache busting example:

```csharp
var version = "v3"; // increment on schema/content changes
var cacheKey = $"catalog:{version}:category:{categoryId}";
```

### Distributed Caching in Distributed Systems

Distributed caching benefits from source notes:
- Horizontal scalability by distributing load.
- Lower latency through nearby hot data.
- High availability and fault tolerance with replication.
- Reduced backend load.
- Better support for large datasets.
- Cache invalidation/expiration controls across nodes.
- Load balancing friendliness.

### Distributed Provider Comparison

| Aspect | Redis | SQL Server Cache | NCache | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Strength | Very high throughput, rich data structures | Reuse existing SQL infra | .NET-focused distributed cache features | Infra familiarity vs raw cache performance | Pick based on org stack and throughput/latency needs |
| Typical latency | Low | Higher than in-memory Redis patterns | Low/medium depending topology | SQL-backed cache may have more storage overhead | Redis for high-QPS read paths |
| Operational model | Separate cache cluster | DB-backed cache table/service | Dedicated cache cluster for .NET | Dedicated cache requires ops maturity | SQL cache when DB platform ownership already exists |
| .NET integration | Strong (`IDistributedCache`, StackExchange.Redis) | Supported provider options | Strong .NET integration | Feature richness may increase complexity | NCache in .NET-heavy enterprises needing advanced features |

### Core Caching Strategies

| Aspect | Cache-Aside (Lazy) | Read-Through | Write-Through | Cache-Through / Write-Behind | Trade-offs | When to Use |
|---|---|---|---|---|---|---|
| Read miss handling | App fetches source then populates cache | Cache layer fetches source automatically | N/A for read path | N/A for read path | Cache-aside is simplest and common in app code | Most service-layer APIs |
| Write path | App writes source then invalidates/updates cache | Usually handled by cache abstraction/provider | Write cache and source together | Write cache now, persist source asynchronously | Write-behind boosts write latency but risks consistency on failures | Eventual consistency tolerant workloads |
| Consistency | App-controlled | Cache-controlled | Stronger cache/source sync | Eventual consistency | More automation can hide failure complexity | Choose based on consistency SLA |

Cache-aside sample:

```csharp
public async Task<Product> GetProductAsync(int id)
{
    var key = $"product:{id}";
    var cached = await _distributedCache.GetStringAsync(key);

    if (cached is not null)
        return JsonSerializer.Deserialize<Product>(cached)!;

    var product = await _repository.GetByIdAsync(id);
    await _distributedCache.SetStringAsync(
        key,
        JsonSerializer.Serialize(product),
        new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        });

    return product;
}
```

### Choosing the Right Strategy (Decision Matrix)

| Decision Input | Preferred Strategy | Why |
|---|---|---|
| Read-heavy with occasional writes | Cache-aside + absolute/sliding expiry | Simple and effective; app controls invalidation |
| Multi-instance app with shared state | Distributed cache + event-driven invalidation | Cross-node consistency and shared hot keys |
| Strict write consistency requirement | Write-through or source-first write + explicit invalidation | Reduces stale read window |
| Very high write throughput, eventual consistency acceptable | Write-behind/cache-through | Lower write latency with async persistence |
| Highly sensitive or regulated data | Minimize cache footprint + encryption + short TTL | Reduces exposure window and compliance risk |

### Security for Cached Data

Source concepts preserved:
- Encrypt sensitive cached payloads.
- Integrity check hashes to detect tampering.
- Secure key management and key rotation.
- Access controls (RBAC).
- Data masking/tokenization where needed.
- Secure transmission (TLS).
- Data lifecycle controls (TTL, cleanup).
- Segmentation of sensitive vs non-sensitive caches.
- Audit logging and monitoring.

Canonical encryption + integrity pattern:

```csharp
public static class CacheCrypto
{
    public static byte[] Encrypt(byte[] plain, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using var encryptor = aes.CreateEncryptor();
        return encryptor.TransformFinalBlock(plain, 0, plain.Length);
    }

    public static byte[] ComputeHmac(byte[] data, byte[] secret)
    {
        using var hmac = new HMACSHA256(secret);
        return hmac.ComputeHash(data);
    }
}
```

### Cache Maintenance: Cleanup and Size Management

| Aspect | Technique | Why It Matters |
|---|---|---|
| Expired data removal | Automatic expiration + periodic cleanup jobs | Prevent stale growth and memory waste |
| Eviction behavior | Priority + provider eviction policy | Preserve high-value keys under pressure |
| Size control | Size limits and monitoring thresholds | Prevent OOM or cache stampedes from overgrowth |
| Warm-up | Preload hot keys at startup | Reduce cold-start misses |
| Observability | Hit ratio, miss ratio, eviction count, latency | Enables iterative tuning |

Maintenance playbook from source notes:
- Automatic cleanup through expiration + scheduled tasks.
- Manual admin controls for selective key purge/full clear.
- Cache partitioning/sharding for different data classes.
- Performance tuning via live metrics and threshold alerts.

### Output/Response Caching Notes

Output/response caching concept from source:
- Cache generated response output to avoid recomputation.
- Best for static/semi-static content.
- Must align with HTTP caching semantics to avoid serving incorrect personalized data.

## 3. Senior Perspective (The "Why")

- Invalidation dominates complexity: adding cache is easy; proving correctness under write concurrency is hard.
- Caching changes consistency contracts: teams must define acceptable staleness per endpoint and per domain object.
- Scale choice is architectural: in-memory cache is an optimization inside one node; distributed cache is a shared subsystem with operational overhead.
- Memory and cost trade-off: aggressive TTL/large values raise memory pressure and eviction churn, which can reduce performance gains.
- Security trade-off: cached sensitive data increases blast radius unless encrypted, short-lived, segmented, and audited.
- Evolution view (.NET Framework vs modern .NET): legacy `System.Runtime.Caching` patterns are still useful, but modern ASP.NET Core favors DI-based `IMemoryCache` and `IDistributedCache` abstractions for portability and cloud scale.
- Reliability lens: cache should degrade gracefully (fallback to source) and never be a single point of failure.

## 4. Interview Gotchas & Confusion Points

1. "Cache is always faster, so cache everything."
Why candidates fail: they ignore memory limits, invalidation costs, and stale risk.
Strong answer: cache only high-value hot data with explicit TTL and invalidation rules.

2. Mixing up in-memory and distributed cache guarantees.
Why candidates fail: they assume in-memory cache is shared across app instances.
Strong answer: in-memory is per-process; distributed cache is required for cross-instance consistency.

3. No invalidation path on writes.
Why candidates fail: reads look correct in tests but stale in production.
Strong answer: every write path defines cache update/invalidate behavior.

4. Sliding expiration overuse.
Why candidates fail: hot stale keys can live too long.
Strong answer: combine sliding with absolute max lifetime for bounded staleness.

5. Treating cache hit ratio as the only metric.
Why candidates fail: high hit ratio can still hide slow serialization/network or stale data incidents.
Strong answer: track latency, evictions, value size, backend fallbacks, and stale-read errors.

6. Caching sensitive data in plaintext.
Why candidates fail: they overlook insider risk and memory dumps.
Strong answer: encrypt sensitive payloads, rotate keys, enforce TLS, and segment sensitive caches.

7. Misunderstanding write-through vs write-behind.
Why candidates fail: they expect strong consistency from async write-behind.
Strong answer: write-behind improves latency but accepts eventual consistency and failure reconciliation complexity.

8. Assuming distributed cache means high availability by default.
Why candidates fail: cluster topology and failover are not configured.
Strong answer: explain replication/failover plan and failure testing.

9. Using one giant cache key namespace.
Why candidates fail: invalidation and ownership become chaotic.
Strong answer: define key conventions by domain, version, and scope.

10. Ignoring cache stampede risk.
Why candidates fail: many requests miss and hammer the backend at once.
Strong answer: add request coalescing, staggered expiries, or lock/lease patterns for hot keys.

11. Assuming EF Core automatically caches query results globally.
Why candidates fail: they confuse query plan caching with data result caching.
Strong answer: result caching usually requires explicit app/distributed cache strategy.

12. No cleanup strategy for long-lived caches.
Why candidates fail: memory bloat and noisy evictions degrade performance.
Strong answer: set size limits, TTL discipline, and periodic maintenance.

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

1. What is caching?
Answer: storing frequently accessed data in a faster temporary store to reduce source lookups.

2. In-memory vs distributed cache?
Answer: in-memory is fastest but per-instance; distributed is shared across instances and scales horizontally.

3. What is cache-aside?
Answer: app reads cache first, falls back to source on miss, then stores result back in cache.

4. Absolute vs sliding expiration?
Answer: absolute expires at fixed time; sliding extends lifetime on each access.

5. Why do we need cache invalidation?
Answer: to prevent stale data after source changes.

6. What are common distributed cache providers in .NET ecosystems?
Answer: Redis, SQL-backed providers, and NCache in .NET-heavy environments.

7. What is output/response caching?
Answer: caching full HTTP responses for repeat requests when content is safe to reuse.

8. What is cache dependency?
Answer: a link between cached item and source condition that triggers invalidation on change.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

1. API latency spikes after scale-out from 1 to 10 pods. What changed?
Answer: in-memory cache became fragmented per instance; move shared hot data to distributed cache and review key/TTL strategy.

2. Users see stale data for up to 30 minutes after updates.
Answer: introduce write-path invalidation/event-driven updates and tighten TTL for volatile entities.

3. Cache hit ratio is high but DB load is still high.
Answer: likely caching wrong keys or low-value reads; inspect miss hotspots, key cardinality, and stampede behavior.

4. Payment/profile data must be cached for performance but is sensitive.
Answer: encrypt payloads, keep short TTL, segment by sensitivity, audit access, and avoid caching full secrets.

5. You need strong consistency after writes on critical entities.
Answer: avoid async write-behind for those entities; use source-first write + deterministic invalidate/update.

6. During incident, cache cluster is down. How should app behave?
Answer: fail open to source with backpressure/rate-limits, degrade noncritical features, and avoid hard dependency on cache availability.

7. How do you prevent cache stampede on a hot key?
Answer: single-flight/request coalescing, jittered expirations, and early refresh strategies.

8. How do you decide between Redis and SQL-backed cache in a .NET enterprise app?
Answer: compare latency/SLA, operational maturity, existing infra ownership, and required cache feature set.

## 6. The Revision Bank

1. Define cache-aside in one sentence.
2. Why is invalidation usually harder than cache reads/writes?
3. When is distributed cache mandatory over in-memory cache?
4. What problem does sliding expiration solve, and what risk does it introduce?
5. Give one case where write-behind is a bad choice.
6. How do versioned cache keys help deployment safety?
7. What metrics would you track to tune caching in production?
8. Why can high cache hit ratio still coexist with poor user latency?
9. Name two controls for protecting sensitive cached data.
10. What is the difference between response caching and data caching?
11. How does cache dependency improve consistency?
12. What operational risks appear when cache size is unbounded?

## 7. Clarification / Suggested Additions Before Finalizing
- Cache stampede mitigation patterns (single-flight locks, soft TTL + background refresh).
- Distributed invalidation via message bus/outbox events.
- Multi-level caching (L1 in-memory + L2 distributed) with consistency rules.
- Provider-specific operational guidance (Redis persistence modes, eviction policy selection, cluster failover testing).
- Benchmark-driven tuning checklist (value size budgets, serialization format, compression threshold).
