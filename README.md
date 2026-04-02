# 📌 Client Renewal Management System

## 🚀 Overview

The Client Renewal Management System is a backend application built using ASP.NET Core Web API that helps manage client cases and track renewal dates.

It automatically detects upcoming renewals and processes reminders using a background job, making it useful for legal professionals, consultants, or service-based businesses.

---

## 🛠️ Tech Stack

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* BackgroundService (for scheduled jobs)

---

## 📂 Features

### ✅ Client Management

* Add new clients
* Store client details (Name, Phone, Email)

### ✅ Case Management

* Add cases linked to clients
* Store renewal dates
* Prevent duplicate entries

### ✅ Renewal Tracking

* Fetch upcoming renewals (next 7 days)
* Calculate remaining days for renewal

### ✅ Background Job (Automation)

* Runs automatically every 30 seconds (for demo)
* Detects upcoming renewals
* Marks reminders as sent
* Prevents duplicate reminders

### ✅ Dashboard API

* Total clients
* Total cases
* Upcoming renewals
* Pending reminders
* Completed reminders

---

## 🔗 API Endpoints

### Client APIs

* `POST /api/client` → Add client

### Case APIs

* `POST /api/case` → Add case
* `GET /api/case/upcoming` → Get upcoming renewals

### Dashboard API

* `GET /api/dashboard` → Get summary data

---

## ⚙️ How It Works

1. Admin adds a client
2. Admin adds a case with renewal date
3. Data is stored in SQL Server
4. Background job runs periodically
5. System checks for upcoming renewals
6. Marks reminders as sent
7. Dashboard shows real-time statistics

---

## 🧪 Sample Request

```json
POST /api/case

{
  "title": "Rental Agreement",
  "renewalDate": "2026-04-05",
  "clientId": 1
}
```

---

## 📊 Sample Response

```json
{
  "id": 1,
  "title": "Rental Agreement",
  "renewalDate": "2026-04-05T00:00:00",
  "clientId": 1
}
```

---

## ⚠️ Challenges Solved

* Circular reference issue in JSON serialization
* Duplicate data insertion handling
* Date comparison and filtering issues
* Background job state management

---

## 🚀 Future Enhancements

* Email/SMS notification integration
* JWT Authentication
* Role-based access control
* Hangfire for advanced scheduling
* Frontend (React/Angular)

---

## 👨‍💻 Author

Vinay Samanthula

---
