# SignalR - Senior Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
SignalR is ASP.NET's real-time communication framework for bi-directional server-client messaging over persistent connections. It enables live updates (chat, notifications, dashboards, collaboration) by abstracting transport negotiation (WebSockets, SSE, Long Polling) and connection management. Senior-level SignalR design focuses on connection lifecycle, scale-out topology, reliability under reconnect, and secure targeted messaging.

## 2. Structured Study Material

### SignalR Overview and Purpose

SignalR is used when clients should receive server updates instantly without polling loops.

High-value outcomes from source notes:
- Real-time communication and reduced latency.
- Better UX (no manual refresh loops).
- Collaborative and multi-user scenarios.
- Real-time notifications and alerts.
- Live streaming style updates (scores, metrics, tickers).
- Scale support via shared messaging infrastructure.

Common use cases:
- Chat systems.
- Notification centers.
- Live dashboards.
- Collaborative editing.
- Multiplayer game state updates.

### Client-Server Communication Model

SignalR uses hub-based communication:
- Clients connect to a hub endpoint.
- Clients invoke hub methods on server.
- Server pushes messages to one, many, or all clients.
- Client-to-client communication happens through server relay (not direct peer-to-peer).

Connection flow:
1. Client starts negotiation/connection.
2. Transport is selected.
3. Persistent channel stays open for bidirectional messaging.
4. Reconnect logic handles transient network failures.

### SignalR Core Components

| Component | What It Is | Why It Matters | Common Interview Angle |
|---|---|---|---|
| Hub | Server class inheriting `Hub` that exposes callable methods | Organizes messaging contract | "How do clients call server methods?" |
| Connection | Logical client session (`ConnectionId`) | Needed for targeting, tracking, cleanup | "How do you map users to connections?" |
| Transport | Underlying protocol (WebSockets/SSE/Long Polling) | Affects latency, overhead, compatibility | "How does fallback work?" |
| Hub Protocol | Payload encoding (JSON/MessagePack) | Controls payload size and CPU usage | "How do you optimize throughput?" |

### Transport Comparison and Negotiation

| Aspect | WebSockets | Server-Sent Events (SSE) | Long Polling | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Directionality | Full duplex | Server to client stream + separate client requests | Request/response loop simulation | Duplex has best realtime behavior; polling has higher overhead | WebSockets by default when available |
| Latency/overhead | Lowest overhead | Low/medium | Highest overhead | Fallback improves compatibility but increases cost | Long Polling only when modern transports unavailable |
| Browser/network compatibility | High (modern) | Good (HTTP-friendly) | Highest compatibility | Compatibility fallback vs performance | Legacy/proxy-restricted environments |
| Typical SignalR behavior | Preferred transport | Automatic fallback | Last fallback | Automatic negotiation simplifies client code | Let SignalR negotiate unless policy requires restriction |

Notes compatibility detail:
- "Forever Frame" appears in older ASP.NET SignalR discussions; modern ASP.NET Core SignalR uses WebSockets/SSE/Long Polling.

### Hub Definition and Broadcasting

```csharp
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

Targeting patterns (canonical extension near source examples):

```csharp
public async Task SendToCaller(string message)
{
    await Clients.Caller.SendAsync("ReceiveMessage", "system", message);
}

public async Task SendToOthers(string user, string message)
{
    await Clients.Others.SendAsync("ReceiveMessage", user, message);
}

public async Task SendToUser(string userId, string message)
{
    await Clients.User(userId).SendAsync("ReceiveMessage", "system", message);
}
```

### Group Messaging (Hub Feature in Practice)

```csharp
public async Task JoinRoom(string room)
{
    await Groups.AddToGroupAsync(Context.ConnectionId, room);
    await Clients.Group(room).SendAsync("ReceiveMessage", "system", $"{Context.ConnectionId} joined {room}");
}

public async Task LeaveRoom(string room)
{
    await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
}

public async Task SendToRoom(string room, string user, string message)
{
    await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
}
```

### ASP.NET Core Integration

```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub");
});

app.Run();
```

Client-side integration:

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .withAutomaticReconnect()
    .build();

connection.on("ReceiveMessage", (user, message) => {
    console.log(`${user}: ${message}`);
});

connection.start().catch(err => console.error(err));

function sendMessage(user, message) {
    connection.invoke("SendMessage", user, message).catch(err => console.error(err));
}

connection.onclose(error => console.log("Connection closed", error));
connection.onreconnecting(error => console.log("Reconnecting", error));
connection.onreconnected(connectionId => console.log("Reconnected", connectionId));
```

### ASP.NET Core vs ASP.NET MVC (Classic) SignalR

| Aspect | ASP.NET Core SignalR | ASP.NET MVC/OWIN SignalR (Classic) | Trade-offs | Migration/Compatibility Impact | When to Use |
|---|---|---|---|---|---|
| Package/ecosystem | `Microsoft.AspNetCore.SignalR` | `Microsoft.AspNet.SignalR` | APIs similar conceptually but not drop-in compatible | Existing classic hubs usually need code updates | Prefer Core for modern development |
| Startup mapping | `endpoints.MapHub<T>(...)` | `RouteTable.Routes.MapHubs()` style setup | Core pipeline is endpoint routing-centric | Route config and middleware order change in migration | Core apps on .NET 6+ |
| Lifecycle APIs | `OnConnectedAsync`, `OnDisconnectedAsync` | Includes older lifecycle patterns in some versions | Some older callbacks differ/removed | Reconnection logic often moved to client handlers | Mixed legacy migration projects |
| Scale-out style | Azure SignalR Service / Redis backplane | SQL/Redis backplane patterns in classic stack | Hosting model and ops tooling differ | Scale strategy must be redesigned, not copied blindly | Cloud-native Core apps |

### Connection Lifecycle and Management

Server lifecycle hooks in ASP.NET Core:

```csharp
public class PresenceHub : Hub
{
    private readonly ILogger<PresenceHub> _logger;

    public PresenceHub(ILogger<PresenceHub> logger)
    {
        _logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation("Connected: {ConnectionId}", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation("Disconnected: {ConnectionId}, Error: {Error}",
            Context.ConnectionId,
            exception?.Message);

        await base.OnDisconnectedAsync(exception);
    }
}
```

Lifecycle management recommendations from source themes:
- Track `ConnectionId` <-> user/session mappings.
- Handle disconnect/reconnect explicitly in UX.
- Clean stale state on disconnect.
- Log lifecycle events for diagnostics.

### Real-time Messaging and Hub Method Invocation

From source flow:
- Define hub methods (e.g., `SendMessage`).
- Client invokes with `connection.invoke(...)`.
- Server emits with `Clients.*.SendAsync(...)`.
- Client subscribes with `connection.on(...)`.

`invoke` vs `send` (important interview contrast):

| Aspect | `invoke` | `send` | Trade-offs | When to Use |
|---|---|---|---|---|
| Return/ack behavior | Expects completion/return path | Fire-and-forget | `invoke` gives stronger flow control; `send` is lighter | `invoke` for command-like calls, `send` for best-effort fire-and-forget |
| Error visibility | Better surfaced in promise rejection | Limited | Reliability vs minimal overhead | Prefer `invoke` for critical user actions |

### Security: Authentication and Authorization

Source emphasizes secure communication and ASP.NET auth integration.

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

[Authorize]
public class SecureHub : Hub
{
    [Authorize(Roles = "Admin")]
    public Task BroadcastAdminMessage(string message)
        => Clients.All.SendAsync("ReceiveMessage", "admin", message);
}
```

Security best practices:
- Use HTTPS.
- Require authentication for private channels.
- Use role/policy checks for privileged hub methods.
- Validate user input and message payloads.

### Scale-out Strategy

| Aspect | Single Node | Redis Backplane | Azure SignalR Service | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Connection fan-out | Limited to one server | Shared pub/sub fan-out across nodes | Managed large-scale fan-out | More scale means more infra/ops complexity | Use scale-out for multi-instance deployments |
| Operational burden | Low | Medium | Lower app-side ops, vendor-managed service | Managed service reduces ops but adds platform dependency | Cloud-hosted high-connection systems |
| Failure behavior | Node loss drops all local connections | Better multi-node resilience | Designed for large realtime workloads | Need reconnection and retry logic regardless | Production realtime with high concurrency |

Redis backplane example:

```csharp
builder.Services
    .AddSignalR()
    .AddStackExchangeRedis("localhost:6379", options =>
    {
        options.Configuration.ChannelPrefix = "myapp";
    });
```

### Performance and Reliability Best Practices

From source notes, condensed for senior execution:
- Optimize payload size.
- Prefer async end-to-end.
- Choose JSON vs MessagePack based on compatibility vs bandwidth.
- Use groups/user targeting to avoid noisy global broadcasts.
- Apply backpressure and throttling for high-frequency events.
- Add structured logging and metrics (connect/disconnect rate, send failures, reconnect frequency, message latency).
- Plan for transient faults with automatic reconnect and idempotent client handlers.

## 3. Senior Perspective (The "Why")

- SignalR is an architecture choice, not only a library choice: it introduces persistent connections, stateful session concerns, and scale-out messaging semantics.
- The hardest production problems are not creating hubs; they are reconnect consistency, ordering expectations, and fan-out cost under load.
- Transport fallback is about compatibility safety, but fallback transports increase server/network overhead and can change latency profiles.
- Targeted messaging (user/group) is usually cheaper and safer than broad `Clients.All` broadcasting.
- Scale-out decisions affect reliability and cost: Redis backplane or managed SignalR service are operational trade-offs, not just code toggles.
- Legacy to modern evolution: concepts are stable from classic SignalR to ASP.NET Core SignalR, but APIs/startup/lifecycle hooks differ and migration needs deliberate redesign.

## 4. Interview Gotchas & Confusion Points

1. Treating SignalR as direct client-to-client transport.
Why candidates fail: they describe peer-to-peer semantics.
Strong answer: SignalR communication is mediated by server hubs; server decides fan-out targets.

2. Assuming WebSockets is always used.
Why candidates fail: ignore negotiation and environment constraints.
Strong answer: SignalR attempts WebSockets first, then falls back (SSE/Long Polling) based on support and network conditions.

3. Overusing `Clients.All` for every message.
Why candidates fail: unnecessary fan-out causes throughput and privacy issues.
Strong answer: use `Caller`, `Others`, `User`, and `Group` targeting to minimize traffic.

4. Mixing classic SignalR lifecycle APIs with ASP.NET Core APIs.
Why candidates fail: memory of older APIs leads to incorrect method overrides.
Strong answer: in ASP.NET Core hubs, use `OnConnectedAsync` and `OnDisconnectedAsync`; reconnect handling is mainly client-side events.

5. Ignoring reconnect idempotency.
Why candidates fail: duplicate UI updates or duplicate actions after reconnect.
Strong answer: client handlers should be idempotent and state re-sync should happen after reconnect.

6. Skipping connection cleanup.
Why candidates fail: stale mapping of users/connections causes misrouted messages.
Strong answer: remove mappings on disconnect and re-add on reconnect/connect.

7. Confusing authentication with authorization.
Why candidates fail: they secure connection but not method-level actions.
Strong answer: authenticate hub connection and authorize sensitive hub methods/policies.

8. No scale-out plan for multi-instance hosting.
Why candidates fail: messages only reach users connected to the same node.
Strong answer: use Redis backplane or Azure SignalR Service for cross-node fan-out.

9. Sending large payloads at high frequency.
Why candidates fail: causes latency spikes and memory pressure.
Strong answer: compress/compact payloads, delta updates, and apply throttling.

10. Assuming strict global ordering guarantees.
Why candidates fail: distributed systems and reconnects can reorder or replay events.
Strong answer: design event versioning/sequence handling if ordering is business-critical.

11. Missing observability.
Why candidates fail: cannot diagnose disconnect storms or transport downgrade issues.
Strong answer: capture structured metrics/logs around lifecycle and send failure paths.

12. Relying only on happy-path demos.
Why candidates fail: demos pass but production fails under network churn.
Strong answer: test with packet loss, reconnect loops, and node failover scenarios.

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

1. What is SignalR and why use it?
Answer: ASP.NET real-time framework for bi-directional messaging without polling loops.

2. What are hubs in SignalR?
Answer: Server-side classes exposing methods clients can invoke and endpoints server uses to push messages.

3. How does client-server communication work?
Answer: Client connects to hub, invokes hub methods, server sends events to client handlers.

4. Which transports does SignalR use?
Answer: WebSockets first, then SSE, then Long Polling as fallback.

5. How do you broadcast messages?
Answer: `Clients.All.SendAsync(...)` for all; also `Caller`, `Others`, `Group`, `User` for targeting.

6. How do clients call hub methods?
Answer: JavaScript/.NET client connection invokes methods with `invoke` (or `send`).

7. How do you integrate SignalR in ASP.NET Core?
Answer: `AddSignalR()` in services and `MapHub<T>("/route")` in endpoints.

8. Which lifecycle methods are commonly used on hub server side?
Answer: `OnConnectedAsync` and `OnDisconnectedAsync`.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

1. Users on one app instance are not receiving updates from other instances.
Answer: Missing scale-out. Add Redis backplane or Azure SignalR Service and verify sticky-session assumptions are removed.

2. Reconnect storms after network blips create duplicate notifications.
Answer: Use client reconnect handlers plus state reconciliation and idempotent message processing.

3. Chat throughput drops during traffic spikes.
Answer: Move from broad broadcasts to group/user targeting, reduce payload size, and monitor transport fallback rate.

4. Need secure admin-only realtime commands.
Answer: Authenticate hub connection, add `[Authorize]` at hub/method level, and enforce role/policy checks.

5. Migrating from classic ASP.NET MVC SignalR to ASP.NET Core SignalR.
Answer: Port hub contracts, update startup/routing model, revalidate lifecycle hooks, and retest client reconnect behavior.

6. High latency for specific geography.
Answer: Evaluate managed SignalR service region placement/CDN strategy and optimize payload protocol (e.g., MessagePack where suitable).

7. Need guaranteed ordered processing for critical events.
Answer: Add sequence numbers/versioning and client-side ordering checks; do not rely on implicit global ordering.

8. Incident response: users report random disconnects.
Answer: Inspect connection lifecycle telemetry, transport negotiation outcomes, proxy timeouts, and server resource pressure.

## 6. The Revision Bank

1. Why is SignalR better than polling for realtime UX?
2. What are the three primary transports SignalR uses today?
3. Which server-side lifecycle methods are standard in ASP.NET Core hubs?
4. When should you use `Clients.Group(...)` over `Clients.All`?
5. What problem does automatic reconnect solve, and what does it not solve?
6. How does scale-out change SignalR message delivery behavior?
7. What is the compatibility difference between classic ASP.NET SignalR and ASP.NET Core SignalR?
8. Why can transport fallback increase server cost?
9. How would you secure a hub method that only admins should call?
10. What are the trade-offs between `invoke` and `send` on the client?
11. Why do connection mappings need cleanup on disconnect?
12. Which metrics are most useful for diagnosing SignalR production issues?
