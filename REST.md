You’re absolutely right! Let’s restore the missing details while retaining a clean, organized structure. Below is a **comprehensive yet concise version** that preserves all critical content from your original revamped guide, formatted for clarity:

---

### **1. Definition of REST**  
**REST (REpresentational State Transfer)**  
An architectural style for building scalable web services using HTTP. Resources (e.g., users, orders) are accessed via **URIs** and manipulated using standard HTTP methods. Emphasizes statelessness, cacheability, and a uniform interface.

---

### **2. REST Principles (6 Constraints)**  
1. **Client-Server**: Separation of concerns (UI vs. data storage).  
2. **Stateless**: No client context stored on the server between requests.  
3. **Cacheable**: Responses must define caching rules.  
4. **Uniform Interface**: Standardized interaction (resources, URIs, HTTP methods).  
5. **Layered System**: Proxies/gateways improve scalability.  
6. **Code-on-Demand (Optional)**: Servers can extend client functionality (e.g., JavaScript).  

---

### **3. HTTP Methods in REST**  
| Method   | Idempotent? | Safe? | Usage                          | Example              |  
|----------|-------------|-------|--------------------------------|----------------------|  
| `GET`    | Yes         | Yes   | Retrieve data                  | `GET /users`         |  
| `POST`   | No          | No    | Create resource (server ID)    | `POST /users` → 201  |  
| `PUT`    | Yes         | No    | Replace entire resource        | `PUT /users/123`     |  
| `DELETE` | Yes         | No    | Remove resource                | `DELETE /users/123`  |  
| `PATCH`  | No*         | No    | Partial update                 | `PATCH /users/123`   |  

---

### **4. HTTP Status Codes**  
- **2xx Success**:  
  - `200 OK`: Generic success (e.g., `GET` or `PUT`).  
  - `201 Created`: Resource created (common for `POST`).  
  - `204 No Content`: Success with no body (common for `DELETE`).  
- **4xx Client Errors**:  
  - `400 Bad Request`: Invalid input (e.g., malformed JSON).  
  - `401 Unauthorized`: Missing/wrong authentication.  
  - `404 Not Found`: Resource does not exist.  
- **5xx Server Errors**:  
  - `500 Internal Server Error`: Unhandled server exception.  

---

### **5. REST Best Practices**  
- **Resource Naming**: Use nouns (e.g., `/users`, `/orders`).  
- **URI Structure**:  
  - Use hyphens for readability: `/product-categories` (not camelCase).  
  - Hierarchical relationships: `/users/{userId}/posts`.  
- **Versioning**:  
  - URI path (`/v1/users`) or headers (`Accept: application/vnd.myapi.v2+json`).  
- **Documentation**: Use OpenAPI/Swagger with examples for all endpoints.  

---

### **6. Content Negotiation**  
**Goal**: Serve data in the client’s preferred format (JSON, XML, etc.).  

**Implementation**:  
1. **Client Request**:  
   ```http  
   GET /users/123 HTTP/1.1  
   Accept: application/xml  
   ```  
2. **Server Response**:  
   ```http  
   HTTP/1.1 200 OK  
   Content-Type: application/xml  
   <user><id>123</id><name>Alice</name></user>  
   ```  
- Use `406 Not Acceptable` if the server can’t match the `Accept` header.  
- Default to JSON for simplicity.  

---

### **7. Authentication & Authorization**  
**Authentication (Verify Identity)**:  
- **OAuth 2.0**:  
  - **Authorization Code Flow**: Secure for web apps (redirect-based).  
  - **Client Credentials Flow**: Server-to-server communication.  
- **JWT (JSON Web Tokens)**:  
  - Structure: `header.payload.signature` (base64-encoded).  
  - Example:  
    ```  
    eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0Iiwicm9sZSI6ImFkbWluIn0.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c  
    ```  

**Authorization (Access Control)**:  
- **Scopes**: Limit token permissions (e.g., `read:users`).  
- **Role-Based Access Control (RBAC)**: Assign roles like `admin` or `user`.  

**Security Best Practices**:  
- Always use HTTPS.  
- Store tokens securely (HTTP-only cookies for browsers).  

---

### **8. Versioning Strategies**  
| Method       | Example                   | Pros               | Cons                |  
|--------------|---------------------------|--------------------|---------------------|  
| URI Path     | `/v1/users`               | Simple to implement | Breaks URIs         |  
| Query Param  | `/users?version=1`        | Easy to test       | Pollutes URLs       |  
| Header       | `Accept: application/vnd.myapi.v2+json` | Clean URIs | Harder to debug     |  

---

### **9. Idempotent Methods**  
- **Idempotent**: `GET`, `PUT`, `DELETE` (repeated requests have the same effect).  
- **Non-idempotent**: `POST`, `PATCH` (may create duplicate resources).  

---

### **10. Core Components of an HTTP Request**  
1. **Method**: Defines the action (`GET`, `POST`, etc.).  
2. **URI**: Identifies the resource (e.g., `/users/123?role=admin`).  
3. **Headers**:  
   - `Authorization`: `Bearer <token>` or `Basic <credentials>`.  
   - `Content-Type`: Format of the request body (e.g., `application/json`).  
4. **Body**:  
   - JSON (common):  
     ```json  
     { "name": "Alice", "email": "alice@example.com" }  
     ```  
   - Form data (e.g., file uploads).  

---

### **11. PUT vs POST vs PATCH**  
| Method | Purpose            | Idempotent? | Response Code |  
|--------|--------------------|-------------|---------------|  
| POST   | Create new resource | No          | 201 Created   |  
| PUT    | Replace entire resource | Yes | 200 OK/204 No Content |  
| PATCH  | Partial update     | No*         | 200 OK/204 No Content |  

---

### **12. REST Pros & Cons**  
**Advantages**:  
- Statelessness improves scalability.  
- Cacheability reduces server load.  
- Leverages HTTP standards (simple to adopt).  

**Disadvantages**:  
- Over-fetching/under-fetching data.  
- No built-in support for real-time communication (use WebSockets).  

---

### **13. API Design Guide**  
**Step 1: Resource Modeling**  
- Use nouns for resources (e.g., `/users`, `/products`).  
- Sub-resources for hierarchies: `/users/{userId}/orders`.  

**Step 2: Error Handling**  
- Standardize error responses:  
  ```json  
  {  
    "error": {  
      "code": "INVALID_EMAIL",  
      "message": "Invalid email format",  
      "details": "email@domain"  
    }  
  }  
  ```  
- Use appropriate HTTP status codes (e.g., `400`, `429`).  

**Step 3: Pagination & Filtering**  
- Offset-based: `/users?page=2&limit=10`.  
- Cursor-based: `/users?cursor=abc123&limit=10` (efficient for large datasets).  

**Step 4: Testing**  
- Unit tests for edge cases (e.g., invalid inputs).  
- Use Postman/Newman for automated API testing.  

---

### **14. Common Pitfalls**  
- **Chatty APIs**: Avoid excessive small requests; use batch operations.  
- **Ignoring Caching**: Add `Cache-Control` headers for performance.  
- **Overfetching**: Let clients request specific fields (`/users?fields=name,email`).  

---

This version retains **all critical technical details** from your original guide while using a clean, structured format. Let me know if any specific sections need further expansion! 🔍
