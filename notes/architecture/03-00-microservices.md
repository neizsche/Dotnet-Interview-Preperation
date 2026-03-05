# Microservices Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
Microservices split systems into independently deployable services aligned to business capabilities, improving team autonomy, scalability, and release speed. The trade-off is distributed-system complexity: network failures, eventual consistency, observability, security, and operational overhead become first-class design concerns. Senior design focuses on service boundaries, communication contracts, resilience, and cloud-native operations rather than just splitting a monolith into many services.

## 2. Structured Study Material

### 2.1 Core Principles of Microservices

| Principle | What It Means | Why It Matters |
|---|---|---|
| Single Responsibility (per service) | Each service owns one business capability. | Smaller, focused codebases and clearer ownership. |
| Decentralization | Services and teams make local technology/deployment decisions. | Faster delivery and reduced central bottlenecks. |
| Service Independence | Build, deploy, and scale services separately. | Lower blast radius of changes and incidents. |
| API-based Communication | Services interact through explicit contracts (HTTP/gRPC/messages). | Loose coupling and replaceable implementations. |
| Data Ownership per Service | Each service owns its persistence model. | Better autonomy and schema evolution control. |
| Resilience & Fault Tolerance | Design for partial failures (retry, circuit breaker, fallback). | Prevent cascading outages. |
| Horizontal Scalability | Scale only hot services, not the whole app. | Better resource utilization and cost control. |
| Continuous Delivery/Deployment | Independent pipelines and deployments. | Faster, safer release cadence. |
| Observability | Metrics, logs, tracing across services. | Diagnose distributed failures quickly. |
| Organizational Alignment | Teams align to bounded contexts/domains. | Clear accountability and faster domain evolution. |

### 2.2 Monolith vs Microservices

| Aspect | Monolithic Architecture | Microservices Architecture | Trade-off |
|---|---|---|---|
| Structure | Single tightly coupled application | Loosely coupled independent services | Microservices add network/distributed complexity |
| Deployment | One deployable unit | Independent deployments | Needs stronger CI/CD and release governance |
| Scaling | Scale entire app | Scale selected services | Better efficiency but higher platform complexity |
| Data | Often shared DB | Database per service | Cross-service reporting and consistency get harder |
| Team model | Centralized/layered | Small cross-functional teams | Requires org maturity and ownership culture |
| Fault isolation | Failure can impact whole app | Failures isolated by service boundary | Requires resiliency patterns and observability |
| Tech stack | Usually uniform | Polyglot options possible | More operational/tooling diversity |

### 2.3 Adoption Benefits and Challenges

| Category | Benefits | Challenges |
|---|---|---|
| Delivery | Faster independent releases | Versioning and contract coordination |
| Scalability | Scale bottlenecks only | Capacity planning across many services |
| Reliability | Better fault isolation | Distributed failure modes and retries |
| Maintainability | Smaller bounded codebases | Cross-service debugging/traceability |
| Flexibility | Per-service tech choices | Skill spread and governance burden |
| Operations | DevOps automation fit | Monitoring, logging, tracing complexity |
| Security | Fine-grained service controls | Consistent authn/authz and secret management |

### 2.4 .NET Platform Fit for Microservices

| Capability | .NET Core / .NET 5+ / .NET 8 | Relevance to Microservices |
|---|---|---|
| Cross-platform runtime | Linux/Windows/macOS support | Works across cloud and container platforms |
| ASP.NET Core APIs | High-performance HTTP endpoints | Strong default for service APIs |
| Container support | First-class Docker/Kubernetes workflows | Standardized deployment model |
| Performance | Runtime/JIT/GC improvements | Better throughput and lower latency |
| Protocol support | HTTP/2, gRPC, OpenAPI | Flexible inter-service communication |
| LTS releases | Stable support windows | Predictable production maintenance |

#### ASP.NET Core Endpoint Baseline
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id) => Ok(new { Id = id, Status = "Created" });
}
```

### 2.5 Service Decomposition and Bounded Contexts

**Bounded context example (source concept):**
```csharp
public class OrderContext
{
    public class Order { }
    public class OrderItem { }
}

public class InventoryContext
{
    public class Product { }
    public class Stock { }
}

public class ShippingContext
{
    public class Shipment { }
    public class Delivery { }
}
```

| Decomposition Strategy | When to Use | Pros | Cons |
|---|---|---|---|
| Business Capability | Clear business domains exist | Aligns with org structure | Can create chatty service boundaries |
| Domain-Driven Design | Complex business logic | Strong domain alignment | Steeper learning curve |
| Subdomain Decomposition | Large, evolving domain | Supports gradual extraction | Needs strong domain expertise |
| Strangler Pattern | Monolith migration | Low-risk incremental modernization | Temporary dual-system complexity |

### 2.6 Inter-service Communication

#### Synchronous Communication (gRPC)
```csharp
// order.proto concept
service OrderService {
    rpc CreateOrder(CreateOrderRequest) returns (OrderResponse);
}

public class OrderServiceImpl : OrderService.OrderServiceBase
{
    public override Task<OrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
    {
        return Task.FromResult(new OrderResponse { OrderId = Guid.NewGuid().ToString() });
    }
}

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new OrderService.OrderServiceClient(channel);
var response = await client.CreateOrderAsync(new CreateOrderRequest());
```

#### Asynchronous Communication (Message Queue)
```csharp
public class OrderCreatedEventPublisher
{
    public void Publish(OrderCreatedEvent orderEvent)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(orderEvent));
        _channel.BasicPublish(exchange: "", routingKey: "order_created", body: body);
    }
}

public class InventoryUpdateConsumer
{
    public void StartConsuming()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (_, ea) =>
        {
            var evt = JsonSerializer.Deserialize<OrderCreatedEvent>(Encoding.UTF8.GetString(ea.Body.ToArray()));
            UpdateInventory(evt);
        };

        _channel.BasicConsume("order_created", autoAck: true, consumer: consumer);
    }
}
```

| Pattern | When to Use | Pros | Cons |
|---|---|---|---|
| gRPC | Internal low-latency, typed contracts | High performance, strong typing | HTTP/2/tooling complexity |
| REST/HTTP | Public APIs and broad interoperability | Simple and ubiquitous | Less efficient payload/protocol |
| Message Queue | Async workflows and decoupling | Reliability and loose coupling | Ordering, retries, DLQ complexity |
| Event Streaming | Real-time pipelines, CQRS/event analytics | High throughput and replay options | Operational complexity |
| WebSocket | Real-time bidirectional updates | Low-latency push updates | Connection/state management |
| Service Mesh | Standardized traffic/security policies | Centralized resilience and telemetry | Extra platform complexity/overhead |

### 2.7 Distributed Transactions and Saga Pattern

**Core problem:** 2PC/strict ACID across independent microservices is usually impractical at scale.

#### Choreography-based Saga (event-driven)
```csharp
public class OrderCreatedEvent { public Guid OrderId { get; set; } public decimal Amount { get; set; } }
public class PaymentProcessedEvent { public Guid OrderId { get; set; } public bool Success { get; set; } }

public class PaymentService
{
    public async Task HandleOrderCreated(OrderCreatedEvent evt)
    {
        try
        {
            var ok = await _paymentGateway.ChargeAsync(evt.Amount);
            await _eventBus.PublishAsync(new PaymentProcessedEvent { OrderId = evt.OrderId, Success = ok });

            if (!ok)
                await _eventBus.PublishAsync(new OrderCancelledEvent { OrderId = evt.OrderId, Reason = "Payment failed" });
        }
        catch (Exception ex)
        {
            await _eventBus.PublishAsync(new OrderCancelledEvent { OrderId = evt.OrderId, Reason = ex.Message });
        }
    }
}
```

#### Orchestration-based Saga (central coordinator)
```csharp
public class OrderSagaOrchestrator
{
    public async Task ProcessOrderCreation(Guid orderId)
    {
        var saga = new OrderCreationSaga(orderId);

        try
        {
            await _inventoryService.ReserveItemsAsync(orderId);
            saga.MarkInventoryReserved();

            await _paymentService.ProcessPaymentAsync(orderId);
            saga.MarkPaymentProcessed();

            await _orderService.ConfirmOrderAsync(orderId);
            saga.MarkCompleted();
        }
        catch (Exception ex)
        {
            if (saga.IsPaymentProcessed) await _paymentService.RefundAsync(orderId);
            if (saga.IsInventoryReserved) await _inventoryService.ReleaseItemsAsync(orderId);
            await _orderService.CancelOrderAsync(orderId, ex.Message);
        }

        await _sagaRepository.SaveAsync(saga);
    }
}
```

| Approach | What Differs | Strength | Risk/Trap | When to Choose |
|---|---|---|---|---|
| Choreography Saga | No central coordinator; services react to events | Simpler local autonomy | Harder global visibility and debugging | Smaller workflows, event-native teams |
| Orchestration Saga | Dedicated orchestrator controls steps | Clear flow and centralized compensation | Orchestrator can become bottleneck | Complex multi-step business transactions |

**Data consistency strategies from source concepts:**
- Database-per-service.
- Saga + compensating transactions.
- Event-driven propagation.
- CQRS separation.
- Eventual consistency mindset.
- Idempotent operations for retries/duplicates.

### 2.8 API Gateway, Service Discovery, and Security

#### API Gateway with Ocelot
```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/orders",
      "DownstreamScheme": "https",
      "UpstreamPathTemplate": "/orders",
      "UpstreamHttpMethod": ["GET", "POST"]
    }
  ],
  "GlobalConfiguration": {
    "ServiceDiscoveryProvider": {
      "Host": "localhost",
      "Port": 8500,
      "Type": "Consul"
    }
  }
}
```

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json");

var app = builder.Build();
app.UseOcelot().Wait();
app.Run();
```

#### Service Discovery with Consul
```csharp
public class ServiceRegistry : IHostedService
{
    public async Task StartAsync(CancellationToken ct)
    {
        var registration = new AgentServiceRegistration
        {
            ID = _serviceId,
            Name = "order-service",
            Address = "localhost",
            Port = 5001,
            Check = new AgentServiceCheck
            {
                HTTP = "https://localhost:5001/health",
                Interval = TimeSpan.FromSeconds(10),
                Timeout = TimeSpan.FromSeconds(5)
            }
        };

        await _consulClient.Agent.ServiceRegister(registration, ct);
    }
}
```

#### OAuth2 + JWT + RBAC Flow (centralized identity)

| Step | Responsibility | Notes |
|---|---|---|
| Authenticate user/client | OAuth2/OIDC identity provider | Issues signed JWT access token |
| Send bearer token | Client -> API gateway/service | `Authorization: Bearer <token>` |
| Validate token | Gateway or service middleware | Verify signature, issuer, audience, expiry |
| Authorize request | RBAC/scope policy | Role/claim-based endpoint access |
| Propagate identity | Service-to-service trust/token exchange | Maintain security context downstream |
| Revoke/refresh tokens | Identity platform | Manage token lifecycle and compromise response |

| Security Concern | Recommended Practice |
|---|---|
| Endpoint authn/authz sprawl | Centralize at gateway + consistent service policies |
| Role management | RBAC with least privilege and clear role ownership |
| Identity consistency | Central identity provider + SSO/federation |
| Service-to-service trust | mTLS + short-lived tokens |
| Security observability | Audit logs for auth failures/denials/token errors |

### 2.9 Resilience, Autoscaling, and Load Balancing

#### Polly Circuit Breaker + Retry
```csharp
var circuitBreaker = Policy<HttpResponseMessage>
    .Handle<HttpRequestException>()
    .OrResult(r => !r.IsSuccessStatusCode)
    .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

var retry = Policy<HttpResponseMessage>
    .Handle<HttpRequestException>()
    .OrResult(r => !r.IsSuccessStatusCode)
    .WaitAndRetryAsync(3, n => TimeSpan.FromSeconds(Math.Pow(2, n)));

var policy = Policy.WrapAsync(retry, circuitBreaker);
var response = await policy.ExecuteAsync(() => httpClient.GetAsync(url));
```

| Pattern | Purpose | Key Configuration | Important Constraint |
|---|---|---|---|
| Circuit Breaker | Stop hammering failing dependency | Failure threshold + break duration | Tune carefully to avoid false opens |
| Retry | Handle transient failures | Retry count + backoff | Only for idempotent/controlled operations |
| Bulkhead | Isolate resource pools | Max parallelism/queue | Prevent noisy neighbor exhaustion |
| Timeout | Bound slow dependency cost | Per-call timeout | Avoid hung request chains |

| Scaling/Traffic Technique | Role in Microservices |
|---|---|
| Kubernetes HPA | Scale pods by CPU/custom metrics |
| Cluster Autoscaler | Scale cluster node capacity |
| Cloud/Application Load Balancer | Distribute external traffic to healthy instances |
| Service Mesh balancing | Internal traffic policies and retries |
| Dynamic service discovery | Route to active healthy service instances |
| Reactive autoscaling | Scale from current load signals |
| Predictive autoscaling | Scale from historical/forecast traffic |

### 2.10 DDD and Hexagonal Architecture in Microservices

#### Strategic DDD
```csharp
public class SharedKernel
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }
        public Money(decimal amount, string currency) { Amount = amount; Currency = currency; }
    }

    public class Email
    {
        public string Value { get; }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid email");
            Value = value;
        }
    }
}
```

#### Tactical DDD (Entity, Value Object, Aggregate, Domain Event)
```csharp
public class OrderNumber : ValueObject
{
    public string Value { get; }
    public OrderNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Order number cannot be empty");
        Value = value;
    }
}

public class Order : AggregateRoot<Guid>
{
    private readonly List<OrderLine> _orderLines = new();

    public void AddOrderLine(ProductId productId, Quantity quantity, Money price)
    {
        if (quantity.Value <= 0) throw new InvalidOperationException("Quantity must be positive");

        _orderLines.Add(new OrderLine(productId, quantity, price));
        AddDomainEvent(new OrderLineAddedDomainEvent(Id, productId, quantity));
    }
}

public class OrderLineAddedDomainEvent : DomainEvent
{
    public Guid OrderId { get; }
    public ProductId ProductId { get; }
    public Quantity Quantity { get; }

    public OrderLineAddedDomainEvent(Guid orderId, ProductId productId, Quantity quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }
}
```

#### Hexagonal (Ports and Adapters)
```csharp
// Port
public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id);
    Task SaveAsync(Order order);
}

// Domain service
public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public async Task<Order> CreateOrderAsync(CustomerId customerId, List<OrderItem> items)
    {
        var order = new Order(Guid.NewGuid(), customerId, items);
        await _orderRepository.SaveAsync(order);
        return order;
    }
}

// Adapter
public class SqlOrderRepository : IOrderRepository
{
    public Task<Order> GetByIdAsync(Guid id) => _context.Orders.Include(x => x.OrderLines).FirstOrDefaultAsync(x => x.Id == id);
    public async Task SaveAsync(Order order) { _context.Orders.Update(order); await _context.SaveChangesAsync(); }
}
```

### 2.11 Cloud-Native Development and Operations

#### Docker (multi-stage, non-root, health checks)
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OrderService/OrderService.csproj", "OrderService/"]
RUN dotnet restore "OrderService/OrderService.csproj"
COPY . .
RUN dotnet publish "OrderService/OrderService.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
RUN apt-get update && apt-get install -y curl
RUN groupadd -r appgroup && useradd -r -g appgroup appuser
USER appuser
COPY --from=build /app/publish .
HEALTHCHECK --interval=30s --timeout=3s CMD curl -f http://localhost:8080/health || exit 1
ENTRYPOINT ["dotnet", "OrderService.dll"]
```

#### Docker Compose (service dependencies)
```yaml
services:
  order-service:
    build:
      context: .
      dockerfile: OrderService/Dockerfile
    ports:
      - "5001:8080"
    depends_on:
      - sql-server
      - rabbitmq

  sql-server:
    image: mcr.microsoft.com/mssql/server:2019-latest

  rabbitmq:
    image: rabbitmq:3-management
```

#### Kubernetes Deployment + Service
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: order-service
spec:
  replicas: 3
  selector:
    matchLabels:
      app: order-service
  template:
    metadata:
      labels:
        app: order-service
    spec:
      containers:
      - name: order-service
        image: myregistry/order-service:latest
        ports:
        - containerPort: 8080
        resources:
          requests:
            cpu: "250m"
            memory: "256Mi"
          limits:
            cpu: "500m"
            memory: "512Mi"
---
apiVersion: v1
kind: Service
metadata:
  name: order-service
spec:
  selector:
    app: order-service
  ports:
  - port: 80
    targetPort: 8080
```

#### Helm and IaC Snippets
```yaml
# values.yaml
replicaCount: 3
image:
  repository: myregistry/order-service
  tag: latest
resources:
  requests:
    cpu: 250m
    memory: 256Mi
```

```hcl
resource "azurerm_linux_web_app" "main" {
  name                = "app-orders-${var.environment}"
  resource_group_name = azurerm_resource_group.main.name
  service_plan_id     = azurerm_service_plan.main.id

  site_config {
    application_stack { dotnet_version = "8.0" }
    always_on = false
  }
}
```

```bicep
resource webApp 'Microsoft.Web/sites@2021-02-01' = {
  name: 'app-orders-${environment}'
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      linuxFxVersion: 'DOTNETCORE|8.0'
      alwaysOn: false
    }
    httpsOnly: true
  }
}
```

### 2.12 Practical Adoption Recommendations

| Recommendation | Why It Matters |
|---|---|
| Start with explicit business case | Avoid architecture-driven overengineering |
| Decompose by clear domain boundaries | Prevent accidental coupling and chatty traffic |
| Design for failure from day one | Distributed failures are normal, not edge cases |
| Invest early in DevOps automation | Manual ops do not scale with service count |
| Standardize observability | Debugging without traceability is slow and risky |
| Use API-first contracts | Stabilizes inter-team and inter-service integration |
| Align team topology to service ownership | Improves accountability and delivery speed |
| Iterate with metrics | Architecture should evolve with measured outcomes |

### 2.13 Real-World .NET Microservices Examples (Source Highlights)

| Organization | Noted Microservices Outcome | Practical Takeaway |
|---|---|---|
| Netflix | Migrated from monolithic style to service-based platform at massive scale. | Decomposition plus strong platform automation is essential. |
| Microsoft (Azure/Office/Xbox ecosystems) | Large-scale service architecture with cloud-native operations. | Platform consistency and observability standards matter as much as code. |
| Stack Overflow | Decomposed critical backend areas to improve scaling and deployment flexibility. | Selective decomposition can deliver value without rewriting everything at once. |
| SoundCloud | Service-oriented architecture improved resource usage and release agility. | Team autonomy and bounded ownership improve delivery speed. |
| Jet.com (Walmart) | Service decomposition supported rapid business growth and resilience needs. | Domain-focused boundaries help scale fast-moving commerce systems. |

### 2.14 API Versioning Strategies in Microservices

| Strategy | Example | Pros | Cons | When to Use |
|---|---|---|---|---|
| URI Versioning | `/api/v1/orders` | Explicit and easy to route/document | URL churn across versions | Public APIs with clear external contracts |
| Query String Versioning | `/api/orders?api-version=1.0` | Easy migration without path changes | Can be less explicit for consumers | Internal/legacy clients needing gradual rollout |
| Header Versioning | `X-API-Version: 1.0` | Keeps URI stable | Harder to test/debug manually | Internal APIs with strict gateway control |
| Media Type Versioning | `Accept: application/vnd.company.orders.v1+json` | Fine-grained content negotiation | Most complex for clients/tooling | Mature API programs with contract governance |

**Versioning guardrails:**
- Keep backward compatibility where possible.
- Publish deprecation windows and migration guides.
- Measure old-version traffic before removal.

## 3. Senior Perspective (The "Why")
- Microservices are an organizational scaling model as much as a technical architecture; team autonomy and bounded ownership drive most benefits.
- The hardest problems are rarely endpoint code. They are consistency, reliability, operational visibility, security boundaries, and versioning discipline.
- Service boundaries should optimize change isolation, not just runtime decomposition. Bad boundaries create chatty service graphs and hidden coupling.
- Synchronous communication improves simplicity for request-response flows but increases failure coupling; asynchronous/event-driven flows improve resilience but increase consistency and debugging complexity.
- Resilience patterns (retry, circuit breaker, timeout, bulkhead) must be tuned from real telemetry, otherwise they can amplify outages.
- DDD and hexagonal architecture help keep business logic stable while infrastructure evolves, which is critical for long-lived microservice systems.
- Cloud-native maturity means repeatable deployment, health probes, autoscaling, least-privilege security, and fully automated drift-free infrastructure.

## 4. Interview Gotchas & Confusion Points

| Gotcha | Why Candidates Fail | What a Strong Answer Clarifies |
|---|---|---|
| "Microservices are always better than monoliths" | Ignores context and cost. | Microservices fit when independent scaling, domain autonomy, and team parallelism justify complexity. |
| Decomposition by technical layers | Creates tightly coupled service mesh with high chatter. | Decompose by business capability/bounded context first. |
| Assuming synchronous calls are harmless | Overlooks cascading failures. | Use sync only where immediate consistency/response is required; otherwise prefer async workflows. |
| Saga without idempotency | Retries/duplicates create inconsistent states. | Every saga step and compensation must be idempotent and observable. |
| Using retries on non-idempotent operations | Can duplicate side effects. | Retries require idempotent semantics or deduplication keys. |
| Circuit breaker default tuning | Too sensitive or too lax behavior under load. | Tune thresholds and break duration from production telemetry. |
| API gateway as single security fix | Ignores downstream authz and service trust. | Gateway centralizes policy, but services still need defense-in-depth and token validation strategy. |
| Service discovery without deregistration health | Stale endpoints receive traffic. | Use active health checks and clean deregistration on shutdown/failure. |
| Database per service misunderstood | Teams keep shared DB for convenience. | True autonomy requires owned schema/data model and explicit integration paths. |
| Ignoring observability at design time | Root-cause analysis becomes impossible. | Build metrics/logging/tracing and correlation IDs into baseline templates. |
| Kubernetes adoption without platform discipline | Treats k8s as a silver bullet. | Requires resource limits, probes, autoscaling, secret management, and runbook maturity. |
| API versioning strategy undefined | Breaking changes ripple across consumers. | Define versioning policy (URI/header/media type), deprecation timeline, and backward compatibility rules. |

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

**Q1. What are the key differences between monolith and microservices?**
A: Monolith is a single deployable unit with tight coupling; microservices are independently deployable services with explicit network contracts.

**Q2. When should you choose synchronous vs asynchronous communication?**
A: Use synchronous for immediate user-facing results and simple request-response; use asynchronous for decoupling, resilience, background workflows, and eventual consistency.

**Q3. Why is database-per-service recommended?**
A: It preserves service autonomy, independent schema evolution, and reduced coupling.

**Q4. What problem does the Saga pattern solve?**
A: It coordinates distributed business transactions without 2PC by using local transactions and compensating actions.

**Q5. Circuit breaker vs retry: what is the difference?**
A: Retry handles transient faults by retrying. Circuit breaker stops calls to persistently failing dependencies to prevent cascades.

**Q6. What is service discovery and why is it needed?**
A: Dynamic lookup of healthy service instances in changing environments (containers/autoscaling).

**Q7. How does DDD relate to microservices?**
A: Bounded contexts guide service boundaries; tactical patterns keep domain logic cohesive and explicit.

**Q8. What does hexagonal architecture improve in services?**
A: Testability and maintainability by isolating domain logic from infrastructure adapters.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

**Q9. How do you handle distributed transactions without two-phase commit?**
A: Implement Saga (choreography or orchestration), enforce idempotency, persist saga state, define compensations, and monitor stuck/failed workflows.

**Q10. A service has high latency and timeouts. What is your approach?**
A: Start with metrics/logs/traces and dependency timings, then apply timeouts/retry/circuit breaker/bulkhead, optimize hot queries, and reassess boundaries if cross-service chatter is high.

**Q11. How would you implement service discovery in a dynamic environment?**
A: Register instances with Consul (or platform-native registry), add health checks, route through gateway/mesh, and ensure deregistration on termination.

**Q12. How do you secure microservices with OAuth2 and JWT?**
A: Central identity provider issues signed tokens; gateway/services validate claims and scopes; RBAC policies enforce least privilege; use HTTPS/mTLS and token lifecycle controls.

**Q13. What are core data management challenges in microservices and mitigations?**
A: Consistency, duplication, and cross-service querying. Mitigate with Saga, CQRS/read models, event-driven propagation, and API composition.

**Q14. How do you design API versioning for microservices?**
A: Choose a stable strategy (URI/query/header/media type), maintain backward compatibility, version contracts intentionally, and publish deprecation schedules with observability on old-version usage.

**Q15. How can microservices fail organizationally even if technology is good?**
A: If teams are not aligned to service ownership, platform standards are weak, and operational capabilities (SRE/DevOps/security) are underdeveloped.

## 6. The Revision Bank
1. What makes a microservice boundary good vs chatty?
2. Monolith vs microservices: when is microservices a bad choice?
3. gRPC vs REST in internal service communication.
4. When do you pick choreography vs orchestration saga?
5. Why is idempotency mandatory with retries and sagas?
6. Circuit breaker and retry: how do they complement each other?
7. What is the minimum observability baseline for microservices?
8. How do API gateway and service mesh differ in responsibility?
9. Why does database-per-service improve autonomy but complicate queries?
10. DDD bounded context and microservice boundary relationship.
11. What are the must-have Kubernetes probes and why?
12. Name three API versioning strategies and one downside of each.

## 7. Clarification / Suggested Additions Before Finalizing
- Clarification: The source note appears truncated at the end of the API versioning answer (`Accept: application/vnd...`). Do you want me to add a full standardized .NET API versioning section with complete examples?
- Clarification: Should I include a dedicated subsection on observability tooling in .NET (`OpenTelemetry`, correlation IDs, trace context propagation) with code templates?
- Suggested addition: Add a compact migration blueprint from monolith to microservices using Strangler + domain event extraction phases.
- Suggested addition: Add a production readiness checklist (SLOs, runbooks, autoscaling thresholds, chaos testing, security posture).
- Suggested addition: Add a failure-mode playbook for common incidents (dependency outage, message backlog, registry failure, token issuer downtime).
