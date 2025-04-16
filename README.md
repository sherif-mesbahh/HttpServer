# HttpServer

A concurrent HTTP server developed in C#, designed to efficiently handle multiple client connections using asynchronous I/O operations.

## Features

- **Concurrent Request Handling**: 
  - Uses `async/await` for efficient I/O operations
  - Implements semaphore to limit maximum concurrent connections
  - Handles multiple clients simultaneously without blocking

- **HTTP Protocol Support**:
  - Processes GET requests with proper HTTP responses
  - Implements standard status codes (200 OK, 404 Not Found, 500 Internal Server Error)
  - Supports basic routing mechanism

- **Software Design**:
  - Follows SOLID principles for clean architecture
  - Implements Single Responsibility Pattern for separation of concerns
  - Uses Factory Pattern for dynamic handler instantiation
  - Modular design for easy maintenance and scalability

## Technical Implementation

### Core Components

1. **HTTP Listener**:
   - Asynchronous socket handling
   - Connection management with semaphore
   - Request lifecycle control

2. **Request Processor**:
   - HTTP protocol parsing
   - Route matching
   - Handler instantiation via factory

3. **Response Generator**:
   - Status code handling
   - Header formation
   - Content delivery
	- 
### Concurrency Control

The server uses a `SemaphoreSlim` to limit concurrent connections:

### Examples
	#Successful request
	curl -v curl http://localhost:8080

	#Successful request
	curl -v curl http://localhost:8080/home

	#Not found request
	curl -v curl http://localhost:8080/test
	
