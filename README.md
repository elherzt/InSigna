# InSigna – Secure and Reusable Auth Core for .NET 8

<p align="center">
  <img src="assets/InsignaLogo.png" alt="InSigna Logo" width="220"/>
</p>

InSigna is a lightweight authentication library built for backend projects that need clean password hashing and JWT generation.

Designed to be reusable, easy to set up, and free of domain-specific logic—this project gives you a starting point for security in any .NET 8 API, microservice, or monolith.

**Key goals:**
- ✅ Generate secure JSON Web Tokens (JWT) with custom claims
- ✅ Hash passwords with strength validation and easy verification
- ✅ Stay minimal: no controllers, no enums, no hard-coded business rules
- ✅ Plug into any backend project without refactoring or guessing

Use InSigna when you want a simple and clean base for authentication that respects separation of concerns and scales as your project grows.

## ⚙️ Tech Stack & Dependencies

InSigna is built on top of modern, battle-tested technologies to offer robust authentication without unnecessary coupling:

| Component      | Purpose                                | Notes                               |
|----------------|----------------------------------------|-------------------------------------|
| .NET 8         | Core framework                         | Minimal API support, modern syntax |
| BCrypt.Net-Next| Password hashing and verification      | Adjustable work factor (cost)      |
| System.IdentityModel.Tokens.Jwt | JWT encoding and decoding | Customizable claims & expiration   |


This stack keeps the library lightweight and easy to integrate with any backend architecture—whether monolithic, microservice-based, or serverless.

## 🚀 Integration Options

InSigna is built to fit into your backend projects with maximum flexibility. Choose the integration mode that best suits your workflow:

### 1. 🔧 Direct Source Inclusion (as Project Code)

Ideal for internal projects or when custom modifications are needed.

**Steps:**
- Clone or copy the `InSigna` source folder into your target solution.
- Add the project reference manually or via Visual Studio / `dotnet sln add`.
- Modify namespaces, logging or structure to match your architecture.
- Extend or override internal methods as needed.

✅ Best for: Rapid prototyping, internal APIs, full control over behavior.

---

### 2. 📦 Internal Plugin (as DLL Reference)

Perfect for stable setups where InSigna is used as a drop-in authentication module.

**Steps:**
- Build the InSigna project to generate the `.dll`.
- Reference the DLL in your consuming project.
- Install dependencies listed below using NuGet:
  
  | Package | Version | Purpose |
  |--------|---------|---------|
  | `Microsoft.AspNetCore.Authentication.JwtBearer` | 8.0.18+ | Bearer token support |
  | `Microsoft.AspNetCore.Identity` | 2.3.1 | Identity infrastructure (optional) |
  | `Microsoft.IdentityModel.Tokens` | 8.13.0 | Signing & cryptography |
  | `System.IdentityModel.Tokens.Jwt` | 8.13.0 | JWT legacy handling |

✅ Best for: Clean separation, plugin-based architecture, use across multiple solutions.

---

## 🔮 What’s Next

InSigna will continue growing with focused improvements:

- ⚙️ **Hashing**: Add support for Argon2, PBKDF2, and SHA-512, with configurable strength via environment or appsettings.
- 📜 **Logging**: Optional integration with `ILogger<T>` to trace login attempts, token generation, and security events.